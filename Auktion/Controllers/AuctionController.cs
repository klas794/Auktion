using Auktion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            var validation = Validation.DbValidate(auction);

            if (validation.Item1)
            {
                _auctionModel.Auction.Add(auction);
                _auctionModel.SaveChanges();
            }

            return validation.Item2;
        }

        public List<Auction> Read()
        {
            var auctions = _auctionModel.Auction.ToList();
            return auctions;
        }        

        public List<ValidationResult> Update(Auction auction)
        {
            var updateAuction = _auctionModel.Auction.Find(auction.Id);

            updateAuction.ProductId = auction.ProductId;
            updateAuction.Name = auction.Name;
            updateAuction.Startprice = auction.Startprice;
            updateAuction.BuyNow = auction.BuyNow;
            updateAuction.Startdate = auction.Startdate;
            updateAuction.Enddate = auction.Enddate;
            //updateAuction.Photo = auction.Photo;

            var validation = Validation.DbValidate(updateAuction);

            if (validation.Item1)
            {
                _auctionModel.SaveChanges();
            }

            return validation.Item2;
        }
        public bool Delete(Auction auction)
        {
            try
            {
                _auctionModel.Auction.Remove(auction);
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
