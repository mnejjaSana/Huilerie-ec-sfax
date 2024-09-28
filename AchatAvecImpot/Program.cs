using AchatAvecImpot.Sql;
using AchatAvecImpot.Model;
using AchatAvecImpot.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot
{
    class Program
    {
        static void Main(string[] args)
        {
            string CodeAchat = "";

            while (true)
            {
                Console.WriteLine("Entrez votre Code Achat: ");

                CodeAchat = Console.ReadLine();

                // Add your validation condition here
                if (IsValidCodeAchat(CodeAchat))
                {
                    // Valid input, you can continue with your logic
                    Achat AchatDb = new Achat();

                    AchatDb = SqlJob.GetAchat(CodeAchat);

                    if (AchatDb != null)
                    {
                        if (AchatDb.EtatAchat == EtatAchat.NonReglee)
                        {
                            decimal unPourcent=0.01m;
                            decimal MtAdeduire = decimal.Multiply(AchatDb.MontantReglement, unPourcent);
                            decimal MtAPayeAvecImpo = decimal.Subtract(AchatDb.MontantReglement, MtAdeduire);
                            SqlJob.UpdateAchatNonRegle(MtAdeduire, MtAPayeAvecImpo, AchatDb.Numero);
                            Console.WriteLine("Traitement terminé avec succès");

                        }
                        else 
                        {
                           Console.WriteLine("Traitement non effectué");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Achat introuvable");


                    }


                }
                else
                {
                    // Invalid input, ask the user to re-enter
                    Console.WriteLine("Code Achat est invalide. Réessayer.");


                }
            }

            // Add a method to define your validation logic
            bool IsValidCodeAchat(string code)
            {
                return !string.IsNullOrEmpty(code) && code.Length == 11;
            }

        }
    }
}
