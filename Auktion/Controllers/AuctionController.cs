using Auktion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktion.Controllers
{
    public class AuctionController
    {
        private readonly AuctionModel _auctionModel;

        public AuctionController()
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
                _auctionModel.Auction.Add(auction);
                _auctionModel.SaveChanges();
            }

            return result;
        }

        public List<Auction> Read()
        {
            var auctions = _auctionModel.Auction.ToList();
            return auctions;
        }
    }
}
