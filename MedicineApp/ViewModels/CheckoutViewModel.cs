using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicineApp.Views;
using MedicineApp.Services;
using MedicineApp.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Net.Mail;
namespace MedicineApp.ViewModels
{
    public class CheckoutViewModel : BaseViewModel
    {
        private string name;
        private string address;
        private string email;
        private string phone;

        public ObservableCollection<CartItem> CartItems { get; set; }
        public double TotalPrice => CartItems.Sum(item => item.TotalPrice);

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public string UserEmail // Avoid clashing with the Email class
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        public ICommand CheckoutCommand { get; }

        public CheckoutViewModel()
        {
            CartItems = new ObservableCollection<CartItem>(CartService.Instance.GetCartItems());
            CheckoutCommand = new Command(async () => await Checkout());
        }

        private async Task Checkout() // When button is clicked, perform validation and then send mail
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Address) ||
                string.IsNullOrWhiteSpace(UserEmail) ||
                string.IsNullOrWhiteSpace(Phone))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "All fields are required.", "OK");
                return;
            }

            if (!IsValidEmail(UserEmail))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email is incorrectly formated.", "OK");
                return;
            }

            if (Phone.Length != 10)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Phone number must be 10 numbers.", "OK");
                return;
            }

            if (Name.Length > 50)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Name is too long, max 50 characters.", "OK");
                return;
            }
            if (Name.Length <= 2)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Name is too short, minimum 3 characters.", "OK");
                return;
            }

            if (address.Length > 100)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Address is too long, max 100 characters.", "OK");
                return;
            }
            if (address.Length <= 2)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Address is too short, minimum 3 characters.", "OK");
                return;
            }

            var cartSummary = new StringBuilder();
            foreach (var item in CartItems)
            {
                cartSummary.AppendLine($"{item.Amount}x {item.Medicine.Name} - {item.TotalPrice:C}");
            }

            string emailContent = $@"
            Name: {Name}
            Address: {Address}
            Email: {UserEmail}
            Phone: {Phone}

            Items:
            {cartSummary}

            Total: {TotalPrice:C}";

            try
            {

                if (Email.Default.IsComposeSupported) // Sending email
                {
                    var message = new EmailMessage
                    {
                        Subject = "Order from: " + Name,
                        Body = emailContent,
                        BodyFormat = EmailBodyFormat.PlainText,
                        To = new List<string> { "veryrealemail@probablygmail.nu" }
                    };

                    await Email.Default.ComposeAsync(message);
                }

                await Application.Current.MainPage.DisplayAlert("Success", "Order placed successfully!", "OK");
                CartService.Instance.ClearCart();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to send email: {ex.Message}", "OK");
            }
        }
        bool IsValidEmail(string email) // Email validation
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}