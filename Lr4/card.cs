using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public class card
    {
        [Key] public int id { get; set; }

        public DateTime recdate { get; set; }

        public string vname { get; set; }
        public string oname { get; set; }
        public string dname { get; set; }

        [ForeignKey("PetEntity")] public int id_pet { get; set; }

        [ForeignKey("id_pet")]
        public pet PetEntity { get; set; }
        
    }
}
