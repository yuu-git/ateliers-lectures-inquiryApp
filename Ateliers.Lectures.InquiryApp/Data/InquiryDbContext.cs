using Ateliers.Lectures.InquiryApp.Data;
using Ateliers.Lectures.InquiryApp.Migrations;
using Ateliers.Lectures.InquiryApp.Models.Inquiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ateliers.Lectures.InquiryApp.Models
{
    /// <summary>
    /// 問い合わせデータベースコンテキストクラス
    /// </summary>
    public class InquiryDbContext : DbContext, IInquiryDbContext
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="options"> DBオプション </param>
        public InquiryDbContext(DbContextOptions<InquiryDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// 問い合わせモデルのデータセット
        /// </summary>
        public DbSet<InquiryModel> Inquiries { get; set; }

        /// <summary>
        /// 問い合わせ項目のデータセット
        /// </summary>
        public DbSet<InquiryItem> InquiryItems { get; set; }

        /// <summary>
        /// 見つけ出した方法のデータセット
        /// </summary>
        public DbSet<FoundOutMethod> FoundOutMethods { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ReplaceService<IMigrationsIdGenerator, CustomMigrationsIdGenerator>();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InquiryModel>()
                .HasMany(i => i.InquiryItems)
                .WithOne(ii => ii.Inquiry)
                .HasForeignKey(ii => ii.InquiryId);

            modelBuilder.Entity<InquiryModel>()
                .HasMany(i => i.FoundOutMethods)
                .WithOne(fm => fm.Inquiry)
                .HasForeignKey(fm => fm.InquiryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
