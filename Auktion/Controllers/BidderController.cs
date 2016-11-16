using Auktion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktion.Controllers
{
    class BidderController
    {
        private readonly AuctionModel _auctionModel;

        public BidderController()
        {
            _auctionModel = new AuctionModel();
        }

        public List<ValidationResult> Create(Bidder bidder)
        {
            var context = new ValidationContext(bidder, null, null);
            var result = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(bidder, context, result, true);

            if (valid)
            {
                _auctionModel.Bidder.Add(bidder);
                _auctionModel.SaveChanges();
            }

            return result;
        }

        public List<Bidder> Read()
        {
            var bidders = _auctionModel.Bidder.ToList();
            return bidders;
        }
    }
}
