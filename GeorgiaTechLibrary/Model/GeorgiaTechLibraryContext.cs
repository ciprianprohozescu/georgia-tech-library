using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GeorgiaTechLibrary.Model
{
    public partial class GeorgiaTechLibraryContext : DbContext
    {
        public GeorgiaTechLibraryContext()
        {
        }

        public GeorgiaTechLibraryContext(DbContextOptions<GeorgiaTechLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Volume> Volumes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=GeorgiaTechLibrary;User Id=SA;Password=PeStIsOrI@#2;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apartment).HasColumnName("apartment");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Minit)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("minit");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Binding)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("binding");

                entity.Property(e => e.CanLend).HasColumnName("can_lend");

                entity.Property(e => e.Edition).HasColumnName("edition");

                entity.Property(e => e.IsInteresting).HasColumnName("is_interesting");

                entity.Property(e => e.Language)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("language");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId })
                    .HasName("PK__BookAuth__A1680C5D4CD42B3A");

                entity.ToTable("BookAuthor");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookAutho__autho__7D439ABD");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookAutho__book___7C4F7684");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.ToTable("Library");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Agreement)
                    .HasColumnType("text")
                    .HasColumnName("agreement");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.VolumeId, e.BookId })
                    .HasName("PK__Loan__2E9858D5265A928F");

                entity.ToTable("Loan");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.VolumeId).HasColumnName("volume_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.Property(e => e.LoanDate)
                    .HasColumnType("date")
                    .HasColumnName("loan_date");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("date")
                    .HasColumnName("return_date");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__member_id__00200768");

                entity.HasOne(d => d.Volume)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => new { d.VolumeId, d.BookId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__01142BA1");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.HasIndex(e => e.Ssn, "UQ__Member__DDDF0AE62A5FE239")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CampusAddressId).HasColumnName("campus_address_id");

                entity.Property(e => e.CardExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("card_expiry_date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("date")
                    .HasColumnName("entry_date");

                entity.Property(e => e.Fname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Minit)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("minit");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PrivateAddressId).HasColumnName("private_address_id");

                entity.Property(e => e.Ssn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ssn");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.HasOne(d => d.CampusAddress)
                    .WithMany(p => p.MemberCampusAddresses)
                    .HasForeignKey(d => d.CampusAddressId)
                    .HasConstraintName("FK__Member__campus_a__6E01572D");

                entity.HasOne(d => d.PrivateAddress)
                    .WithMany(p => p.MemberPrivateAddresses)
                    .HasForeignKey(d => d.PrivateAddressId)
                    .HasConstraintName("FK__Member__private___6EF57B66");
            });

            modelBuilder.Entity<Volume>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.BookId })
                    .HasName("PK__Volume__36833991BCD20659");

                entity.ToTable("Volume");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.AcquiryDate)
                    .HasColumnType("date")
                    .HasColumnName("acquiry_date");

                entity.Property(e => e.SourceLibraryId).HasColumnName("source_library_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Volumes)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volume__book_id__787EE5A0");

                entity.HasOne(d => d.SourceLibrary)
                    .WithMany(p => p.Volumes)
                    .HasForeignKey(d => d.SourceLibraryId)
                    .HasConstraintName("FK__Volume__source_l__797309D9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
