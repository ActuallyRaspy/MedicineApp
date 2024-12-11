using MedicineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineApp.Services
{
    public class CartService
    {
        private static CartService _instance;

        //Singleton instance. One single instance that is accessed globally
        public static CartService Instance => _instance ??= new CartService();

        private readonly List<CartItem> _cartItems = new();

        public List<CartItem> GetCartItems() => _cartItems;

        public void AddToCart(Medicine medicine, int amount)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.Medicine.Id == medicine.Id);
            if (existingItem != null)
            {
                existingItem.Amount += amount;
            }
            else
            {
                _cartItems.Add(new CartItem { Medicine = medicine, Amount = amount });
            }
        }

        public void RemoveFromCart(Medicine medicine)
        {
            _cartItems.RemoveAll(item => item.Medicine.Id == medicine.Id);
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

        public double GetTotalPrice()
        {
            return _cartItems.Sum(item => item.TotalPrice);
        }
    }
}
