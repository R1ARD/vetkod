using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lr4
{
    public class medecine
    {
        public int id { get; set; }
        public string mname { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public string contraindications { get; set; }
        public bool isrecipe { get; set; }

        public List<disease> DiseaseEntities { get; set; }

    }
}
