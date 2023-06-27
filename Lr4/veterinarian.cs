using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lr4
{
    public class veterinarian
    {
        [Key] public int id { get; set; }
        public string vname { get; set; }
        public string vsecondname { get; set; }
        public string vfathername { get; set; }
        public string gender { get; set; }
        public DateTime birthdate { get; set; }
        public string phonenumber { get; set; }
        public string emailaddress { get; set; }
        public string vpassword { get; set; }
        public string vaddress { get; set; }
        public int salary { get; set; }
        public string education { get; set; }

        public List<petowner> PetOwnerEntities { get; set; }

        public List<pet> PetEntities { get; set; }
        public List<card> CardEntities { get; set; }
    }
}
