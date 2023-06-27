using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lr4
{
    public class petowner
    {
        [Key] public int id { get; set; }
        public string oname { get; set; }
        public string osecondname { get; set; }
        public string ofathername { get; set; }
        public string gender { get; set; }
        public string phonenumber { get; set; }
        public string emailaddress { get; set; }
        public string oaddress { get; set; }

        [ForeignKey("VeterinarianEntity")] public int id_veterinarian { get; set; }
       
        public veterinarian VeterinarianEntity { get; set; }

        public List<pet> PetEntities { get; set; }
    }
}
