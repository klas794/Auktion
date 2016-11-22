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

        public object EndingAuctionsReport(DateTime startDate, DateTime endDate)
        {
            var result = _auctionController.Read()
               .Where(x => x.Enddate <= endDate && x.Enddate >= startDate)
               .Select(x => new
               {
                   Name = x.Name,
                   Revenue = Math.Round(x.Bids.Max(y => y.Price) * x.Product.Supplier.Commission,2),
               }).ToList();
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
               .Select(x => new { Month = x.Select(y => y.Month).FirstOrDefault() + " " + x.Select(y => y.Year).FirstOrDefault(), Sum = Math.Round(x.Sum(y => y.Revenue),2) + " kr" }).ToList();
            return monthlyRevenue;
        }

        public object BidderReport()
        {
            var bidderReport = new List<object>();
            var winners = _auctionModel.AuctionHistory.Select(ah => ah.BidderId).Distinct().ToList();

            foreach (var winner in winners)
            {
                var totalPayed = _auctionModel.AuctionHistory.Where(a => a.Id == winner).Sum(x => x.FinalBid);
                var name = _auctionModel.AuctionHistory.Where(a => a.Id == winner)
                    .Select(x => string.Concat(x.Bidder.Firstname, " ", x.Bidder.Lastname)).FirstOrDefault();

                bidderReport.Add(new { Name = name, Payed = totalPayed });
                
            }
            return bidderReport;
        }
    }
}
