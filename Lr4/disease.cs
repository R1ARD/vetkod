using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lr4
{
    public class disease
    {
        [Key] public int id { get; set; }

        public string dname { get; set; }
        public string dtype { get; set; }
        public string symptom { get; set; }

        [ForeignKey("MedecineEntity")] public int id_medecine { get; set; }
        public medecine MedecineEntity { get; set; }

        public List<pet> PetEntities { get; set; }
    }
}
