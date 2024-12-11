namespace MedicineApp.Views;
using MedicineApp.Models;
using System.Collections.ObjectModel;
using MedicineApp.Services;
using MedicineApp.ViewModels;


public partial class CheckoutPage : ContentPage
{
    public ObservableCollection<CartItem> CartItems { get; set; }

    public CheckoutPage()
	{
		InitializeComponent();
        BindingContext = new CheckoutViewModel();
    }
}