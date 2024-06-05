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
		public void LoadData()
		{
			_laptopCountBuilt = 0;
		}
	}
}
