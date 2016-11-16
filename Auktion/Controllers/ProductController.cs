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

        public List<Product> Read()
        {
            var products = _auctionModel.Product.ToList();
            return products;
        }
    }
}
