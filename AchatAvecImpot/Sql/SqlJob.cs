using AchatAvecImpot.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Sql
{
    public class SqlJob
    {
        private static string ConnectionString
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

        public static void UpdateAchatNonRegle(decimal MtAdeduire, decimal MtAPayeAvecImpo, string NumAchat )
        {
            var parameters = new { MtAdeduire, MtAPayeAvecImpo, NumAchat };

            using (var cn = new SqlConnection(ConnectionString))
            {
                var Executer = cn.Query(SqlScript.UpdateAchatNonRegle, parameters);
            }

        }

    }
}
