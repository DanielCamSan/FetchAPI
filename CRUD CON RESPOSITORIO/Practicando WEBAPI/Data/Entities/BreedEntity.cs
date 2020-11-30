using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Data.Entities
{
    public class BreedEntity
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        public int? TypesofUnity { get; set; }

        public List<string> Heroes { get; set; }
        public string DefaultColor { get; set; }
        public string Reign { get; set; }

        public string ArmyName { get; set; }
        public string Difficulty { get; set; }
        public decimal? Rating { get; set; }
    }
}
