using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmExercice : DevExpress.XtraEditors.XtraForm
    {
        private static FrmExercice _FrmExercice;

        public static FrmExercice InstanceFrmExercice
        {
            get
            {
                if (_FrmExercice == null)
                {
                    _FrmExercice = new FrmExercice();
                }

                return _FrmExercice;
            }
        }
       
        private static string originalConnectionString { get { return ConfigurationManager.ConnectionStrings["Context"].ConnectionString; } }


        public FrmExercice()
        {
            InitializeComponent();
        }

        private void FrmExercice_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmExercice = null;
        }


        private List<string> ListDBFromServer()
        {

            List<string> listDBFromServer = new List<string>();


            using (SqlConnection con = new SqlConnection(originalConnectionString))
            {
                con.Open();

               
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases  WHERE database_id > 4;", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listDBFromServer.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return listDBFromServer;
        } 


        private void FrmExercice_Load(object sender, EventArgs e)
        {
            List<string> ListDb = ListDBFromServer();

            foreach(var item in ListDb)
            {
                comboBoxExercice.Properties.Items.Add(item);
            }
           
         
        }
        private void BtnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxExercice.Text))
            {
                XtraMessageBox.Show("L'exercice est obligatoire", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxExercice.ErrorText = "L'exercice est obligatoire";
                return;
            }

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(originalConnectionString);
                
                builder.InitialCatalog = comboBoxExercice.Text;

                string updatedConnectionString = builder.ToString();

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                ConnectionStringsSection connectionStrings = config.ConnectionStrings;

                if (connectionStrings != null && connectionStrings.ConnectionStrings["Context"] != null)
                {
                    // Update the connection string.
                    connectionStrings.ConnectionStrings["Context"].ConnectionString = updatedConnectionString;

                    // Save the configuration file.
                    config.Save(ConfigurationSaveMode.Modified);

                    // Refresh the ConfigurationManager to reflect the changes.
                    ConfigurationManager.RefreshSection("connectionStrings");

                   
                    string updatedValue = connectionStrings.ConnectionStrings["Context"].ConnectionString;
                    Console.WriteLine("Updated Connection String: " + updatedValue);
                }

                comboBoxExercice.Text = string.Empty;
                Application.Exit();
              
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erreur lors de la mise à jour de la chaîne de connexion: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

     
    }
}