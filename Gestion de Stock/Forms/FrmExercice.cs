using DevExpress.XtraEditors;
using System;
using System.Configuration;
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

        private void FrmExercice_Load(object sender, EventArgs e)
        {
            comboBoxExercice.Properties.Items.Add("Huilerie2022");
            comboBoxExercice.Properties.Items.Add("Huilerie2023");
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxExercice.Text))
            {
                XtraMessageBox.Show("L'exercice est obligatoire", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxExercice.ErrorText = "L'exercice est obligatoire";
                return;
            }
            else
            {
                // Create a SqlConnectionStringBuilder object
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(originalConnectionString);

                // Get the current Initial Catalog (Database)
                string currentInitialCatalog = builder.InitialCatalog;


                // Set a new Initial Catalog (Database)
                string newInitialCatalog = comboBoxExercice.Text;
                builder.InitialCatalog = newInitialCatalog;

                // Updated connection string
                string updatedConnectionString = builder.ToString();

                // Open the configuration file.
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Locate the connection string in the configuration file.
                ConnectionStringsSection connectionStrings = config.ConnectionStrings;

                if (connectionStrings != null)
                {
                    // Check if the connection string with the given name exists.
                    if (connectionStrings.ConnectionStrings["Context"] != null)
                    {
                        // Update the connection string.
                        connectionStrings.ConnectionStrings["Context"].ConnectionString = updatedConnectionString;

                        // Save the configuration file.
                        config.Save(ConfigurationSaveMode.Modified);

                        // Refresh the ConfigurationManager to reflect the changes.
                        ConfigurationManager.RefreshSection("connectionStrings");
                    }

                }


                Application.Exit();
                comboBoxExercice.Text = string.Empty;
            }
        }
    }
}