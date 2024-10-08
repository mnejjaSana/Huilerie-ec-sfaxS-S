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
using Gestion_de_Stock.Model.Enumuration;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmListeDepencesPersonne : DevExpress.XtraEditors.XtraForm
    {
        public Model.ApplicationContext db { get; set; }
        private static FrmListeDepencesPersonne _FrmListeDepencesPersonne;
        public static FrmListeDepencesPersonne InstanceFrmListeDepencesPersonne
        {
            get
            {
                if (_FrmListeDepencesPersonne == null)
                    _FrmListeDepencesPersonne = new FrmListeDepencesPersonne();
                return _FrmListeDepencesPersonne;
            }
        }
        public FrmListeDepencesPersonne()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
                    }

        private void FrmListeDepencesPersonne_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmListeDepencesPersonne = null;
        }

        private void FrmListeDepencesPersonne_Load(object sender, EventArgs e)
        {
            Application.OpenForms.OfType<FrmListeDepencesPersonne>().First().depenseBindingSource.DataSource = db.Depenses.Where(x => x.Nature == NatureMouvement.Personne && x.Montant > 0).OrderByDescending(x => x.DateCreation).ToList();
        }
    }
}