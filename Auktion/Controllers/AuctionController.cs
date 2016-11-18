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

        public List<Tuple<Bidder, decimal>> GetAllWinnersAndTotalAmountPayed()
        {
            var tupleList = new List<Tuple<Bidder, decimal>>();
            // LÄGG TILL Winner i AuctionHistory
            //
            var winners = _auctionModel.AuctionHistory.Select(ah => ah.Winner).Distinct().ToList();
            
            foreach(var winner in winners)
            {
                var totalPayed = _auctionModel.AuctionHistory.Select(au => au.FinalBid).Where(a => a.Winner == winner).Sum();
                var tuple = Tuple.Create(winner.UserName, totalPayed);
                tupleList.Add(tuple);
            }
            return tupleList;
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
