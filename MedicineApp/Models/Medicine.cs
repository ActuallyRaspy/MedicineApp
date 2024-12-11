using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineApp.Models
{
    public class Medicine
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); //Auto creates the ID
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
