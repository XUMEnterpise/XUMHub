using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Commands;
using XUMHUB.Core;
using XUMHUB.DTOS;
using XUMHUB.Model;
using XUMHUB.Services;
using XUMHUB.Services.AgentService;
using XUMHUB.Services.LaptopModelsService;
using XUMHUB.Stores;

namespace XUMHUB.ViewModel
{
    public class LaptopLoggingViewModel : BaseViewModel
    {

		IDatabaseToAgent databaseToAgent = new DatabaseToAgent();
        public ICommand SubmitCommand => new RelayCommand(Submit);
        AgentModel agent;
		NavigationStore _store { get; }
        public AgentStore AgentStore { get; }

        private FaultsViewmodel faultsViewmodel;
		public FaultsViewmodel FaultsViewmodel
		{
			get
			{
				return faultsViewmodel;
			}
			set
			{
                faultsViewmodel = value;
				OnPropertyChanged(nameof(faultsViewmodel));
			}
		}
		private void Submit(object obj)
        {
            if (string.IsNullOrEmpty(ServiceCode))
            {
                return;
            }
			agent = AgentStore.AgentModel;
			if(agent==null)
            {
                return;
            }
			List<FaultModel> faults= new List<FaultModel>();
			foreach(var fault in FaultsViewmodel.FaultSelections)
			{
				FaultModel faultModel=new FaultModel(fault.SelectedFault.faultId, fault.SelectedFault.repairId, fault.FaultName, fault.IsRepaired);
                faults.Add(faultModel);
            }
            RepairEntryViewModel repairEntryViewModel = new RepairEntryViewModel(null,serviceCode,agent.AgentName,DateTime.Now,"PENDING",null,null,faults);
            ICommand CreateRepairCommand = new CreateRepairEntryCommand(repairEntryViewModel);
            CreateRepairCommand.Execute(null);
			NavigateToRepairs();
        }

        private void NavigateToRepairs()
        {
            RepairViewModel repairViewModel = new RepairViewModel(_store, AgentStore);
			NavigationService<RepairViewModel> repairSerivice=new NavigationService<RepairViewModel>(_store, () => repairViewModel);
            ICommand Navigate=new NavigateCommand<RepairViewModel>(repairSerivice);
            Navigate.Execute(null);
        }

        private string agentName;
		public string AgentName
        {
			get
			{
				return agentName;
			}
			set
			{
                agentName = value;
				OnPropertyChanged(nameof(agentName));
            }
		}
		private string serviceCode;
		public string ServiceCode
		{
			get
			{
				return serviceCode;
			}
			set
			{
                serviceCode = value;
				OnPropertyChanged(nameof(serviceCode));
			}
		}

        public LaptopLoggingViewModel(NavigationStore store,AgentStore agentStore)
        {
            _store = store;
            AgentStore = agentStore;
            FaultsViewmodel = new FaultsViewmodel(AgentStore);
			agentName= AgentStore.AgentModel.AgentName;
        }
    }
}
