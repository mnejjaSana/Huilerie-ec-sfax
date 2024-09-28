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
using System.IO;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace Gestion_de_Stock.Forms
{
    public partial class FrmLicence : DevExpress.XtraEditors.XtraForm
    {
        private static FrmLicence _FrmLicence;

        public static FrmLicence InstanceFrmLicence
        {
            get
            {
                if (_FrmLicence == null)
                    _FrmLicence = new FrmLicence();
                return _FrmLicence;
            }
        }

        public FrmLicence()
        {
            InitializeComponent();
        }

        private void FrmLicence_Load(object sender, EventArgs e)
        {
            string macAddress = "";
            textcodeLicence.Text = "HuilerieEC, version : V1";
            LabelAdresseTunis.Text = "Golden Estates Towers, 9éme étage App.A9.8 Centre Urbain Nord, 1080, Tunis-Tunisie";
            LabelAdresseSfax.Text = "Route Gabes Km3, Immeuble SOTEME 1er étage, 3052, Sfax-Tunisie";
            LabelTel.Text = "+216 70 033 140";
            LabelEmail.Text = "contact@econsult.com.tn";
            LabelSite.Text = "www.econsult.com.tn";

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface inter in interfaces)
            {
                if (inter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    PhysicalAddress adressePhysique = inter.GetPhysicalAddress();
                    byte[] octets = adressePhysique.GetAddressBytes();

                    for (int i = 0; i < octets.Length; i++)
                    {
                        macAddress += octets[i].ToString("X2");
                        if (i < octets.Length - 1)
                        {
                            macAddress += "";
                        }
                    }
                    Console.WriteLine("Adresse MAC de cet ordinateur: " + macAddress);
                    break;
                }
            }
            textcodeLicence.Text = macAddress;



        }

        private void FrmLicence_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmLicence = null;
            this.Hide();
            Application.Exit();
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();

        }

        public void FormshowNotParent(Form frm)
        {

            frm.Show();
            frm.Activate();
        }

        private void BtnLicence_Click(object sender, EventArgs e)
        {
            try
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "Fichiers texte (*.EC)|*.EC",
                    Title = "Open txt File",
                    InitialDirectory = @"C:\"
                })


                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        String exportFilePath = openFileDialog.FileName;
                        String fileName = openFileDialog.SafeFileName;
                        string rename = "FichierLicence.EC";
                        String macAddress = textcodeLicence.Text;
                        File.Copy(exportFilePath,
                        Path.Combine(Directory.GetCurrentDirectory(), rename), true);


                        // Lire les données du fichier chiffré
                        string line = File.ReadAllText(exportFilePath);

                        // Diviser la ligne en quatre parties : la clé, le vecteur d'initialisation, les données chiffrées et la date
                        string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 3 || parts.Any(part => part.Length == 0))
                        {
                            XtraMessageBox.Show("Fichier incompatible", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            return;
                        }
                        // Décoder la clé, le vecteur d'initialisation et les données chiffrées depuis Base64
                        byte[] key = Convert.FromBase64String(parts[0]);
                        byte[] iv = Convert.FromBase64String(parts[1]);
                        byte[] encryptedBytes = Convert.FromBase64String(parts[2]);

                        // Déchiffrer les données
                        byte[] decryptedBytes;
                        using (Aes aes = Aes.Create())
                        {
                            aes.Key = key;
                            aes.IV = iv;

                            using (MemoryStream ms = new MemoryStream(encryptedBytes))
                            {
                                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                                {
                                    using (MemoryStream decryptedMs = new MemoryStream())
                                    {
                                        cs.CopyTo(decryptedMs);
                                        decryptedBytes = decryptedMs.ToArray();
                                    }
                                }
                            }

                        }



                        // Lire la chaîne de caractères à partir des octets déchiffrés
                        string decryptedString = Encoding.UTF8.GetString(decryptedBytes);

                        int spaceIndex = decryptedString.IndexOf(' ');
                        string dateStr = decryptedString.Substring(spaceIndex + 1);

                        // licence
                        DateTime datedujour = DateTime.Now;
                        DateTime dateLicence = DateTime.Parse(dateStr);

                        TimeSpan ts = dateLicence - datedujour;



                        if (decryptedString != null && ts.TotalDays > 0)
                        {



                            // Vérification si l'adresse MAC est présente dans la ligne
                            if (decryptedString.Contains(macAddress))
                            {
                                // Faire quelque chose si l'adresse MAC est trouvée dans le fichier
                                Console.WriteLine("L'adresse MAC a été trouvée dans le fichier,!");
                                this.Hide();
                                FormshowNotParent(FrmLogin.InstancFrmLogin);


                            }
                            else
                            {
                                this.Hide();
                                XtraMessageBox.Show("Fichier incompatible", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Exit();
                                return;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Fichier incompatible ou la date invalide", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return;
                        }


                    }
            }
            catch (Exception ex)
            {
                // handle the exception here
                XtraMessageBox.Show("Fichier incompatible", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
    }
}