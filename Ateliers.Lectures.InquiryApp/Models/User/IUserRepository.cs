using Microsoft.EntityFrameworkCore;

namespace Ateliers.Lectures.InquiryApp.Models.User
{
    /// <summary>
    /// ユーザーリポジトリ
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// ユーザー名によってユーザーを取得します。
        /// </summary>
        /// <param name="username">ユーザー名</param>
        /// <returns>指定されたユーザー名に対応するユーザー</returns>
        UserModel GetByUsername(string username);

        /// <summary>
        /// ユーザーを作成します。
        /// </summary>
        /// <param name="user">作成するユーザー</param>
        Task<int> CreateAsync(UserModel user);
    }

}