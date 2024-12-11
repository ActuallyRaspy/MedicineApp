using MedicineApp.Views;
namespace MedicineApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("details", typeof(ProductDetailPage));
        }
    }
}
