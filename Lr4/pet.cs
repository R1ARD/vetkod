using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lr4
{
    public class pet
    {
        [Key] public int id { get; set; }
        public string pname { get; set; }
        public string kind { get; set; }
        public string status { get; set; }

        public List<card> CardEntities { get; set; }


        [ForeignKey("PetOwnerEntity")] public int id_owner { get; set; }

        [ForeignKey("VeterinarianEntity")] public int id_veterinarian { get; set; }

        [ForeignKey("DiseaseEntity")] public int id_disease { get; set; }

        [ForeignKey("id_owner")]
        public petowner PetOwnerEntity { get; set; }
        [ForeignKey("id_veterinarian")] 
        public veterinarian VeterinarianEntity { get; set; }
        [ForeignKey("id_disease")]
        public disease DiseaseEntity { get; set; }
    }
}
