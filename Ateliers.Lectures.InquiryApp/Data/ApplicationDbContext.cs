using Ateliers.Lectures.InquiryApp.Migrations;
using Ateliers.Lectures.InquiryApp.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ateliers.Lectures.InquiryApp.Data
{
    /// <summary>
    /// アプリケーションのデータベースコンテキストを表すクラスです。
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        /// <summary>
        /// ApplicationDbContext クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="options">データベースコンテキストのオプション。</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// ユーザーモデルのデータセット。
        /// </summary>
        public DbSet<UserModel> Users { get; set; }

        /// <summary>
        /// DbContext の設定をカスタマイズします。
        /// </summary>
        /// <param name="optionsBuilder">DbContext のオプションビルダー。</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ReplaceService<IMigrationsIdGenerator, CustomMigrationsIdGenerator>();
        }
    }
}
