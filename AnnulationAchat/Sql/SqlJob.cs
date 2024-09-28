using AnnulationAchatHuile.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace AnnulationAchatHuile.Sql
{
   public class SqlJob
    {
        private static String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Context"].ConnectionString;
            }
        }

        public static Achat GetAchat(string NumAchat)
        {
            var parameters = new { NumAchat = NumAchat };
            using (var cn = new SqlConnection(ConnectionString))
            {
                return cn.Query<Achat>(SqlScript.GetAchat, parameters).FirstOrDefault();
            }

        }

        public static Agriculteur GetFounisseur(int IdFournisseur)
        {
            var parameters = new { IdFournisseur = IdFournisseur };
            using (var cn = new SqlConnection(ConnectionString))
            {
                return cn.Query<Agriculteur>(SqlScript.GetFounisseur, parameters).FirstOrDefault();
            }

        }

        public static Pile GetPile(int IdPile)
        {
            var parameters = new { IdPile = IdPile };
            using (var cn = new SqlConnection(ConnectionString))
            {
                return cn.Query<Pile>(SqlScript.GetPile, parameters).FirstOrDefault();
            }

        }

        public static void UpdateMouvementStock(int IDAchat)
        {
            var parameters = new { IDAchat = IDAchat };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.UpdateMouvementStock, parameters);
            }

        }

        public static void UpdateMouvementCaisse(int IDAchat)
        {
            var parameters = new { IDAchat = IDAchat };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.UpdateMouvementCaisse, parameters);
            }

        }

        public static void DeleteAvance(string NumAvance)
        {
            var parameters = new { NumAvance = NumAvance };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.DeleteAvance, parameters);
            }

        }

        public static void DeleteAchat(int IdAchat)
        {
            var parameters = new { IdAchat = IdAchat };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.DeleteAchat, parameters);
            }

        }

        public static void DeleteDepense(string commantaire)
        {
            var parameters = new { commantaire = commantaire };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.DeleteDepense, parameters);
            }

        }

        public static int GetMaxIdAlimentation()
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                return cn.Query<int>(SqlScript.GetMaxIdAlimentation).FirstOrDefault();
            }

        }

        public static int GetMaxIdMouvementStock()
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                return cn.Query<int>(SqlScript.GetMaxIdMouvementStock).FirstOrDefault();
            }

        }
        
       
        public static int GetMaxIdDepense()
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                return cn.Query<int>(SqlScript.GetMaxIdDepense).FirstOrDefault();
            }

        }

        public static decimal GetSoldeCaisse()
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                return cn.Query<decimal>(SqlScript.GetSoldeCaisse).FirstOrDefault();
            }

        }

        public static void UpdatePMPPile(int IdPile)
        {
            var parameters = new { IdPile = IdPile };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.UpdatePMPPile, parameters);
            }

        }

        public static Coffrecheque GetCoffreCheque(decimal Montant, string NumCheque, string Bank, DateTime ?DateEcheance)
        {
            var parameters = new { Montant= Montant, NumCheque= NumCheque, Bank= Bank , DateEcheance = DateEcheance };

            using (var cn = new SqlConnection(ConnectionString))
            {
                return cn.Query<Coffrecheque>(SqlScript.GetCoffreCheque, parameters).FirstOrDefault();
            }

        }

        public static void DeleteDepenseById(int IdDep)
        {
            var parameters = new { IdDep = IdDep };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.DeleteDepenseById, parameters);
            }

        }

        public static void DeleteCoffreCheque(int IdCoffre)
        {
            var parameters = new { IdCoffre = IdCoffre };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.DeleteCoffreCheque, parameters);
            }

        }

        public static void DeleteHistoriqueAchat(string NumAchat)
        {
            var parameters = new { NumAchat = NumAchat };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.DeleteHistoriqueAchat, parameters);
            }

        }

        public static List<HistoriquePaiementAchats> GetListHistoriqueAchat(int IdAgr, string NumAchat)
        {
            var parameters = new { IdAgr = IdAgr, NumAchat = NumAchat };
            using (var cn = new SqlConnection(ConnectionString))
            {
                return cn.Query<HistoriquePaiementAchats>(SqlScript.GetListHistoriqueAchat, parameters).ToList();
            }

        }

        public static void DeleteDepenseAvance(string commantaire, int agrId, decimal Montant)
        {
            var parameters = new { commantaire = commantaire, agrId = agrId, Montant = Montant };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.DeleteDepenseAvance, parameters);
            }

        }

        public static Achat GetAvance(int IdFournisseur, decimal MontantRegle)
        {
            var parameters = new { IdFournisseur = IdFournisseur, MontantRegle = MontantRegle };

            using (var cn = new SqlConnection(ConnectionString))
            {

                return cn.Query<Achat>(SqlScript.GetAvance, parameters).FirstOrDefault();
            }

        }
    }
}
