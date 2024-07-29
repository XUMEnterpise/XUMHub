using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace XUMHUB.DTOS
{

    public partial class LaptopModels
    {
        [Key]
        public int Id { get; set; }
        public string Sku { get; set; }
        public string LaptopModel { get; set; }
        public string Cpu { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public string Display { get; set; }
        public string WindowsVersion { get; set; }

    }
}
