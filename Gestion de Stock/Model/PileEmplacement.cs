﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class PileEmplacement
    {
        public virtual ICollection <PileRapport> ListePilesRapport { get; set; }
        public virtual ICollection<Emplacement> ListeEmplacement { get; set; }
    }
}
