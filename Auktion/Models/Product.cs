namespace Auktion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public enum Conditions
    {
        New,
        Used,
        Old,
        Broken
    }
    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Auction = new HashSet<Auction>();
            AuctionHistory = new HashSet<AuctionHistory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public Conditions Condition { get; set; }

        public int? SupplyId { get; set; }

        public byte[] Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auction> Auction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuctionHistory> AuctionHistory { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
