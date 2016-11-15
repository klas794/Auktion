namespace Auktion
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

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Auction> Auction { get; set; }
        public virtual DbSet<AuctionHistory> AuctionHistory { get; set; }
        public virtual DbSet<Bidder> Bidder { get; set; }
        public virtual DbSet<Bids> Bids { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.Zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Bidder)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Supplier)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Auction>()
                .Property(e => e.Startprice)
                .HasPrecision(38, 2);

            modelBuilder.Entity<Auction>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Auction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AuctionHistory>()
                .Property(e => e.Startprice)
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
                .Property(e => e.Zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bidder>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Bidder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bids>()
                .Property(e => e.Price)
                .HasPrecision(38, 2);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.SupplyId);
        }
    }
}
