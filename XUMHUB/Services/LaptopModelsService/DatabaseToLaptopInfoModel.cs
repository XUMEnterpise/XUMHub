using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.Services.LaptopModelsService
{
    class DatabaseToLaptopInfoModel : IDatabaseToLaptopInfoModel
    {
        public async Task<IEnumerable<LaptopInfoModel>> GetAllLaptopModels()
        {
            using(var db = new DBContext())
            {
                IEnumerable<LaptopModels> returnsInfoDTO = await db.LaptopModels.ToListAsync();
                return returnsInfoDTO.Select(r => ConvertToLaptopInfoModel(r));
            }
        }

        public Task<LaptopInfoModel> GetLaptopModelByModel(string model)
        {
            using (var db = new DBContext())
            {
                var laptopModel = db.LaptopModels.Where(x => x.LaptopModel == model).FirstOrDefault();
                return Task.FromResult(ConvertToLaptopInfoModel(laptopModel));
            }
        }
        private LaptopInfoModel ConvertToLaptopInfoModel(LaptopModels r)
        {
           return new LaptopInfoModel(r.Sku,r.LaptopModel,r.Cpu,r.Ram,r.Storage,r.Display,r.WindowsVersion);
        }
    }
}
