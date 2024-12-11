using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicineApp.Models;
using MedicineApp.Services;

namespace MedicineApp.ViewModels
{
    public class ProductDetailViewModel : BaseViewModel
    {
        private int _quantity = 1;
        private Medicine _medicine;

        public Medicine Medicine
        {
            get => _medicine;
            set => SetProperty(ref _medicine, value);
        }

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public ICommand AddToCartCommand { get; }

        public ProductDetailViewModel(Medicine medicine)
        {
            Medicine = medicine;
            AddToCartCommand = new Command(AddToCart);
        }

        private void AddToCart()
        {
            CartService.Instance.AddToCart(Medicine, Quantity);

            Application.Current.MainPage.DisplayAlert(
                "Cart",
                $"{Quantity} of {Medicine.Name} added to the cart.",
                "OK");
        }
    }
}
