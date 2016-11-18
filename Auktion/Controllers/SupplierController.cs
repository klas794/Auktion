using Auktion.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Auktion.Controllers
{
    class SupplierController
    {
        private readonly AuctionModel _auctionModel;

        public SupplierController()
        {
            _auctionModel = new AuctionModel();
        }

        public List<ValidationResult> Create(Supplier supplier)
        {
            var validation = Validation.DbValidate(supplier);

            if (validation.Item1)
            {
                _auctionModel.Supplier.Add(supplier);
                _auctionModel.SaveChanges();
            }

            return validation.Item2;
        }
        public List<Supplier> Read()
        {
            var suppliers = _auctionModel.Supplier.ToList();
            return suppliers;
        }
        public Supplier Read(int id)
        {
            var suppliers = _auctionModel.Supplier.Find(id);
            return suppliers;
        }
        public List<ValidationResult> Update(Supplier supplier)
        {
            var updateSupplier = _auctionModel.Supplier.Find(supplier.Id);

            updateSupplier.Firstname = supplier.Firstname;
            updateSupplier.Lastname = supplier.Lastname;
            updateSupplier.Commission = supplier.Commission;
            updateSupplier.Email = supplier.Email;
            updateSupplier.Phone = supplier.Phone;
            updateSupplier.Address.Street = supplier.Address.Street;
            updateSupplier.Address.Zip = supplier.Address.Zip;
            updateSupplier.Address.City = supplier.Address.City;
            updateSupplier.Address.Country = supplier.Address.Country;

            var validation = Validation.DbValidate(updateSupplier);

            if (validation.Item1)
            {
                _auctionModel.SaveChanges();
            }

            return validation.Item2;
        }
        public bool Delete(Supplier supplier)
        {
            try
            {
                _auctionModel.Supplier.Remove(supplier);
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
