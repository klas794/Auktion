using Auktion.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            var validation = Validation.DbValidate(product);

            if (validation.Item1)
            {
                _auctionModel.Product.Add(product);
                _auctionModel.SaveChanges();
            }

            return validation.Item2;
        }
        public List<Product> Read()
        {
            var products = _auctionModel.Product.ToList();
            return products;
        }
        public List<ValidationResult> Update(int id, string name, int supplyId, string description, Product.Conditions condition)
        {
            var oldProduct = _auctionModel.Product.Where(x => x.Id == id).Single();
            var updateProduct = _auctionModel.Product.Find(oldProduct.Id);

            updateProduct.Name = name;
            updateProduct.SupplyId = supplyId;
            updateProduct.Description = description;
            updateProduct.Condition = condition;

            var validation = Validation.DbValidate(updateProduct);

            if (validation.Item1)
            {
                _auctionModel.SaveChanges();
            }

            return validation.Item2;
        }
        public bool Delete(Product product)
        {
            try
            {
                _auctionModel.Product.Remove(product);
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
