using Ateliers.Lectures.InquiryApp.Models;
using Ateliers.Lectures.InquiryApp.Models.User;

/// <summary>
/// 認証サービスクラス
/// </summary>
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="userRepository"> ユーザーリポジトリ </param>
    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// ユーザーを検証します。
    /// </summary>
    /// <param name="username">ユーザー名</param>
    /// <param name="password">パスワード</param>
    /// <returns>検証結果</returns>
    public bool ValidateUser(string username, string password)
    {
        var user = _userRepository.GetByUsername(username);
        if (user == null)
        {
            Console.WriteLine("ユーザーが見つかりませんでした。");
            return false;
        }

        // パスワードの検証ロジック（ハッシュの比較）
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        Console.WriteLine($"パスワードが正しいかどうか: {isPasswordValid}");
        return isPasswordValid;
    }

    /// <summary>
    /// ユーザーを登録します。
    /// </summary>
    /// <param name="username">ユーザー名</param>
    /// <param name="password">パスワード</param>
    /// <param name="email">メールアドレス</param>
    /// <returns>登録されたユーザー数</returns>
    public async Task<int> RegisterUserAsync(string username, string password, string email)
    {
        try
        {
            // パスワードのハッシュ化
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new UserModel
            {
                Username = username,
                PasswordHash = passwordHash,
                Email = email
            };

            var result = await _userRepository.CreateAsync(user);
            Console.WriteLine("ユーザーが正常に登録されました。");

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ユーザーの登録中にエラーが発生しました: {ex.Message}");
            throw;
        }
    }
}
