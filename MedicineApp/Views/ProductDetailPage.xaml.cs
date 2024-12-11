using Microsoft.Maui.Controls;
using static MedicineApp.Views.ProductPage;
using MedicineApp.Models;
using MedicineApp.Services;
using MedicineApp.Models;
using MedicineApp.ViewModels;
namespace MedicineApp.Views;

public partial class ProductDetailPage : ContentPage
{
    public ProductDetailPage(Medicine medicine)
    {
        InitializeComponent();
        BindingContext = new ProductDetailViewModel(medicine);
    }
}