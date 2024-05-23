using System.Windows.Controls;
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
            ReturnsViewModel returnsViewModel = new ReturnsViewModel();
            DataContext = returnsViewModel;
        }
    }
}
