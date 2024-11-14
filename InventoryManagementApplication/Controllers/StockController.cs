using InventoryManagementApplication.Models;
using InventoryManagementApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Controllers
{
    internal class StockController
    {
        private StockRepository _stockRepository;

        public StockController()
        {
            _stockRepository = new StockRepository();
        }

        public void AddEmptyStockToInventory(int productId)
        {
            _stockRepository.AddEmptyStock(productId);
        }
        public string AddStocks(List<Tuple<int, int>> productWithQuantities)
        {
            _stockRepository.AddQuantities(productWithQuantities);
            return "Inventory Updated Successfully";
        }

        public string RemoveStocks(List<Tuple<int, int>> productWithQuantities)
        {
            _stockRepository.RemoveQuantities(productWithQuantities);
            return "Inventory Updated Successfully";
        }

        public bool IsAvailable(int productId, int quantity)
        {
            return _stockRepository.IsProductAvailable(productId, quantity);
        }
    }
}
