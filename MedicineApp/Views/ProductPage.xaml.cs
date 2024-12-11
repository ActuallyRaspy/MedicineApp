using MedicineApp.ViewModels;

namespace MedicineApp.Views;

public partial class ProductPage : ContentPage
{
    public ProductPage()
    {
        InitializeComponent();
        BindingContext = new ProductPageViewModel();
    }
}
