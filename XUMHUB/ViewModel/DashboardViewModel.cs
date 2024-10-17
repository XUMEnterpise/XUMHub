using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;
using System.Timers;
using XUMHUB.Stores;

namespace XUMHUB.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
		private int _laptopCountBuilt;
		public DashboardModel dashboardModel;
        private System.Timers.Timer _timer;


        public DashboardViewModel(AgentStore agentStore)
        {
			dashboardModel = new DashboardModel();
			LoadData();
            _timer = new System.Timers.Timer(1000); // 30 seconds interval
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            AgentStore = agentStore;
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
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
		private int _laptopTestedToday;
		public int LaptopTestedToday
		{
			get
			{
				return _laptopTestedToday;
			}
			set
			{
				_laptopTestedToday = value;
				OnPropertyChanged(nameof(LaptopTestedToday));
			}
		}

		public AgentStore AgentStore { get; }

        public async Task LoadData()
		{
			LaptopCountBuilt = await dashboardModel.LaptopBuiltToday();
			DesktopBuiltToday = await dashboardModel.DesktopBuiltToday();
			DesktopOrdersToday = await dashboardModel.DesktopOrdersToday();
			LaptopOrdersToday= await dashboardModel.LaptopOrdersToday();
            LaptopTestedToday = await dashboardModel.LaptopTestedToday();
        }
	}
}
