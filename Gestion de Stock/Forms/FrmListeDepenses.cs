﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeDepenses : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmListeDepenses _FrmListeDepenses;
        public static FrmListeDepenses InstanceFrmListeDepenses
        {
            get
            {
                if (_FrmListeDepenses == null)
                    _FrmListeDepenses = new FrmListeDepenses();
                return _FrmListeDepenses;
            }
        }
        public FrmListeDepenses()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmListeDepenses_Load(object sender, EventArgs e)
        {

            depenseBindingSource.DataSource = db.Depenses.Where(x => x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.AchatOlive && x.Nature != NatureMouvement.AvanceAgriculteur && x.Nature != NatureMouvement.AchatHuile && x.Nature != NatureMouvement.ReglementImpo && x.Nature != NatureMouvement.RéglementAchats && x.ModePaiement.Equals("Espèce")).OrderByDescending(x => x.DateCreation).ToList();

        }

        private void FrmListeDepenses_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeDepenses = null;
        }

        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            //SplashScreenManager.ShowForm(this, typeof(Forms.FrmWaitForm), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter ....");
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(10);
            //}
            //SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }


        private void dateDebut_EditValueChanged(object sender, EventArgs e)
        {

            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            //if (DateMaxJour.CompareTo(DateMin)<0)
            //{
            //    XtraMessageBox.Show("Date Fin est Invalid ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                depenseBindingSource.DataSource = db.Depenses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.AchatOlive && x.Nature != NatureMouvement.AvanceAgriculteur && x.Nature != NatureMouvement.AchatHuile && x.ModePaiement.Equals("Espèce")).ToList();


            }
            else
            {
                depenseBindingSource.DataSource = db.Depenses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0 && x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.AchatOlive && x.Nature != NatureMouvement.AvanceAgriculteur && x.Nature != NatureMouvement.AchatHuile && x.ModePaiement.Equals("Espèce")).ToList();
            }


        }

        private void dateFin_EditValueChanged(object sender, EventArgs e)
        {
            DateTime DateMin = dateDebut.DateTime;
            DateTime DateMaxJour = dateFin.DateTime.Date.AddDays(1).AddSeconds(-1);

            if (DateMaxJour.CompareTo(DateMin) < 0)
            {
                XtraMessageBox.Show("Date Fin est Invalide ", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateMaxJour.ToString("dd/MM/yyyy").Equals("01/01/0001"))
            {
                depenseBindingSource.DataSource = db.Depenses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.AchatOlive && x.Nature != NatureMouvement.AvanceAgriculteur && x.Nature != NatureMouvement.AchatHuile && x.ModePaiement.Equals("Espèce")).ToList();
            }
            else
            {
                depenseBindingSource.DataSource = db.Depenses.Where(x => x.DateCreation.CompareTo(DateMin) >= 0 && x.DateCreation.CompareTo(DateMaxJour) <= 0 && x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.AchatOlive && x.Nature != NatureMouvement.AvanceAgriculteur && x.Nature != NatureMouvement.AchatHuile && x.ModePaiement.Equals("Espèce")).ToList();
            }

        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {

            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window.
            gridControl1.ShowPrintPreview();
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "Liste Depenses.xlsx";

            ////Customize export options
            //(gridControl1.MainView as GridView).OptionsPrint.PrintHeader = false;
            //XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
            //advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
            //advOptions.SheetName = "Exported from Data Grid";

            //gridControl1.ExportToXlsx(path, advOptions);
            //// Open the created XLSX file with the default application.
            //Process.Start(path);


            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            depenseBindingSource.DataSource = db.Depenses.Where(x => x.Nature != NatureMouvement.Prélèvement && x.Nature != NatureMouvement.AchatOlive && x.Nature != NatureMouvement.AvanceAgriculteur && x.Nature != NatureMouvement.AchatHuile && x.Nature != NatureMouvement.ReglementImpo && x.Nature != NatureMouvement.RéglementAchats && x.ModePaiement.Equals("Espèce")).OrderByDescending(x => x.DateCreation).ToList();

        }
    }
}