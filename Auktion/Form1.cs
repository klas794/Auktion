﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void treAuctions_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnAuctionCreate_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region - Reports -

        private void btnReportCreate_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
