using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.Services.LaptopModelsService
{
    public interface IDatabaseToLaptopInfoModel
    {
        public Task<IEnumerable<LaptopInfoModel>> GetAllLaptopModels();
        public Task<LaptopInfoModel> GetLaptopModelByModel(string model);
    }
}
