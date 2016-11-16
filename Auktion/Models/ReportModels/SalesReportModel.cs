using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktion.Models.ReportModels
{
    class SalesReportModel
    {
        public DateTime Date { get; set; }
        public string Auction { get; set; }
        public decimal Commission { get; set; }
    }
}
