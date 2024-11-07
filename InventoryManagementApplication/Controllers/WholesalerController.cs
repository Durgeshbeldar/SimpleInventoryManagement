using InventoryManagementApplication.Models;
using InventoryManagementApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Controllers
{
    internal class WholesalerController
    {
        private readonly WholesalerRepository _wholesalerRepository;

        public WholesalerController()
        {
            _wholesalerRepository = new WholesalerRepository();
        }

        // Add New Wholesaler
        public string AddWholesaler(Wholesaler wholesaler)
        {
            _wholesalerRepository.Add(wholesaler);
            return "Wholesaler Added Successfully to The DataBase...!";
        }

        // Update wholesaler details
        public string UpdateWholesaler(Wholesaler wholesaler)
        {
            return _wholesalerRepository.Update(wholesaler);
        }

        // Delete a wholesaler
        public string DeleteWholesaler(int wholesalerId)
        {
            return _wholesalerRepository.Delete(wholesalerId);
        }

        // Get all wholesalers
        public List<Wholesaler> GetAllWholesalers()
        {
            return _wholesalerRepository.GetAll();
        }

        // Search for a wholesaler by ID
        public Wholesaler GetWholesalerById(int wholesalerId)
        {
            return _wholesalerRepository.GetWholesalerById(wholesalerId);
        }
    }
}
