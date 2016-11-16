using Auktion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktion.Controllers
{
    class SupplierController
    {
        private readonly AuctionModel _auctionModel;

        public SupplierController()
        {
            _auctionModel = new AuctionModel();
        }

        public List<ValidationResult> Create(Auction auction)
        {
            var context = new ValidationContext(auction, null, null);
            var result = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(auction, context, result, true);

            if (valid)
            {
                _auctionModel.Auctions.Add(auction);
                _auctionModel.SaveChanges();
            }

            return result;
        }

        public List<Supplier> Read()
        {
            var suppliers = _auctionModel.Suppliers.ToList();
            return suppliers;
        }
    }
}
