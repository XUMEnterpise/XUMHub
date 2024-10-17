using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;
using System.Timers;
using XUMHUB.Stores;
using System.Windows.Input;
using XUMHUB.Core;
using XUMHUB.Helpers;

namespace XUMHUB.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
		private int _laptopCountBuilt;
		public DashboardModel dashboardModel;
        private System.Timers.Timer _timer;
		public ICommand SendLaptopsReport { get; }
		public ICommand SendDesktopsReport { get; }


        public DashboardViewModel(AgentStore agentStore)
        {
			dashboardModel = new DashboardModel();
			LoadData();
            _timer = new System.Timers.Timer(1000); // 30 seconds interval
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            AgentStore = agentStore;
			Date=DateTime.Now;
			SendLaptopsReport = new RelayCommand(s => SendLaptopsReportMethod());
            SendDesktopsReport = new RelayCommand(s => SendDesktopsReportMethod());
        }

        private async void SendDesktopsReportMethod()
        {
            string message = $"Date {Date}\nPCs Printed: {DesktopBuiltToday}\nPCs Tested:{DesktopsTestedToday}\nPC Orders:{DesktopOrdersToday}";
            await dashboardModel.SendChatMessage(message,ChatHook.GPCWebhook);
        }

        private async void SendLaptopsReportMethod()
        {
			string message = $"Date {Date}\nLaptops Printed: {LaptopCountBuilt}\nLaptops Tested:{LaptopTestedToday}\nLaptop Orders:{LaptopOrdersToday}";
			await dashboardModel.SendChatMessage(message,ChatHook.LaptopWebhook);
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
		private int _desktopsTestedToday;
		public int DesktopsTestedToday
		{
			get
			{
				return _desktopsTestedToday;
			}
			set
			{
				_desktopsTestedToday = value;
				OnPropertyChanged(nameof(DesktopsTestedToday));
			}
		}
		private DateTime? _date;
		public DateTime? Date
		{
			get
			{
				return _date;
			}
			set
			{
				_date = value;
				OnPropertyChanged(nameof(Date));
			}
		}
		public AgentStore AgentStore { get; }

        public async Task LoadData()
		{
			LaptopCountBuilt = await dashboardModel.LaptopBuilt(Date??DateTime.Now);
			DesktopBuiltToday = await dashboardModel.DesktopBuilt(Date ?? DateTime.Now);
			DesktopOrdersToday = await dashboardModel.DesktopOrders(Date ?? DateTime.Now);
			LaptopOrdersToday= await dashboardModel.LaptopOrders(Date ?? DateTime.Now);
            LaptopTestedToday = await dashboardModel.LaptopTested(Date ?? DateTime.Now);
            DesktopsTestedToday = await dashboardModel.DesktopsTested(Date ?? DateTime.Now);

        }
	}
}
