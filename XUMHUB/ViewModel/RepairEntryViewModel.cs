﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    class RepairEntryViewModel
    {
        public readonly RepairDataModel _repairData;
        public string ServiceTag => _repairData.ServiceTag;
        public string Agent => _repairData.AgentLogged.AgentName;
        public DateTime LoggedDate => _repairData.DateLogged;
        public string RepairStatus => _repairData.RepairStatus;
        public DateTime? RepairDate => _repairData.RepairedDate;
        public string RepairAgent => _repairData.AgentRepaired.AgentName;
        public List<FaultViewModel> Faults;


        public RepairEntryViewModel(RepairDataModel repairData)
        {
            _repairData = repairData;
        }
        public void LoadData()
        {
            foreach (var fault in _repairData.Faults)
            {
                Faults.Add(new FaultViewModel(fault));
            }
        }

    }
}