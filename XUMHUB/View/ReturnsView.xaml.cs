using System.Windows.Controls;
using System.Windows.Input;
using XUMHUB.Services;
using XUMHUB.ViewModel;


namespace XUMHUB.View
{
    /// <summary>
    /// Interaction logic for ReturnsView.xaml
    /// </summary>
    public partial class ReturnsView : UserControl
    {
        public ReturnsView()
        {
            InitializeComponent();
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item && item.DataContext is ReturnsInfoViewModel returnsInfo)
            {
                ((ReturnsListingViewModel)this.DataContext).HandleDoubleClick(returnsInfo);
            }
        }
    }
}
