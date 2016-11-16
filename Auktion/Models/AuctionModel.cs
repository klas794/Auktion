namespace Auktion.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AuctionModel : DbContext
    {
        public AuctionModel()
            : base("name=AuctionModel")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Auction> Auctions { get; set; }
        public virtual DbSet<AuctionHistory> AuctionHistories { get; set; }
        public virtual DbSet<Bidder> Bidders { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.Zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Bidders)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.AdressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Auction>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Auction>()
                .Property(e => e.Startprice)
                .HasPrecision(38, 2);

            modelBuilder.Entity<Auction>()
                .Property(e => e.BuyNow)
                .HasPrecision(38, 2);

            modelBuilder.Entity<Auction>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Auction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AuctionHistory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AuctionHistory>()
                .Property(e => e.Startprice)
                .HasPrecision(38, 2);

            modelBuilder.Entity<AuctionHistory>()
                .Property(e => e.BuyNow)
                .HasPrecision(38, 2);

            modelBuilder.Entity<AuctionHistory>()
                .Property(e => e.FinalBid)
                .HasPrecision(38, 2);

            modelBuilder.Entity<Bidder>()
                .Property(e => e.SSN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bidder>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bidder>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Bidder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bid>()
                .Property(e => e.Price)
                .HasPrecision(38, 2);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Commission)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.SupplyId);
        }
    }
}
