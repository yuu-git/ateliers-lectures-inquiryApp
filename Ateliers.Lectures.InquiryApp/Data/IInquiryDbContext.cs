using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;
using Ateliers.Lectures.InquiryApp.Models.Inquiry;

namespace Ateliers.Lectures.InquiryApp.Data
{
    /// <summary>
    /// 問い合わせデータベースコンテキストのインターフェース
    /// </summary>
    public interface IInquiryDbContext
    {
        /// <summary>
        /// 問い合わせエンティティのセット
        /// </summary>
        DbSet<InquiryModel> Inquiries { get; set; }

        /// <summary>
        /// 問い合わせ項目エンティティのセット
        /// </summary>
        DbSet<InquiryItem> InquiryItems { get; set; }

        /// <summary>
        /// 問い合わせ項目選択肢エンティティのセット
        /// </summary>
        DbSet<FoundOutMethod> FoundOutMethods { get; set; }

        /// <summary>
        /// 変更を非同期で保存する
        /// </summary>
        /// <param name="cancellationToken"> (任意) キャンセルトークン</param>
        /// <returns>非同期操作の結果を表すタスク</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 指定されたエンティティの状態を追跡する
        /// </summary>
        /// <param name="entity">追跡するエンティティ</param>
        /// <returns>エンティティのエントリ</returns>
        EntityEntry Entry(object entity);
    }
}