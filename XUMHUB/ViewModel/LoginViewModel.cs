using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Commands;
using XUMHUB.Core;
using XUMHUB.Model;
using XUMHUB.Services;
using XUMHUB.Services.AgentService;
using XUMHUB.Stores;

namespace XUMHUB.ViewModel
{
    internal class LoginViewModel :BaseViewModel
    {
		private string staffCode;
		public ICommand LoginCommand { get; }
		IDatabaseToAgent agentService = new DatabaseToAgent();
        NavigationService<DashboardViewModel> dahsboardNavService;
        public MainViewModel MainViewModel { get; set; }

        public AgentModel AgentModel { get; set; }
        public LoginViewModel(NavigationService<DashboardViewModel> dahsboardNavService, AgentStore agentStore)
        {
			LoginCommand = new RelayCommand(s => OnLogin());
			this.dahsboardNavService = dahsboardNavService;
            AgentStore = agentStore;
        }

        private async void OnLogin()
        {
			AgentModel = await agentService.GetAgent(staffCode);
            if(AgentModel == null)
            {
                return;
            }
            AgentStore.AgentModel = AgentModel;
            MainViewModel.IsButtonEnabled = true;

            dahsboardNavService.Navigate();
            
        }

        public string StaffCode
		{
			get { return staffCode; }
			set 
			{ staffCode = value;
				OnPropertyChanged();
			}
			
		}

        public AgentStore AgentStore { get; }
    }
}
