using Auktion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public List<ValidationResult> Create(Product product)
        {
            var context = new ValidationContext(product, null, null);
            var result = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(product, context, result, true);

            if (valid)
            {
                _auctionModel.Product.Add(product);
                _auctionModel.SaveChanges();
            }

            return result;
        }

        public List<Product> Read()
        {
            var products = _auctionModel.Product.ToList();
            return products;
        }
    }
}
