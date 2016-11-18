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

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? ProductId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Startdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Enddate { get; set; }

        public decimal Startprice { get; set; }

        public decimal BuyNow { get; set; }

        public decimal FinalBid { get; set; }

        public int FinalBidderId { get; set; }

        public virtual Bidder Bidder { get; set; }

        public virtual Product Product { get; set; }
    }
}
