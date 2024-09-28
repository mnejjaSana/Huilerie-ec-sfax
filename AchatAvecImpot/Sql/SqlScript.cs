using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchatAvecImpot.Sql
{
    public class SqlScript
    {
        public static string GetAchat = @"select * FROM [dbo].[Achats] where Numero=@NumAchat";

        public static string UpdateAchatNonRegle = @"update Achats set MtAdeduire =@MtAdeduire, MtAPayeAvecImpo =@MtAPayeAvecImpo, AvecAmpo = 1  where Numero=@NumAchat";





    }
}
