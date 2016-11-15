namespace Auktion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AuctionHistory")]
    public partial class AuctionHistory
    {
        public int Id { get; set; }

        public int? AuctionId { get; set; }

        public int? ProductId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Startdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Enddate { get; set; }

        public decimal Startprice { get; set; }

        public int BuyNow { get; set; }

        public virtual Auction Auction { get; set; }

        public virtual Product Product { get; set; }
    }
}
