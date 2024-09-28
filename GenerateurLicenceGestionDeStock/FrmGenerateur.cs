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
using System.Security.Cryptography;
using System.IO;

namespace GenerateurLicenceGestionDeStock
{
    public partial class FrmGenerateur : DevExpress.XtraEditors.XtraForm
    {
        public FrmGenerateur()
        {
            InitializeComponent();
        }

        private void FrmGenerateur_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime lastDayOfYear = new DateTime(currentDate.Year, 12, 31);
            DateTime expirationDateTime = new DateTime(lastDayOfYear.Year, lastDayOfYear.Month, lastDayOfYear.Day, 0, 0, 0);
            string expirationDate = expirationDateTime.ToString("dd/MM/yyyy");

            TxtdateEdit.Text = expirationDate;
        }

        private void BtnGenerer_Click(object sender, EventArgs e)
        {
            string macAddress = TxtCodeClient.Text + " " + TxtdateEdit.Text;
            string fileName = "Licence_" + TxtSociete.Text + ".EC";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            // Générer une clé aléatoire pour le chiffrement AES
            byte[] key = new byte[32];
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                key = aes.Key;
            }

            // Générer un vecteur d'initialisation aléatoire
            byte[] iv = new byte[16];
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                iv = aes.IV;
            }

            // Chiffrer la chaîne macAddress
            byte[] encryptedBytes;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(macAddress);
                        }
                        encryptedBytes = ms.ToArray();
                    }
                }
            }

            // Écrire les données chiffrées dans le fichier
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(Convert.ToBase64String(key) + "   " + Convert.ToBase64String(iv) + "   " + Convert.ToBase64String(encryptedBytes));
            }

            XtraMessageBox.Show("Fichier généré avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}