using Auktion.Controllers;
using Auktion.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktion
{
    public class ReportHandler
    {
        AuctionModel _auctionModel = new AuctionModel();
        AuctionController _auctionController = new AuctionController();
        //public List<Auction> EndingAuctionsReport(DateTime startDate, DateTime endDate)
        //{

        //    var result = _auctionModel.Auction.Where(x => x.Enddate.Ticks > startDate.Ticks && x.Enddate.Ticks < endDate.Ticks).ToList();
        //    return result;
        //}

        public List<Bidder> CustomerReport(DateTime startDate, DateTime endDate)
        {
            var result = _auctionModel.Bidder.ToList();
            return result;
        }

        public object MonthlyRevenue(DateTime startDate, DateTime endDate)
        {
            var monthlyRevenue = _auctionController.Read()
               .Where(x => x.Enddate <= endDate && x.Startdate >= startDate)
               .Select(x => new
               {
                   Revenue = x.Bids.Max(y => y.Price) * x.Product.Supplier.Commission,
                   Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Enddate.Month),
                   Year = x.Enddate.Year,
                   Enddate = x.Enddate
               })
               .GroupBy(x => new { Year = x.Enddate.Year, x.Enddate.Month }).ToList()
               .Select(x => new { Month = x.Select(y => y.Month).FirstOrDefault() + " " + x.Select(y => y.Year).FirstOrDefault(), Sum = x.Sum(y => y.Revenue) + " kr" }).ToList();
            return monthlyRevenue;
        }

        //public List<Tuple<Bidder, decimal>> GetAllWinnersAndTotalAmountPayed()
        //{
        //    var tupleList = new List<Tuple<Bidder, decimal>>();
        //    // LÄGG TILL Winner i AuctionHistory
        //    //
        //    var winners = _auctionModel.AuctionHistory.Select(ah => ah.Winner).Distinct().ToList();

        //    foreach (var winner in winners)
        //    {
        //        var totalPayed = _auctionModel.AuctionHistory.Select(au => au.FinalBid).Where(a => a.Winner == winner).Sum();
        //        var tuple = Tuple.Create(winner.UserName, totalPayed);
        //        tupleList.Add(tuple);
        //    }
        //    return tupleList;
        //}
    }
}
