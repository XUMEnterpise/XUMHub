using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.Services
{
    public class CSVService
    {
        private readonly DBContext  _context;

        public CSVService ()
        {
            _context = new DBContext();
        }

        public POModel CreatePOModel(string filePath, string pONumber, string pOTitle)
        {
            var poEntries = new List<POEntryModel>();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Skip header line
            {
                var values = line.Split(',');
                var sku = values[0].Trim();
                var qty = int.Parse(values[2].Trim());
                poEntries.Add(new POEntryModel(sku, qty));
            }

            var poModel = new POModel(pONumber, pOTitle, poEntries);
            SavePOModeToDatabase(poModel);
            return poModel;
        }

        private void SavePOModeToDatabase(POModel poModel)
        {
            var poEntries = poModel.pOEntries.Select(entry => new PurchaseOrder
            {
                Ponumber = poModel.PONumber,
                Potitle= poModel.POTitle,
                Sku = entry.SKU,
                Quantity = entry.QTY
            });

            _context.PurchaseOrders.AddRange(poEntries);
            _context.SaveChanges();
        }
    }
}