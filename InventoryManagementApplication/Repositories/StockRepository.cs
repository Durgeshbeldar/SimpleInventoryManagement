using InventoryManagementApplication.Data;
using InventoryManagementApplication.Exceptions;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Repositories
{
    internal class StockRepository
    {
        private InventoryContext _context;

        public StockRepository()
        {
            _context = new InventoryContext();
        }

        public void AddEmptyStock(int productId)
        {
            Stock stock = new Stock(productId);
            _context.InventoryStocks.Add(stock);
            _context.SaveChanges();
        }

        public void AddQuantities(List<Tuple<int, int>> productIdsWithQuantities)
        {  
            List <Stock> stocks = _context.InventoryStocks.ToList();
            foreach (var pair in productIdsWithQuantities)
            {
                int productId = pair.Item1; 
                int quantity = pair.Item2;
                Stock stock = stocks.FirstOrDefault(s => s.ProductId == productId);
                if (stock == null)
                    continue;
                stock.AvailableQuantity = stock.AvailableQuantity + quantity; 
                stock.TotalPurchased  = stock.TotalPurchased + quantity;
            } 
            _context.SaveChanges(); 
        }

        public void RemoveQuantities(List<Tuple<int, int>> productIdsWithQuantities)
        {
            List<Stock> stocks = _context.InventoryStocks.ToList();
            foreach (var pair in productIdsWithQuantities)
            {
                int productId = pair.Item1;
                int quantity = pair.Item2;
                Stock stock = stocks.FirstOrDefault(s => s.ProductId == productId);
                if (stock == null)
                    continue;
                stock.AvailableQuantity = stock.AvailableQuantity - quantity;
                stock.TotalSold = stock.TotalSold + quantity;
            }
            _context.SaveChanges();
        }

        public bool IsProductAvailable(int productId,int quantity)
        {
           var stock =  _context.InventoryStocks.Where(stock => stock.ProductId == productId).FirstOrDefault();
           if (stock != null)
                return stock.AvailableQuantity >= quantity;
            throw new ProductNotFoundException("Product Not Found In Stock, Please Try Another Product.");
        }
    }
}
