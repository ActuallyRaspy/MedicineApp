using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicineApp.Models;
using MedicineApp.Services;
using MedicineApp.Views;

namespace MedicineApp.ViewModels
{
    public class ProductPageViewModel : BaseViewModel
    {
        private ObservableCollection<Medicine> _products;
        public ObservableCollection<Medicine> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private Medicine _selectedProduct;
        public Medicine SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (SetProperty(ref _selectedProduct, value))
                {
                    OnProductTapped(value);
                }
            }
        }

        public ICommand NavigateToCartCommand { get; }

        public ProductPageViewModel()
        {
            LoadMedicines();
            NavigateToCartCommand = new Command(async () => await NavigateToCart());
        }

        private void LoadMedicines()
        {
            var medicines = MedicineService.GetMedicines();
            Products = new ObservableCollection<Medicine>(medicines);
        }

        private async Task NavigateToCart()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CheckoutPage());
        }

        private async void OnProductTapped(Medicine selectedMedicine)
        {
            if (selectedMedicine != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ProductDetailPage(selectedMedicine));
            }
        }
    }
}
