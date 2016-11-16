using Auktion.Controllers;
using Auktion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MainTabController.SelectedIndex = 1;
        }

        private void btnSupplierAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSupplierEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSupplierDelete_Click(object sender, EventArgs e)
        {

        }

        private void lstSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var supplier = lstSuppliers.SelectedItem as Supplier;

            txtSupplierFirstname.Text = supplier.Firstname;
            txtSupplierLastname.Text = supplier.Lastname;
            txtSupplierCommision.Text = (supplier.Commission * 100) + "%";
            //txtSupplierStreet.Text = supplier.Address.Streeet;
            txtSupplierZip.Text = supplier.Address.Zip;
            txtSupplierCity.Text = supplier.Address.City;
            //txtSupplierCountry.Text = supplier.Address.Country;
            txtSupplierEmail.Text = supplier.Email;
            txtSupplierPhoneNumber.Text = supplier.Phone;
        }

        #endregion

        #region - Product Tab -

        private void btnProductAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {

        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var product = lstProducts.SelectedItem as Product;

            txtProductName.Text = product.Name;
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {

        }

        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region - Auctions -

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

        private void btnAuctionCreate_Click(object sender, EventArgs e)
        {
            var result = _auctionController.Create(new Auction
            {
                ProductId = 1,
                Name = txtAuctionName.Text,
                Startdate = dtpAuctionStart.Value,
                Enddate = dtpAuctionEnd.Value,
                Startprice = decimal.Parse(txtAuctionOpeningPrice.Text),
                BuyNow = decimal.Parse(txtAuctionBuyNow.Text),
            });
        }

        #endregion

        #region - Reports -

        private void btnReportCreate_Click(object sender, EventArgs e)
        {
            var startDate = dtpReportStart.Value;
            var endDate = dtpReportEnd.Value;
            var reportHandler = new ReportHandler();

            if (cboReports.Text == "Sales Report")
            {
                //reportHandler.SalesReport(startDate, endDate);
            }
            else if (cboReports.Text == "Customer Report")
            {
                dgvReport.DataSource = reportHandler.CustomerReport(startDate, endDate);
            }
            else if (cboReports.Text == "Ending Auctions Report")
            {
                //dgvReport.DataSource = reportHandler.EndingAuctionsReport(startDate, endDate);
            }
        }

        #endregion

        private void lstAuctionBids_Format(object sender, ListControlConvertEventArgs e)
        {
            string bidderFirstname = ((Bids)e.ListItem).Bidder.Firstname;
            string bidderLastname = ((Bids)e.ListItem).Bidder.Lastname;
            string bid = ((Bids)e.ListItem).Price.ToString();
            string date = ((Bids)e.ListItem).Date.ToString();

            e.Value = bid + "SEK | " + bidderFirstname + " " + bidderLastname + " | " + date;
        }

        private void lstBidders_Format(object sender, ListControlConvertEventArgs e)
        {
            string bidderId = ((Bidder)e.ListItem).Id.ToString();
            string bidderFirstname = ((Bidder)e.ListItem).Firstname;
            string bidderLastname = ((Bidder)e.ListItem).Lastname;

            e.Value = "ID:" + bidderId + " | " + bidderFirstname + " " + bidderLastname;
        }

        private void PopulateFormWithData()
        {
            lstAuctions.DataSource = _auctionController.Read();
            lstAuctions.DisplayMember = "Name";
            lstAuctions.ValueMember = "Id";

            var supplierDataSource = _supplierController.Read();

            lstSuppliers.DataSource = supplierDataSource;
            lstSuppliers.DisplayMember = "Firstname";
            lstSuppliers.ValueMember = "Id";

            cboAuctionSupplier.DataSource = supplierDataSource;
            cboAuctionSupplier.DisplayMember = "Name";
            cboAuctionSupplier.ValueMember = "Id";

            cboProductSupplier.DataSource = supplierDataSource;
            cboProductSupplier.DisplayMember = "Name";
            cboProductSupplier.ValueMember = "Id";

            lstProducts.DataSource = _productController.Read();
            lstProducts.DisplayMember = "Name";
            lstProducts.ValueMember = "Id";

            lstBidders.DataSource = _bidderController.Read();
            lstBidders.DisplayMember = "Firstname";
            lstBidders.ValueMember = "Id";
        }
    }
}
