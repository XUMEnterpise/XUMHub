using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;
using XUMHUB.Model;
using XUMHUB.Services.LaptopModelsService;

namespace XUMHUB.ViewModel
{
    public class LaptopLoggingViewModel : BaseViewModel
    {
        public ObservableCollection<LaptopInfoModel> LaptopInfo { get; set; }
        public ObservableCollection<LaptopInfoModel> FilteredLaptopInfo { get; set; }
        private IDatabaseToLaptopInfoModel _databaseToLaptopInfoModel;
        public string SKU => Laptop?.Sku;
        public string CPU => Laptop?.Cpu;
        public string RAM => Laptop?.Ram;
        public string Storage => Laptop?.Storage;
        public string ScreenSize => Laptop?.Display;
        public string OS => Laptop?.Os;
        public FaultsViewmodel FaultsViewmodel => new FaultsViewmodel();

        private LaptopInfoModel laptop;
        public LaptopInfoModel Laptop
        {
            get
            {
                return laptop;
            }
            set
            {
                laptop = value;
                OnPropertyChanged(nameof(Laptop));
                UpdateLaptopDetails();
            }
        }
        public LaptopLoggingViewModel()
        {
            _databaseToLaptopInfoModel = new DatabaseToLaptopInfoModel();
            LaptopInfo = new ObservableCollection<LaptopInfoModel>();
            FilteredLaptopInfo = new ObservableCollection<LaptopInfoModel>();
            LoadData();
            
        }
        private string searchQuery;
        public string SearchQuery
        {
            get
            {
                return searchQuery;
            }
            set
            {
                searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                FilterLaptops();
            }
        }
        private void FilterLaptops()
        {
            FilteredLaptopInfo.Clear();
            foreach (var laptop in LaptopInfo.Where(l => l.Model.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)))
            {
                FilteredLaptopInfo.Add(laptop);
            }
        }
        private void UpdateLaptopDetails()
        {
            // Notify that all dependent properties have changed
            OnPropertyChanged(nameof(SKU));
            OnPropertyChanged(nameof(CPU));
            OnPropertyChanged(nameof(RAM));
            OnPropertyChanged(nameof(Storage));
            OnPropertyChanged(nameof(OS));
            OnPropertyChanged(nameof(ScreenSize));
        }
        public async void LoadData()
        {
            IEnumerable<LaptopInfoModel> laptopInfo = await _databaseToLaptopInfoModel.GetAllLaptopModels();
            foreach (var item in laptopInfo)
            {
                LaptopInfo.Add(item);
                FilteredLaptopInfo.Add(item);
            }
        }
    }
}
