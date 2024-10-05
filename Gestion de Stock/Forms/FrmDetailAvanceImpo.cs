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
using Gestion_de_Stock.Model;
using DevExpress.XtraReports.UI;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmDetailAvanceImpo : DevExpress.XtraEditors.XtraForm
    {
        private Model.ApplicationContext db;
        private static FrmDetailAvanceImpo _FrmDetailAvanceImpo;
        public static FrmDetailAvanceImpo InstanceFrmDetailAvanceImpo
        {
            get
            {
                if (_FrmDetailAvanceImpo == null)
                    _FrmDetailAvanceImpo = new FrmDetailAvanceImpo();
                return _FrmDetailAvanceImpo;
            }
        }
        public FrmDetailAvanceImpo()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmDetailAvanceImpo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmDetailAvanceImpo = null;
        }

        private void BtnTicket_Click(object sender, EventArgs e)
        {
            Personne_Passager p = gridView1.GetFocusedRow() as Personne_Passager;

            db = new Model.ApplicationContext();


            Societe societe = db.Societe.FirstOrDefault();

            string RsSte = societe.RaisonSocial;


            if (p != null)
            {

                XrAvancePersonne xrAvancePersonne = new XrAvancePersonne();

                xrAvancePersonne.Parameters["RsSte"].Value = societe.RaisonSocial;

                xrAvancePersonne.Parameters["NumAvn"].Value = p.Numero;

                List<Personne_Passager> personnes = new List<Personne_Passager>();

                personnes.Add(p);

                xrAvancePersonne.DataSource = personnes;
                using (ReportPrintTool printTool = new ReportPrintTool(xrAvancePersonne))
                {
                    printTool.ShowPreviewDialog();

                }

            }
        }
    }
}
