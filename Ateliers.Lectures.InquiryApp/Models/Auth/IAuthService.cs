using System;

/// <summary>
/// 認証サービスインターフェース
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// ユーザーを検証します。
    /// </summary>
    /// <param name="username">ユーザー名</param>
    /// <param name="password">パスワード</param>
    /// <returns>検証結果</returns>
    bool ValidateUser(string username, string password);

    /// <summary>
    /// ユーザーを登録します。
    /// </summary>
    /// <param name="username">ユーザー名</param>
    /// <param name="password">パスワード</param>
    /// <param name="email">メールアドレス</param>
    /// <returns>登録されたユーザー数</returns>
    Task<int> RegisterUserAsync(string username, string password, string email);
}
