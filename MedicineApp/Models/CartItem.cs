using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineApp.Models
{
    public class CartItem
    {
        public Medicine Medicine { get; set; }
        public int Amount { get; set; }
        public double TotalPrice => Medicine.Price * Amount; 
    }
}
