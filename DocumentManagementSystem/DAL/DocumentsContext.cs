namespace DocumentManagementSystem.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DocumentManagementSystem.DAL.Models;
    using DocumentManagementSystem.DAL.Views;

    public partial class DocumentsContext : DbContext
    {
        public DocumentsContext()
            : base("name=Documents")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentView> DocumentView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Document)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentView>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentView>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentView>()
                .Property(e => e.url)
                .IsUnicode(false);
        }
    }
}
