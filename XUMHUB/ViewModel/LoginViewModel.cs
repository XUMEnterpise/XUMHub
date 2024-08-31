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
        NavigationService<RepairViewModel> repairNavService;
        public MainViewModel MainViewModel { get; set; }

        public AgentModel AgentModel { get; set; }
        public LoginViewModel(NavigationService<RepairViewModel> repairNavService, AgentStore agentStore)
        {
			LoginCommand = new RelayCommand(s => OnLogin());
			this.repairNavService = repairNavService;
            AgentStore = agentStore;
        }

        private void OnLogin()
        {
			AgentModel = agentService.GetAgent(staffCode);
            if(AgentModel == null)
            {
                return;
            }
            AgentStore.AgentModel = AgentModel;
            MainViewModel.IsButtonEnabled = true;
            repairNavService.Navigate();
            
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
