using Auktion.Models;
using Auktion.Models.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktion
{
    public class ReportHandler
    {
        AuctionModel _auctionModel = new AuctionModel();
        //public List<Auction> EndingAuctionsReport(DateTime startDate, DateTime endDate)
        //{

        //    var result = _auctionModel.Auction.Where(x => x.Enddate.Ticks > startDate.Ticks && x.Enddate.Ticks < endDate.Ticks).ToList();
        //    return result;
        //}

        public List<Bidder> CustomerReport(DateTime startDate, DateTime endDate)
        {
            var result = _auctionModel.Bidders.ToList();
            return result;
        }

        //public List<SalesReportModel> SalesReport(DateTime startDate, DateTime endDate)
        //{
        //    var salesReport = _auctionModel.AuctionHistory.GroupBy(g => new
        //    {
        //        g.Enddate.Year,
        //        g.Enddate.Month
        //    }).Select(s => new SalesReportModel
        //    {
        //        Date = s.FirstOrDefault().Auction.Enddate,
        //        Auction = s.FirstOrDefault().Auction.Product.Name,
        //        Commission = s.Sum(x => x.Auction.AuctionHistory.FinalBid * x.Auction.Product.Supplier.Commission)
        //    }).ToList();

        //    return salesReport;
        //}
    }
}
