using System.Windows;

namespace ShopChiypesh
{
    public partial class BackgroundWindow : Window
    {
        public BackgroundWindow()
        {
            InitializeComponent();
            frame_auto_reg.NavigationService.Navigate(new pages.AuthorizationPage());
        }
    }
}
