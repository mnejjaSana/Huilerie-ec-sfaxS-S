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

namespace Gestion_de_Stock.Forms
{
    public partial class FrmRetenu : DevExpress.XtraEditors.XtraForm
    {
        public Gestion_de_Stock.Model.ApplicationContext db { get; set; }
        private static FrmRetenu _FrmRetenu;
        public static FrmRetenu InstanceFrmRetenu
        {
            get
            {
                if (_FrmRetenu == null)
                    _FrmRetenu = new FrmRetenu();
                return _FrmRetenu;
            }
        }
        public FrmRetenu()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void FrmRetenu_Load(object sender, EventArgs e)
        {
            List<Retenue> RetenueList = db.retenus.ToList();
            retenueBindingSource.DataSource = RetenueList;

        }

        private void FrmRetenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmRetenu = null;
        }
    }
}