using Auktion.Controllers;
using Auktion.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Auktion
{
    public partial class Form1 : Form
    {
        readonly AuctionController _auctionController;
        readonly SupplierController _supplierController;
        readonly ProductController _productController;
        readonly BidderController _bidderController;
        public Form1()
        {
            _auctionController = new AuctionController();
            _supplierController = new SupplierController();
            _productController = new ProductController();
            _bidderController = new BidderController();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateFormWithData();
        }

        #region - Supplier Tab  -

        private void btnCreateAuction_Click(object sender, EventArgs e)
        {
            cboAuctionSupplier.SelectedIndex = lstSuppliers.SelectedIndex;
            MainTabController.SelectedIndex = 3;
        }

        private void btnRegisterProduct_Click(object sender, EventArgs e)
        {
            cboProductSupplier.SelectedIndex = lstSuppliers.SelectedIndex;
            txtProductDescription.Text = null;
            txtProductName.Text = null;
            cboProductCondition.Text = null;
            MainTabController.SelectedIndex = 1;
        }

        private void btnSupplierAdd_Click(object sender, EventArgs e)
        {
            var result = _supplierController.Create(ReadSupplierForm());

            if (result.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result));
            }

            lstSuppliers.DataSource = _supplierController.Read();
        }

        private void btnSupplierEdit_Click(object sender, EventArgs e)
        {
            var result = _supplierController.Update(ReadSupplierForm());

            if (result.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result));
            }

            lstSuppliers.DataSource = _supplierController.Read();
        }

        private void btnSupplierDelete_Click(object sender, EventArgs e)
        {
            var result = _supplierController.Delete(lstSuppliers.SelectedItem as Supplier);

            if (!result)
            {
                MessageBox.Show("Could not Delete Selected Supplier");
            }

            lstSuppliers.DataSource = _supplierController.Read();
        }

        private void lstSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var supplier = lstSuppliers.SelectedItem as Supplier;

            txtSupplierFirstname.Text = supplier.Firstname;
            txtSupplierLastname.Text = supplier.Lastname;
            txtSupplierCommission.Text = (supplier.Commission * 100) + "%";
            txtSupplierStreet.Text = supplier.Address.Street;
            txtSupplierZip.Text = supplier.Address.Zip;
            txtSupplierCity.Text = supplier.Address.City;
            txtSupplierCountry.Text = supplier.Address.Country;
            txtSupplierEmail.Text = supplier.Email;
            txtSupplierPhoneNumber.Text = supplier.Phone;
        }

        private void lstSuppliers_Format(object sender, ListControlConvertEventArgs e)
        {
            string supplierId = ((Supplier)e.ListItem).Id.ToString();
            string supplierFirstname = ((Supplier)e.ListItem).Firstname;
            string supplierLastname = ((Supplier)e.ListItem).Lastname;

            e.Value = "[" + supplierId + "] " + supplierFirstname + " " + supplierLastname;
        }

        #endregion

        #region - Product Tab -

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            var result = _productController.Create(ReadProductForm());

            if (result.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result));
            }

            lstProducts.DataSource = _productController.Read();
        }
        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            var result = _productController.Update(ReadProductForm());

            if (result.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result));
            }

            lstProducts.DataSource = _productController.Read();
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            var result = _productController.Delete(lstProducts.SelectedItem as Product);

            if (!result)
            {
                MessageBox.Show("Could not Delete Selected Product");
            }

            lstProducts.DataSource = _productController.Read();
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var product = lstProducts.SelectedItem as Product;

            cboProductSupplier.SelectedValue = product.Supplier.Id;
            txtProductName.Text = product.Name;
            txtProductDescription.Text = product.Description;
            cboProductCondition.Text = product.Condition.ToString();
        }

        #endregion

        #region - Bidder Tab -

        private void btnBidderAdd_Click(object sender, EventArgs e)
        {
            var result = _bidderController.Create(ReadBidderForm());

            if (result.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result));
            }

            lstBidders.DataSource = _bidderController.Read();
        }

        private void btnBidderEdit_Click(object sender, EventArgs e)
        {
            var result = _bidderController.Update(ReadBidderForm());

            if (result.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result));
            }

            lstBidders.DataSource = _bidderController.Read();
        }

        private void btnBidderDelete_Click(object sender, EventArgs e)
        {
            var result = _bidderController.Delete(lstBidders.SelectedItem as Bidder);

            if (!result)
            {
                MessageBox.Show("Could not Delete Selected Product");
            }

            lstBidders.DataSource = _bidderController.Read();
        }

        private void lstBidders_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bidder = lstBidders.SelectedItem as Bidder;

            txtBidderFirstname.Text = bidder.Firstname;
            txtBidderLastname.Text = bidder.Lastname;
            txtBidderUsername.Text = bidder.Username;
            txtBidderStreet.Text = bidder.Address.Street;
            txtBidderZip.Text = bidder.Address.Zip;
            txtBidderCity.Text = bidder.Address.City;
            txtBidderCountry.Text = bidder.Address.Country;
            txtBidderEmail.Text = bidder.Email;
            txtBidderPhone.Text = bidder.Phone;
        }
        private void lstBidders_Format(object sender, ListControlConvertEventArgs e)
        {
            string bidderId = ((Bidder)e.ListItem).Id.ToString();
            string bidderFirstname = ((Bidder)e.ListItem).Firstname;
            string bidderLastname = ((Bidder)e.ListItem).Lastname;

            e.Value = "[" + bidderId + "] " + bidderFirstname + " " + bidderLastname;
        }

        #endregion

        #region - Auction Tab -

        private void lstAuctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var auction = lstAuctions.SelectedItem as Auction;

            lblAuctionBegin.Text = "Start Date: " + auction.Startdate;
            lblAuctionEnd.Text = "End Date: " + auction.Enddate;
            lblAuctionName.Text = auction.Name;
            lblAuctionSupplier.Text = "Supplier: " + auction.Product.Supplier.Firstname;
            lblAuctionStartPrice.Text = "OpeningPrice: " + auction.Startprice + "SEK";

            lstAuctionBids.DataSource = auction.Bids.ToList();
            lstAuctionBids.DisplayMember = "Date";
            lstAuctionBids.ValueMember = "BidderId";
        }

        private void cboAuctionSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            var supplier = cboAuctionSupplier.SelectedItem as Supplier;

            cboAuctionProduct.DataSource = supplier.Product.ToList();
            cboAuctionProduct.DisplayMember = "Name";
            cboAuctionProduct.ValueMember = "Id";
        }
        private void lstAuctionBids_Format(object sender, ListControlConvertEventArgs e)
        {
            string bidderFirstname = ((Bids)e.ListItem).Bidder.Firstname;
            string bidderLastname = ((Bids)e.ListItem).Bidder.Lastname;
            string bid = ((Bids)e.ListItem).Price.ToString();
            string date = ((Bids)e.ListItem).Date.ToString();

            e.Value = bid + "SEK | " + bidderFirstname + " " + bidderLastname + " | " + date;
        }
        private void btnAuctionCreate_Click(object sender, EventArgs e)
        {
            var result = _auctionController.Create(ReadAuctionForm());

            if (result.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result));
            }

            lstAuctions.DataSource = _auctionController.Read();
        }

        #endregion

        #region - Report Tab -

        private void btnReportCreate_Click(object sender, EventArgs e)
        {
            var startDate = dtpReportStart.Value;
            var endDate = dtpReportEnd.Value;
            var reportHandler = new ReportHandler();

            if (cboReports.Text == "Monthly Revenue")
            {
                lstReport.DataSource = reportHandler.MonthlyRevenue(startDate, endDate);
            }
            else if (cboReports.Text == "Bidder Report")
            {
                dgvReport.DataSource = reportHandler.BidderReport();
            }
            else if (cboReports.Text == "Ending Auctions Report")
            {
                //dgvReport.DataSource = reportHandler.EndingAuctionsReport(startDate, endDate);
            }
        }



        #endregion

        #region - FormData -
        private void PopulateFormWithData()
        {
            dtpReportStart.Value = dtpReportEnd.Value.AddYears(-1);
            dtpAuctionEnd.Value = dtpAuctionStart.Value.AddDays(14);

            lstAuctions.DataSource = _auctionController.Read();
            lstAuctions.DisplayMember = "Name";
            lstAuctions.ValueMember = "Id";

            var supplierDataSource = _supplierController.Read();

            lstSuppliers.DataSource = supplierDataSource;
            lstSuppliers.DisplayMember = "Firstname";
            lstSuppliers.ValueMember = "Id";

            cboAuctionSupplier.DataSource = supplierDataSource;
            cboAuctionSupplier.DisplayMember = "Firstname";
            cboAuctionSupplier.ValueMember = "Id";

            cboProductSupplier.DataSource = supplierDataSource;
            cboProductSupplier.DisplayMember = "Firstname";
            cboProductSupplier.ValueMember = "Id";

            lstProducts.DataSource = _productController.Read();
            lstProducts.DisplayMember = "Name";
            lstProducts.ValueMember = "Id";

            lstBidders.DataSource = _bidderController.Read();
            lstBidders.DisplayMember = "Firstname";
            lstBidders.ValueMember = "Id";

            cboProductCondition.DataSource = Enum.GetValues(typeof(Conditions));
        }
        private Supplier ReadSupplierForm()
        {
            var address = new Address
            {
                Street = txtSupplierStreet.Text,
                Zip = txtSupplierZip.Text,
                City = txtSupplierCity.Text,
                Country = txtSupplierCountry.Text
            };

            var comission = decimal.Parse(txtSupplierCommission.Text.Substring(0, txtSupplierCommission.Text.IndexOf('%') - 1));
            return new Supplier
            {
                Id = (int)lstSuppliers.SelectedValue,
                Firstname = txtSupplierFirstname.Text,
                Lastname = txtSupplierLastname.Text,
                Commission = comission / 100,
                Email = txtSupplierEmail.Text,
                Phone = txtSupplierPhoneNumber.Text,
                Address = address
            };
        }
        private Product ReadProductForm()
        {
            return new Product
            {
                Id = (int)lstProducts.SelectedValue,
                SupplyId = (int)lstProducts.SelectedValue,
                Name = txtProductName.Text,
                Description = txtProductDescription.Text,
                Condition = (Conditions)cboProductCondition.SelectedItem,
            };
        }

        private Bidder ReadBidderForm()
        {
            var address = new Address
            {
                Street = txtBidderStreet.Text,
                Zip = txtBidderZip.Text,
                City = txtBidderCity.Text,
                Country = txtBidderCountry.Text
            };
            return new Bidder
            {
                Id = (int)lstBidders.SelectedValue,
                Firstname = txtBidderFirstname.Text,
                Lastname = txtBidderLastname.Text,
                Username = txtBidderUsername.Text,
                Email = txtBidderEmail.Text,
                Phone = txtBidderPhone.Text,
                Address = address
            };
        }

        private Auction ReadAuctionForm()
        {
            return new Auction
            {
                ProductId = (int)cboAuctionProduct.SelectedValue,
                Name = txtAuctionName.Text,
                Startprice = decimal.Parse(txtAuctionOpeningPrice.Text),
                BuyNow = decimal.Parse(txtAuctionBuyNow.Text),
                Startdate = dtpAuctionStart.Value,
                Enddate = dtpAuctionEnd.Value
            };
        }

        #endregion
    }
}