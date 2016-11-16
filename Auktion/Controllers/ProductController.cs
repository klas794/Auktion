using Auktion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktion.Controllers
{
    class ProductController
    {
        private readonly AuctionModel _auctionModel;

        public ProductController()
        {
            _auctionModel = new AuctionModel();
        }

        public void Create()
        {

        }

        public List<Auction> Read()
        {
            var auctions = _auctionModel.Auction.ToList();
            return auctions;
        }
    }
}
