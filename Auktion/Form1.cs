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
        public Form1()
        {
            _auctionController = new AuctionController();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateFormWithData();
        }

        private void PopulateFormWithData()
        {
            lstAuctions.DataSource = _auctionController.Read();
            lstAuctions.DisplayMember = "Name";
            lstAuctions.ValueMember = "Id";
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
            lblAuctionName.Text = auction.Product.Name;
            lblAuctionSupplier.Text = "Supplier: " + auction.Product.Supplier.Name;
            lblAuctionStartPrice.Text = "OpeningPrice: " + auction.Startprice + "SEK";
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
    }
}
