using System.Windows;
using System.Windows.Controls;

namespace TestMvvmApp.Components
{
    /// <summary>
    /// Interaction logic for ToyListingItem.xaml
    /// </summary>
    public partial class ToyListingItem : UserControl
    {
        public ToyListingItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToysListItemDropDown.IsOpen = false;
        }
    }
}
