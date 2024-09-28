using System;

using System.Data.SqlClient;
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
using Gestion_de_Stock.Forms;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace Gestion_de_Stock
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        FrmLicence FrmLicence = new FrmLicence();
        public Gestion_de_Stock.Model.ApplicationContext Db;
        MainRibbonForm MainRibbon = new MainRibbonForm();

        private static FrmLogin _FrmLogin;
  
        public static FrmLogin InstancFrmLogin
        {
            get
            {
                if (_FrmLogin == null)
                    _FrmLogin = new FrmLogin();
                return _FrmLogin;
            }
        }

        public FrmLogin()
        {
            InitializeComponent();

            Db = new Model.ApplicationContext();
            

            TxtLogin.EditValue = "Admin";
            TxtPassword.EditValue = "Admin";

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string macAddress = "";
            // LoginTextEdit.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            // t5arej beuuuuugue
            if (string.IsNullOrEmpty(TxtLogin.Text))
            {
                TxtLogin.ErrorText = "Login  est obligatoire";
                return;
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                TxtPassword.ErrorText = "Password  est obligatoire";
                return;
            }

            // ancienne licence

           // DateTime datedujour = DateTime.Now;
           // DateTime dateLicence = new DateTime(2023, 09, 30);// year month day
           //// DateTime dateLicence = new DateTime(2022, 11, 03);
           // TimeSpan ts = dateLicence - datedujour;

           // if (ts.TotalDays < 0)
           // {

           //     this.Hide();
           //     FrmLicence.Show();  
           //     return;

           // }
            var  Utilisateur = ProcessLogin(TxtLogin.Text, TxtPassword.Text);
            string pathExiste = Path.Combine(Directory.GetCurrentDirectory(), "FichierLicence.EC");
            if (Utilisateur != null)
            {
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
                try
                {


                    if (File.Exists(pathExiste) && new FileInfo(pathExiste).Length > 0)
                    {
                        // Lire les données du fichier chiffré
                        string line = File.ReadAllText(pathExiste);

                        // Diviser la ligne en quatre parties : la clé, le vecteur d'initialisation, les données chiffrées et la date
                        string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 3 || parts.Any(part => part.Length == 0))
                        {
                            XtraMessageBox.Show("Fichier incompatible", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FormshowNotParent(Forms.FrmLicence.InstanceFrmLicence);
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

                                LoginInfo.UserID = Utilisateur.Id;
                               
                                MainRibbon.Show();
                                BackupDatabase.GetBackupDatabase();
                                this.Hide();
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
                            this.Hide();
                            FormshowNotParent(Forms.FrmLicence.InstanceFrmLicence);

                            return;
                        }
                    }
                    else
                    {
                        this.Hide();
                        FormshowNotParent(Forms.FrmLicence.InstanceFrmLicence);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    // Afficher un message d'erreur générique en cas d'exception
                    XtraMessageBox.Show("Fichier incompatible", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    FormshowNotParent(Forms.FrmLicence.InstanceFrmLicence);
                    return;
                }
            }
                    
    }

    public void FormshowNotParent(Form frm)
        {
            frm.Show();
            frm.Activate();
        }
        private Utilisateur ProcessLogin(string Login, string password)
        {

            Utilisateur CurrentUser = Db.Utilisateurs.SingleOrDefault(a => a.Login.Equals(Login));
            if (CurrentUser != null)
            {
                if (CurrentUser.Password.Equals(password))
                {
                    return CurrentUser;
                }
                else
                {
                    TxtPassword.ErrorText = "Mot de passe invalide";
                    return null;
                }
            }
            else
            {
                TxtLogin.ErrorText = "Login  est  invalide";
                return null;
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                if (string.IsNullOrEmpty(TxtLogin.Text))
                {
                    TxtLogin.ErrorText = "Login  est obligatoire";
                    return;
                }
                if (string.IsNullOrEmpty(TxtPassword.Text))
                {
                    TxtPassword.ErrorText = "Password  est obligatoire";
                    return;
                }

                var Utilisateur = ProcessLogin(TxtLogin.Text, TxtPassword.Text);
                if (Utilisateur != null)
                {
                    MainRibbon.Show();
                    this.Hide();
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // initialiser l'allignement des icons des erreurs provider
            TxtLogin.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtPassword.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
        }
    }
}