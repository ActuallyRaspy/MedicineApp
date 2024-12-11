using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineApp.Models;

namespace MedicineApp.Services
{
    public static class MedicineService
    {
        public static List<Medicine> GetMedicines()
        {
            return new List<Medicine>
            {
                new Medicine
            {
                Icon = "paracetamol.jpg",
                Name = "Paracetamol",
                Description = "Used to treat mild to moderate pain and reduce fever.",
                Price = 5.99
            },
            new Medicine
            {
                Icon = "ibuprofen.jpg",
                Name = "Ibuprofen",
                Description = "Anti-inflammatory Medicine for pain and swelling.",
                Price = 7.99
            },
            new Medicine
            {
                Icon = "amoxicillin.jpg",
                Name = "Amoxicillin",
                Description = "Antibiotic for treating bacterial infections.",
                Price = 12.49
            },
            new Medicine
            {
                Icon = "cetirizine.jpg",
                Name = "Cetirizine",
                Description = "Relieves allergy symptoms such as runny nose and sneezing.",
                Price = 4.99
            },
            new Medicine
            {
                Icon = "metformin.jpg",
                Name = "Metformin",
                Description = "Used for managing type 2 diabetes by lowering blood sugar levels.",
                Price = 8.99
            },
            new Medicine
            {
                Icon = "losartan.jpg",
                Name = "Losartan",
                Description = "Lowers high blood pressure and protects kidneys in diabetics.",
                Price = 9.99
            },
            new Medicine
            {
                Icon = "omeprazole.jpg",
                Name = "Omeprazole",
                Description = "Reduces stomach acid and treats heartburn and ulcers.",
                Price = 6.99
            },
            new Medicine
            {
                Icon = "salbutamol.jpg",
                Name = "Salbutamol Inhaler",
                Description = "Quick relief from asthma symptoms.",
                Price = 15.99
            },
            new Medicine
            {
                Icon = "insulin_glargine.jpg",
                Name = "Insulin Glargine",
                Description = "Long-acting insulin for diabetes management.",
                Price = 25.99
            },
            new Medicine
            {
                Icon = "doxycycline.jpg",
                Name = "Doxycycline",
                Description = "Antibiotic for bacterial infections and acne.",
                Price = 10.49
            }

            };
        }
    }
}
