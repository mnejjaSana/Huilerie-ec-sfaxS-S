﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Gestion_de_Stock.Repport
{
    public partial class RapportEtatAgriculteur : DevExpress.XtraReports.UI.XtraReport
    {
        public RapportEtatAgriculteur()
        {
            InitializeComponent();
        }

        private void xrPictureBox1_AfterPrint(object sender, EventArgs e)
        {

        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var dbPath0 = executingFolder + "\\Image\\LogoSte.png";
            xrPictureBox1.ImageUrl = dbPath0;

        }
    }
}
