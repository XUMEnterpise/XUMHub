using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
		private int _laptopCountBuilt;
		public DashboardModel dashboardModel;
		
        public DashboardViewModel()
        {
			dashboardModel = new DashboardModel();
			LoadData();
        }
        public int LaptopCountBuilt
		{
			get
			{
				return _laptopCountBuilt;
			}
			set
			{
				_laptopCountBuilt = value;
				OnPropertyChanged(nameof(LaptopCountBuilt));
			}
		}
		private int _desktopBuiltToday;
		public int DesktopBuiltToday
		{
			get
			{
				return _desktopBuiltToday;
			}
			set
			{
				_desktopBuiltToday = value;
				OnPropertyChanged(nameof(DesktopBuiltToday));
			}
		}
		private int _desktopOrdersToday;
		public int DesktopOrdersToday
		{
			get
			{
				return _desktopOrdersToday;
			}
			set
			{
				_desktopOrdersToday = value;
				OnPropertyChanged(nameof(DesktopOrdersToday));
			}
		}
		private int _laptopOrdersToday;
		public int LaptopOrdersToday
		{
			get
			{
				return _laptopOrdersToday;
			}
			set
			{
				_laptopOrdersToday = value;
				OnPropertyChanged(nameof(LaptopOrdersToday));
			}
		}
		public async Task LoadData()
		{
			LaptopCountBuilt = await dashboardModel.LaptopBuiltToday();
			DesktopBuiltToday = await dashboardModel.DesktopBuiltToday();
			DesktopOrdersToday = await dashboardModel.DesktopOrdersToday();
			LaptopOrdersToday= await dashboardModel.LaptopOrdersToday();
		}
	}
}
