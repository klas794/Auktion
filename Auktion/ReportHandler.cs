using Auktion.Controllers;
using Auktion.Models;
using Auktion.Models.ReportModels;
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

        public List<string> MonthlyRevenue(DateTime startDate, DateTime endDate)
        {
            //var salesReport = _auctionModel.AuctionHistory.GroupBy(g => new
            //{
            //    g.Enddate.Year,
            //    g.Enddate.Month
            //}).Select(s => new SalesReportModel
            //{
            //    Date = s.FirstOrDefault().Auction.Enddate,
            //    Auction = s.FirstOrDefault().Auction.Product.Name,
            //    Commission = s.Sum(x => x.FirstOrDefault().Auction.AuctionHistory.FinalBid * x.Auction.Product.Supplier.Commission)
            //}).ToList();

            //return salesReport;

            var monthlyRevenue = _auctionController.Read()
               .Where(x => x.Enddate <= DateTime.Now)
               .Select(x => new
               {
                   Revenue = x.Bids.Max(y => y.Price) * x.Product.Supplier.Commission,
                   Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Enddate.Month),
                   Enddate = x.Enddate
               })
               .GroupBy(x => new { Year = x.Enddate.Year, x.Enddate.Month }).ToList()
               .Select(x => x.Select(y => y.Month).FirstOrDefault() + ": " + x.Sum(y => y.Revenue) + " kr").ToList();
            return monthlyRevenue;
        }
    }
}
