using Auktion.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            var validation = Validation.DbValidate(bidder);

            if (validation.Item1)
            {
                _auctionModel.Bidder.Add(bidder);
                _auctionModel.SaveChanges();
            }

            return validation.Item2;
        }

        public List<Bidder> Read()
        {
            var bidders = _auctionModel.Bidder.ToList();
            return bidders;
        }
        public List<ValidationResult> Update(Bidder bidder)
        {
            var updateBidder = _auctionModel.Bidder.Find(bidder.Id);

            updateBidder.Firstname = bidder.Firstname;
            updateBidder.Lastname = bidder.Lastname;
            updateBidder.Username = bidder.Username;
            updateBidder.Email = bidder.Email;
            updateBidder.Phone = bidder.Phone;
            updateBidder.Address.Street = bidder.Address.Street;
            updateBidder.Address.Zip = bidder.Address.Zip;
            updateBidder.Address.City = bidder.Address.City;
            updateBidder.Address.Country = bidder.Address.Country;

            var validation = Validation.DbValidate(updateBidder);

            if (validation.Item1)
            {
                _auctionModel.SaveChanges();
            }

            return validation.Item2;
        }
        public bool Delete(Bidder bidder)
        {
            try
            {
                _auctionModel.Bidder.Remove(bidder);
                _auctionModel.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
