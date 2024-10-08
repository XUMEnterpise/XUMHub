﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XUMHUB.ViewModel;

namespace XUMHUB.View
{
    /// <summary>
    /// Interaction logic for RepairView.xaml
    /// </summary>
    public partial class RepairView : UserControl
    {
        public RepairView()
        {
            InitializeComponent();
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item && item.DataContext is RepairEntryViewModel returnsInfo)
            {
                ((RepairViewModel)this.DataContext).HandleDoubleClick(returnsInfo);
            }
        }
    }
}
