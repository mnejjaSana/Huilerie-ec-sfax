using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model.Enumuration
{
    public enum NatureMouvement : int
    {
        Salarié = 1,
        Prélèvement = 2,
        Autre = 3,
        AchatOlive = 4,
        AvanceAgriculteur = 5,
        ClôtureCaisse = 6,
        ModificationService = 7,
        AchatHuile=8,
        ReglementImpo = 9,
        RéglementAchats=10,
    }
}
