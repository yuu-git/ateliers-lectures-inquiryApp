using Ateliers.Lectures.InquiryApp.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Ateliers.Lectures.InquiryApp.Data
{
    /// <summary>
    /// アプリケーションのデータベースコンテキストを表すインターフェースです。
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// ユーザーモデルのデータセットです。
        /// </summary>
        DbSet<UserModel> Users { get; set; }

        /// <summary>
        /// 非同期で変更を保存します。
        /// </summary>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>保存された変更の数</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 非同期で変更を保存します。
        /// </summary>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>保存された変更の数</returns>
        int SaveChanges();
    }
}
