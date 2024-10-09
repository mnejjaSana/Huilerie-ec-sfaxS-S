﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Threading;
using Gestion_de_Stock.Model.Enumuration;
using Gestion_de_Stock.Model;
using Gestion_de_Stock.Repport;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmAjouterReglementAchat : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAjouterReglementAchat _FrmAjouterReglementAchat;
        private CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        string decimalSeparator;
        private Model.ApplicationContext db;
        private Societe societe;

        public static FrmAjouterReglementAchat InstanceFrmAjouterReglementAchat
        {
            get
            {
                if (_FrmAjouterReglementAchat == null)
                    _FrmAjouterReglementAchat = new FrmAjouterReglementAchat();
                return _FrmAjouterReglementAchat;
            }
        }


        public FrmAjouterReglementAchat()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
            decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

        }



        private void FrmAjouterReglementAchat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAjouterReglementAchat = null;

        }


        private void BtnValider_Click(object sender, EventArgs e)
        {
            List<PersonneListeAchat> ListePassagers = new List<PersonneListeAchat>();
          
          
            db = new Model.ApplicationContext();
            Caisse caisse = db.Caisse.FirstOrDefault();
            List<PersonneListeAchat> ListePersonneTicket = new List<PersonneListeAchat>();
            decimal MontantEncaisse;
            string MontantEncaisseStr = TxtMontantEncaisse.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantEncaisseStr, out MontantEncaisse);

            decimal MontantOperation;
            string MontantOperationStr = TxtMontantOperation.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(MontantOperationStr, out MontantOperation);

            decimal Solde;
            string SoldeStr = TxtSolde.Text.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            decimal.TryParse(SoldeStr, out Solde);


            var codesAchats = TxtCodeAchat.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(code => code.Trim()).ToList();

            if (MontantEncaisse > Solde || MontantEncaisse <= 0)
            {
                XtraMessageBox.Show("Montant Règlement Invalid", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMontantEncaisse.Text = Solde.ToString();
                return;

            } 


            if (MontantEncaisse > caisse.MontantTotal)
            {
                XtraMessageBox.Show("Solde Caisse est Insuffisant", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtMontantEncaisse.Text = Solde.ToString();
                return;

            }

            var mtTicket = 0m;
            string num = codesAchats[0].Trim();
            Achat Achat = db.Achats.Where(x => x.Numero.Equals(num)).FirstOrDefault();


            if (gridView1.RowCount != 0 && MontantEncaisse <3000)
            {
                XtraMessageBox.Show("Impossible de répartir le montant de règlement!", "Configuration de l'application", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                return;
            }

            if (gridView1.RowCount == 0 && MontantEncaisse == Solde)
            {
                
                decimal initialMontantEncaisse = MontantEncaisse; // Save the initial value


                HistoriquePaiementAchats HP = new HistoriquePaiementAchats();

                Depense D = new Depense();
                var MtAdeduireAjouterREG = 0m;
                var MtAPayeAvecImpoAjouterREG = 0m;

                MouvementCaisse mvtCaisse = new MouvementCaisse();

                Caisse CaisseDb = db.Caisse.Find(1);


                if (MontantEncaisse >= 3000)
                {

                    bool executer = false;
                    var customMessageBox1 = new Message("Voulez vous exécuter le retenu 1%?");

                    var result = customMessageBox1.ShowDialog();

                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        executer = true;
                    }

                    if (executer == false)
                    {
                        var customMessageBox = new Message("Voulez vous répartir le montant d'avance?");
                        var result1 = customMessageBox.ShowDialog();
                        if (result1 == DialogResult.Cancel || result1 == DialogResult.Yes)
                        {
                            return;
                        }


                    }
                    if (executer == true)
                    {
                        D.Nature = NatureMouvement.ReglementImpo;

                        MtAdeduireAjouterREG = decimal.Divide(MontantEncaisse, 100);
                        MtAPayeAvecImpoAjouterREG = decimal.Subtract(MontantEncaisse, MtAdeduireAjouterREG);
                        D.Montant = MtAPayeAvecImpoAjouterREG;
                        HP.AvecAmpoAjouterREG = true;
                        mvtCaisse.MontantSens = MtAPayeAvecImpoAjouterREG * -1;
                        mtTicket = MtAPayeAvecImpoAjouterREG;
                        if (CaisseDb != null)
                        {
                            CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MtAPayeAvecImpoAjouterREG);

                        }
                        Retenue Retenu = new Retenue();
                        Retenu.MontantReglement = MontantEncaisse;
                        Retenu.MontantRetenue = MtAdeduireAjouterREG;
                        Retenu.Commentaire = "Règlement Achat(s)" + TxtCodeAchat.Text;
                        db.retenus.Add(Retenu);
                        db.SaveChanges();
                        Retenu.Numero = "RTN" + (Retenu.Id).ToString("D8");
                        db.SaveChanges();
                    }
                    else
                    {
                        mtTicket = initialMontantEncaisse;
                        D.Nature = NatureMouvement.RéglementAchats;
                        HP.AvecAmpoAjouterREG = false;
                        D.Montant = MontantEncaisse;
                        mvtCaisse.MontantSens = MontantEncaisse * -1;
                        if (CaisseDb != null)
                        {
                            CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MontantEncaisse);

                        }

                    }


                }
                foreach (var code in codesAchats)
                {

                    Achat Achatdb = db.Achats.Where(x => x.Numero.Equals(code.Trim())).FirstOrDefault();
                    var reste = Achatdb.ResteApayer;
                    if (Achatdb != null)
                    {
                        Achatdb.EtatAchat = EtatAchat.Reglee;
                        Achatdb.MontantRegle = Achatdb.MontantReglement;

                        HistoriquePaiementAchats HPAchat = new HistoriquePaiementAchats();

                        HPAchat.Founisseur = Achatdb.Founisseur;
                        HPAchat.NumAchat = Achatdb.Numero;
                        HPAchat.MontantReglement = Achatdb.MontantReglement;
                        HPAchat.MontantRegle = reste;
                        HPAchat.ResteApayer = 0;
                        HPAchat.Commentaire = "Règlement Caisse";
                        HPAchat.TypeAchat = Achatdb.TypeAchat;
                        db.HistoriquePaiementAchats.Add(HPAchat);
                        db.SaveChanges();
                    }


                }

                // Depense 

                D.CodeTiers = Achat.Founisseur.Numero;
                D.Agriculteur = Achat.Founisseur;

                D.ModePaiement = "Espèce";
                D.Tiers = Achat.Founisseur.FullName;
                D.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;
                db.Depenses.Add(D);
                db.SaveChanges();
                int lastDep = db.Depenses.ToList().Count() + 1;
                D.Numero = "D" + (lastDep).ToString("D8");
                db.SaveChanges();

                // mvmCaisse

                mvtCaisse.Sens = Sens.Depense;
                mvtCaisse.Date = DateTime.Now;
                mvtCaisse.Agriculteur = Achat.Founisseur;
                mvtCaisse.CodeTiers = Achat.Founisseur.Numero;
                mvtCaisse.Source = "Agriculteur: " + Achat.Founisseur.FullName;
                mvtCaisse.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;
                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                mvtCaisse.Achat = null;
                mvtCaisse.Montant = CaisseDb.MontantTotal;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();
            }

            if (gridView1.RowCount == 0 && MontantEncaisse < Solde)
            { // Calculer 1% de MontantEncaisse
                

                decimal initialMontantEncaisse = MontantEncaisse; // Save the initial value
                mtTicket = initialMontantEncaisse;

                HistoriquePaiementAchats HP = new HistoriquePaiementAchats();

                Depense D = new Depense();
                var MtAdeduireAjouterREG = 0m;
                var MtAPayeAvecImpoAjouterREG = 0m;

                MouvementCaisse mvtCaisse = new MouvementCaisse();

                Caisse CaisseDb = db.Caisse.Find(1);


                if (MontantEncaisse >= 3000)
                {
                    bool executer = false;
                    var customMessageBox1 = new Message("Voulez vous exécuter le retenu 1%?");

                    var result = customMessageBox1.ShowDialog();

                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        executer = true;
                    }

                    if (executer == false )
                    {
                        var customMessageBox = new Message("Voulez vous répartir le montant d'avance?");
                        var result1 = customMessageBox.ShowDialog();
                        if (result1 == DialogResult.Cancel || result1 == DialogResult.Yes)
                        {
                            return;
                        }


                    }


                    //var customMessageBox = new Message("Voulez-vous répartir le montant à payer?");
                    //var result = customMessageBox.ShowDialog();

                    // Check which button was clicked
                    //if (result == DialogResult.Yes || result == DialogResult.Cancel)
                    //{
                    //    return;
                    //}
                    //var result = XtraMessageBox.Show(
                    //     "Voulez vous répartir le montant du Règlement?",
                    //     "Configuration de l'application",
                    //     MessageBoxButtons.YesNoCancel,
                    //     MessageBoxIcon.Exclamation);

                    //// Check which button was clicked
                    //if (result == DialogResult.Yes || result == DialogResult.Cancel)
                    //{
                    //    return;
                    //}

                    if (executer==true)
                    {
                        D.Nature = NatureMouvement.ReglementImpo;

                        MtAdeduireAjouterREG = decimal.Divide(MontantEncaisse, 100);
                        MtAPayeAvecImpoAjouterREG = decimal.Subtract(MontantEncaisse, MtAdeduireAjouterREG);
                        D.Montant = MtAPayeAvecImpoAjouterREG;
                        mtTicket = MtAPayeAvecImpoAjouterREG;
                        HP.AvecAmpoAjouterREG = true;
                        MontantEncaisse = MtAPayeAvecImpoAjouterREG;
                        mvtCaisse.MontantSens = MtAPayeAvecImpoAjouterREG * -1;

                        if (CaisseDb != null)
                        {
                            CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MtAPayeAvecImpoAjouterREG);

                        }
                        Retenue Retenu = new Retenue();
                        Retenu.MontantReglement = MontantEncaisse;
                        Retenu.MontantRetenue = MtAdeduireAjouterREG;
                        Retenu.Commentaire = "Règlement Achat(s)" + TxtCodeAchat.Text;
                        db.retenus.Add(Retenu);
                        db.SaveChanges();
                        Retenu.Numero = "RTN" + (Retenu.Id).ToString("D8");
                        db.SaveChanges();
                    }
                   
                }
                else
                {
                    D.Nature = NatureMouvement.RéglementAchats;
                    HP.AvecAmpoAjouterREG = false;
                    D.Montant = MontantEncaisse;
                    mvtCaisse.MontantSens = MontantEncaisse * -1;
                    mtTicket = MontantEncaisse;
                    if (CaisseDb != null)
                    {
                        CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, MontantEncaisse);

                    }

                }



                List<string> numeroachats = db.Achats
     .Where(x => TxtCodeAchat.Text.Contains(x.Numero))
     .OrderBy(x => x.Date)
     .Select(x => x.Numero) // Select only the Numero property
     .ToList();

                foreach (var code in numeroachats)
                {

                    var Achatdb = db.Achats
        .Where(x => x.Numero.Equals(code.Trim())) // Match the Numero with the current code
        .OrderBy(x => x.Date)
        .FirstOrDefault();
                    var ResteaPayer = Achatdb.ResteApayer;
                    if (Achatdb != null)
                    {
                        if (MontantEncaisse >= ResteaPayer)
                        {
                            Achatdb.EtatAchat = EtatAchat.Reglee;
                            Achatdb.MontantRegle = Achatdb.MontantReglement;
                            Achatdb.MontantReglement = Achatdb.MontantReglement;



                            MontantEncaisse -= ResteaPayer;

                            HistoriquePaiementAchats HPAchat = new HistoriquePaiementAchats();
                            {
                                HPAchat.Founisseur = Achatdb.Founisseur;
                                HPAchat.NumAchat = Achatdb.Numero;
                                HPAchat.MontantReglement = Achatdb.MontantReglement;
                                HPAchat.MontantRegle = ResteaPayer;
                                HPAchat.ResteApayer = 0;
                                HPAchat.Commentaire = "Règlement Caisse";
                                HPAchat.TypeAchat = Achatdb.TypeAchat;

                            };
                            db.HistoriquePaiementAchats.Add(HPAchat);

                        }
                        else if (MontantEncaisse != 0 && MontantEncaisse < ResteaPayer)
                        {
                            Achatdb.EtatAchat = EtatAchat.PartiellementReglee;
                            Achatdb.MontantRegle += MontantEncaisse;
                            Achatdb.MontantReglement = Achatdb.MontantReglement;
                         

                            var Reset = decimal.Subtract(Achatdb.MontantReglement, Achatdb.MontantRegle);
                            // Create history entry
                            HistoriquePaiementAchats HPAchat = new HistoriquePaiementAchats
                            {
                                Founisseur = Achatdb.Founisseur,
                                NumAchat = Achatdb.Numero,
                                MontantReglement = Achatdb.MontantReglement,
                                MontantRegle = MontantEncaisse,
                                ResteApayer = Reset,
                                Commentaire = "Règlement Caisse",
                                TypeAchat = Achatdb.TypeAchat
                            };
                            db.HistoriquePaiementAchats.Add(HPAchat);


                        }

                        db.SaveChanges(); // Save changes for each purchase
                    }


                }

                // Depense 


                D.CodeTiers = Achat.Founisseur.Numero;
                D.Agriculteur = Achat.Founisseur;

                D.ModePaiement = "Espèce";
                D.Tiers = Achat.Founisseur.FullName;
                D.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;
                db.Depenses.Add(D);
                db.SaveChanges();
                int lastDep = db.Depenses.ToList().Count() + 1;
                D.Numero = "D" + (lastDep).ToString("D8");
                db.SaveChanges();

                // mvmCaisse


                mvtCaisse.Sens = Sens.Depense;
                mvtCaisse.Date = DateTime.Now;
                mvtCaisse.Agriculteur = Achat.Founisseur;
                mvtCaisse.CodeTiers = Achat.Founisseur.Numero;
                mvtCaisse.Source = "Agriculteur: " + Achat.Founisseur.FullName;


                mvtCaisse.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;

                int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                mvtCaisse.Achat = null;
                mvtCaisse.Montant = CaisseDb.MontantTotal;
                db.MouvementsCaisse.Add(mvtCaisse);
                db.SaveChanges();
            }


            if (gridView1.RowCount != 0 && MontantEncaisse >= 3000)
            { // Depense 
      
                int row = 0;
                bool isValid = true; // Pour vérifier la validité des lignes

                // Initialiser la liste des passagers
                while (gridView1.IsValidRowHandle(row))
                {
                    var data = gridView1.GetRow(row) as PersonneListeAchat;

                    // Vérifiez les champs requis
                    var cin = gridView1.GetRowCellValue(row, "cin") as string;
                    var fullName = gridView1.GetRowCellValue(row, "FullName") as string;
                    var montantReglement = gridView1.GetRowCellValue(row, "MontantReglement") as decimal?;

                    // Vérifiez si tous les champs requis sont remplis
                    if (string.IsNullOrEmpty(cin) || (!string.IsNullOrEmpty(cin) && cin.Length!=8) || string.IsNullOrEmpty(fullName) ||
                        !montantReglement.HasValue || montantReglement.Value <= 0)
                    {
                        XtraMessageBox.Show($"La ligne {row + 1} n'est pas valide. Vérifiez les champs CIN, Nom complet, et Montant de règlement.",
                            "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false; // Marquer comme invalide
                        break; // Sortir de la boucle si une ligne n'est pas valide
                    }

                    // Ajouter à la liste seulement si le montant de règlement est valide (non nul et non vide)
                    if (data != null && montantReglement.HasValue && montantReglement.Value > 0)
                    {
                        ListePassagers.Add(data);
                        ListePersonneTicket.Add(data);
                    }

                    row++;
                }

                decimal totalGrid = ListePassagers.Sum(x => x.MontantReglement);
                if (totalGrid != MontantEncaisse)
                {
                    XtraMessageBox.Show("Merci de vérifier les montants ajoutés!", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }

                for (int j = ListePassagers.Count - 1; j >= 0; j--)
                {
                    Depense D = new Depense();


                    D.Nature = NatureMouvement.Personne;
                    D.CodeTiers = Achat.Founisseur.Numero;
                    D.Agriculteur = null;
                    D.CodeTiers = ListePassagers[j].cin;
                    D.Montant = ListePassagers[j].MontantReglement;
                    D.DateCreation = DateTime.Now;
                    D.ModePaiement = "Espèce";
                    D.Tiers = ListePassagers[j].FullName;
                    D.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;
                    db.Depenses.Add(D);
                    db.SaveChanges();
                    int lastDep = db.Depenses.ToList().Count() + 1;
                    D.Numero = "D" + (lastDep).ToString("D8");
                    db.SaveChanges();

                    // mvmCaisse
                    MouvementCaisse mvtCaisse = new MouvementCaisse();
                    mvtCaisse.MontantSens = ListePassagers[j].MontantReglement * -1;
                    mvtCaisse.Sens = Sens.Depense;
                    mvtCaisse.Date = DateTime.Now;
                    mvtCaisse.Agriculteur = null;
                    mvtCaisse.CodeTiers = ListePassagers[j].cin;
                    mvtCaisse.Source = ListePassagers[j].FullName;

                    Caisse CaisseDb = db.Caisse.Find(1);
                    if (CaisseDb != null)
                    {
                        CaisseDb.MontantTotal = decimal.Subtract(CaisseDb.MontantTotal, ListePassagers[j].MontantReglement);

                    }
                    mvtCaisse.Commentaire = "Règlement Achat N° " + TxtCodeAchat.Text;

                    int lastMouvement = db.MouvementsCaisse.ToList().Count() + 1;
                    mvtCaisse.Numero = "D" + (lastMouvement).ToString("D8");
                    mvtCaisse.Achat = Achat;
                    mvtCaisse.Montant = CaisseDb.MontantTotal;
                    db.MouvementsCaisse.Add(mvtCaisse);
                    db.SaveChanges();
                }
              

            

            
                decimal MontantRegleFinal = 0m;
                MontantRegleFinal = MontantEncaisse;
                var MtAdeduireAjouterREG =0;
                var MtAPayeAvecImpoAjouterREG = 0;
                decimal initialMontantEncaisse = MontantEncaisse; // Save the initial value
                                                                  //mtTicket = ;


                List<string> numeroachats = db.Achats
            .Where(x => TxtCodeAchat.Text.Contains(x.Numero))
            .OrderByDescending(x => x.Date)
            .Select(x => x.Numero) // Select only the Numero property
            .ToList();

                for (int j = ListePassagers.Count - 1; j >= 0; j--)
                {
                    for (int i = numeroachats.Count - 1; i >= 0; i--)
                    {
                        var code = numeroachats[i];
                        var Achatdb = db.Achats
                            .Where(x => x.Numero.Equals(code.Trim())) // Match the Numero with the current code
                            .OrderBy(x => x.Date)
                            .FirstOrDefault();

                        if (Achatdb != null)
                        {
                            if (ListePassagers[j].MontantReglement == Achatdb.ResteApayer)
                            {

                                MontantEncaisse -= ListePassagers[j].MontantReglement;

                                Achatdb.EtatAchat = EtatAchat.Reglee;
                                Achatdb.MontantRegle = Achatdb.MontantReglement;

                                HistoriquePaiementAchats HPAchat = new HistoriquePaiementAchats
                                {
                                    Founisseur = Achatdb.Founisseur,
                                    NumAchat = Achatdb.Numero,
                                    MontantReglement = Achatdb.MontantReglement,
                                    MontantRegle = ListePassagers[j].MontantReglement,
                                    ResteApayer = 0,
                                    Commentaire = "Règlement Caisse",
                                    TypeAchat = Achatdb.TypeAchat,


                                };


                                HPAchat.PersonneListeAchat = new PersonneListeAchat
                                {
                                    FullName = ListePassagers[j].FullName,
                                    cin = ListePassagers[j].cin,
                                    MontantReglement = ListePassagers[j].MontantReglement,
                                    Numero = Achatdb.Numero
                                };
                                db.HistoriquePaiementAchats.Add(HPAchat);
                                db.SaveChanges();
                                numeroachats.RemoveAt(i); // Supprime l'élément à l'index i
                                ListePassagers.RemoveAt(j);

                               

                                break;
                            }

                            else if (ListePassagers[j].MontantReglement < Achatdb.ResteApayer)
                            {

                                MontantEncaisse -= ListePassagers[j].MontantReglement;


                                Achatdb.EtatAchat = EtatAchat.PartiellementReglee;
                                Achatdb.MontantRegle += ListePassagers[j].MontantReglement;
                                db.SaveChanges();
                                HistoriquePaiementAchats HPAchat = new HistoriquePaiementAchats();

                                HPAchat.Founisseur = Achatdb.Founisseur;
                                HPAchat.NumAchat = Achatdb.Numero;
                                HPAchat.MontantReglement = Achatdb.MontantReglement;
                                HPAchat.MontantRegle = ListePassagers[j].MontantReglement;
                                HPAchat.ResteApayer = decimal.Subtract(Achatdb.MontantReglement, Achatdb.MontantRegle);
                                HPAchat.Commentaire = "Règlement Caisse";
                                HPAchat.TypeAchat = Achatdb.TypeAchat;
                                HPAchat.PersonneListeAchat = new PersonneListeAchat
                                {
                                    FullName = ListePassagers[j].FullName,
                                    cin = ListePassagers[j].cin,
                                    MontantReglement = ListePassagers[j].MontantReglement,
                                    Numero = Achatdb.Numero
                                };
                                db.HistoriquePaiementAchats.Add(HPAchat);
                                db.SaveChanges();
                                ListePassagers.RemoveAt(j);
                                break;
                            }
                            else if (ListePassagers[j].MontantReglement > Achatdb.ResteApayer)
                            {


                                MontantEncaisse -= Achatdb.ResteApayer;

                                decimal reste = Achatdb.ResteApayer;//200;
                                Achatdb.EtatAchat = EtatAchat.Reglee;

                                Achatdb.MontantRegle += Achatdb.ResteApayer;
                                db.SaveChanges();
                                HistoriquePaiementAchats HPAchat = new HistoriquePaiementAchats();

                                HPAchat.Founisseur = Achatdb.Founisseur;
                                HPAchat.NumAchat = Achatdb.Numero;
                                HPAchat.MontantReglement = Achatdb.MontantReglement;
                                HPAchat.MontantRegle = reste;
                                HPAchat.ResteApayer = 0;
                                HPAchat.Commentaire = "Règlement Caisse";
                                HPAchat.TypeAchat = Achatdb.TypeAchat;
                                HPAchat.PersonneListeAchat = new PersonneListeAchat
                                {
                                    FullName = ListePassagers[j].FullName,
                                    cin = ListePassagers[j].cin,
                                    MontantReglement = reste,
                                    Numero = Achatdb.Numero
                                };
                                db.HistoriquePaiementAchats.Add(HPAchat);
                                    db.SaveChanges();
                                numeroachats.RemoveAt(i);

                                ListePassagers[j].MontantReglement -= reste;

                            }

                            db.SaveChanges();


                        }
                    }




                }


            }



            if (Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmListeDepensesAgriculteurs>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => (x.Nature == NatureMouvement.AchatOlive || x.Nature == NatureMouvement.AvanceAgriculteur || x.Nature == NatureMouvement.AchatHuile || x.Nature == NatureMouvement.ReglementImpo || x.Nature == NatureMouvement.RéglementAchats) && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();

            if (Application.OpenForms.OfType<FrmMouvementCaisse>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmMouvementCaisse>().First().mouvementCaisseBindingSource.DataSource = db.MouvementsCaisse.ToList();

                if (db.MouvementsCaisse.Count() > 0)
                {

                    List<MouvementCaisse> ListeMvtCaisse = db.MouvementsCaisse.ToList();

                    MouvementCaisse mvt = ListeMvtCaisse.Last();

                    Application.OpenForms.OfType<FrmMouvementCaisse>().First().TxtSoldeCaisse.Text = (Math.Truncate(mvt.Montant * 1000m) / 1000m).ToString();

                }


                TxtMontantEncaisse.Text = string.Empty;


            }
            if (Application.OpenForms.OfType<FrmListeAchats>().FirstOrDefault() != null)
            {
                db = new Model.ApplicationContext();
                Application.OpenForms.OfType<FrmListeAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();
            }

            if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                Application.OpenForms.OfType<FrmAchats>().First().achatBindingSource.DataSource = db.Achats.Where(x => x.TypeAchat != TypeAchat.Avance).OrderByDescending(x => x.Date).ToList();


            if (db.Agriculteurs.Count() > 0)
            {

                List<Agriculteur> ListAgriculteurs = db.Agriculteurs.ToList();
                foreach (var l in ListAgriculteurs)
                {
                    List<Achat> ListeAchats = db.Achats.Where(x => x.Founisseur.Id == l.Id && (x.TypeAchat != Model.Enumuration.TypeAchat.Avance && x.TypeAchat != Model.Enumuration.TypeAchat.Service)).ToList();
                    l.TotalAchats = ListeAchats.Sum(x => x.MontantReglement);
                    List<Achat> ListeAchatsAvance = db.Achats.Where(x => x.Founisseur.Id == l.Id && x.TypeAchat == Model.Enumuration.TypeAchat.Avance).ToList();
                    decimal SoldePaiementAchatsParCaisse = db.HistoriquePaiementAchats.Where(x => x.Founisseur.Id == l.Id && x.Commentaire.Equals("Règlement Caisse") && x.TypeAchat != TypeAchat.Service).ToList().Sum(x => x.MontantRegle);
                    l.TotalAvances = decimal.Add(ListeAchatsAvance.Sum(x => x.MontantRegle), SoldePaiementAchatsParCaisse);
                    decimal TotalDeduit = ListeAchats.Sum(x => x.MtAdeduire);
                    decimal SoldeAgriculteur = decimal.Add(decimal.Subtract(decimal.Subtract(l.TotalAvances, l.TotalAchats), l.Solde), TotalDeduit);
                    l.SoldeAgriculteur = SoldeAgriculteur == 0 ? l.Solde : SoldeAgriculteur;
                }
                //waiting Form
                if (Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmFournisseur>().FirstOrDefault().fournisseurBindingSource.DataSource = ListAgriculteurs.Select(x => new { x.Id, x.Numero, x.Nom, x.Prenom, x.Tel, x.TotalAchats, x.TotalAvances, x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmAchats>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAchats>().FirstOrDefault().fournisseurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmEtatAgriculteur>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmEtatAgriculteur>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmAnnulationAvance>().FirstOrDefault().agriculteurBindingSource.DataSource = ListAgriculteurs.AsEnumerable().Select(x => new { x.Id, x.Numero, x.FullName, x.Tel, TotalAchats = Math.Truncate(x.TotalAchats * 1000m) / 1000m, TotalAvances = Math.Truncate(x.TotalAvances * 1000m) / 1000m, x.SoldeAgriculteurAvecSens }).ToList();

                //waiting Form
                if (Application.OpenForms.OfType<FrmRetenu>().FirstOrDefault() != null)
                    Application.OpenForms.OfType<FrmRetenu>().FirstOrDefault().retenueBindingSource.DataSource =db.retenus.ToList();

            }


            XtraMessageBox.Show("Règlement Ajouté avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (ListePersonneTicket.Count() > 0)
            {

                foreach (var item in ListePersonneTicket)
                {

                    XrAvancePersonne xrAvancePersonne = new XrAvancePersonne();


                    xrAvancePersonne.Parameters["RsSte"].Value = societe.RaisonSocial;

                    xrAvancePersonne.Parameters["NumAvn"].Value = TxtCodeAchat.Text;



                    List<PersonneListeAchat> personnes = new List<PersonneListeAchat>();

                    personnes.Add(item);

                    xrAvancePersonne.DataSource = personnes;
                    using (ReportPrintTool printTool = new ReportPrintTool(xrAvancePersonne))
                    {
                        printTool.ShowPreviewDialog();

                    }

                }

            }

            if (Application.OpenForms.OfType<FrmListeDepencesPersonne>().FirstOrDefault() != null)
            {
                Application.OpenForms.OfType<FrmListeDepencesPersonne>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Nature == NatureMouvement.Personne && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
            }


            this.Close();
            TicketavecAchat Ticket = new TicketavecAchat();


            if (ListePersonneTicket.Count() == 0)
            {
                string RsSte = societe.RaisonSocial;

                Ticket.Parameters["RsSte"].Value = RsSte;

                Ticket.Parameters["RsSte"].Visible = false;

                Ticket.Parameters["MtPaye"].Value = mtTicket;

                Ticket.Parameters["MtPaye"].Visible = false;
                Ticket.Parameters["fullname"].Value = Achat.Founisseur.FullName;
           
                List<Achat> AchatSource = new List<Achat>();
                Achat AchatRapport = new Achat();
                AchatRapport.Numero = TxtCodeAchat.Text;
                AchatSource.Add(AchatRapport);

                Ticket.DataSource = AchatSource;
                using (ReportPrintTool printTool = new ReportPrintTool(Ticket))
                {
                    printTool.ShowPreviewDialog();

                }

            }

        }


        private void FrmAjouterReglementAchat_Load(object sender, EventArgs e)
        {
            societe = db.Societe.FirstOrDefault();
        }

        private bool isCellValueChanging = false;

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (isCellValueChanging) return;

            if (e.Column.FieldName == "cin")
            {
                var newValue = e.Value as string;

                if (!string.IsNullOrEmpty(newValue))
                {
                    if (newValue.Length != 8 || !newValue.All(char.IsDigit))
                    {
                        XtraMessageBox.Show("Le CIN doit contenir exactement 8 chiffres.", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        // Effacer le champ de saisie
                        isCellValueChanging = true; // Désactiver temporairement l'événement
                      
                        isCellValueChanging = false; // Réactiver l'événement

                        return; // Sortir
                    }

                    // Vérifiez si le CIN existe déjà
                    for (int row = 0; row < gridView1.DataRowCount; row++)
                    {
                        var existingCIN = gridView1.GetRowCellValue(row, "cin") as string;
                        if (existingCIN == newValue && row != e.RowHandle) // Vérifiez que ce n'est pas la même ligne
                        {
                            XtraMessageBox.Show("Ce CIN existe déjà.", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            gridView1.SetRowCellValue(e.RowHandle, e.Column, null);
                            return;
                        }
                    }
                }
            }

            if (e.Column.FieldName == "MontantReglement")
            {
                var newValue = e.Value as decimal?;

                if (newValue.HasValue)
                {
                    // Vérifie si la valeur est négative ou supérieure ou égale à 3000
                    if (newValue.Value < 0 || newValue.Value >= 3000)
                    {
                        isCellValueChanging = true; // Désactiver temporairement l'événement
                        XtraMessageBox.Show("Le montant de règlement doit être positif et inférieur à 3000!", "Configuration de l'application", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        gridView1.SetRowCellValue(e.RowHandle, e.Column, 0); // Réinitialiser à 0
                        isCellValueChanging = false; // Réactiver l'événement
                        return;
                    }
                }
            }

          
        }

      


        private void BtnSupprimer_Click_1(object sender, EventArgs e)
        {
            int visibleIndex = gridView1.GetVisibleIndex(gridView1.FocusedRowHandle);
            gridView1.DeleteRow(visibleIndex);

        }



    }
}