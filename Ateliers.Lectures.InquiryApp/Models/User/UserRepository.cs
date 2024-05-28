using Ateliers.Lectures.InquiryApp.Data;
using Ateliers.Lectures.InquiryApp.Models.User;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// UserRepositoryのコンストラクター
    /// </summary>
    /// <param name="context">ApplicationDbContextのインスタンス</param>
    public UserRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// ユーザー名によってユーザーモデルを取得します。
    /// </summary>
    /// <param name="username">ユーザー名</param>
    /// <returns>ユーザーモデル</returns>
    public UserModel GetByUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(username));
        }

        var user = _context.Users.SingleOrDefault(u => u.Username == username);

        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    /// <summary>
    /// ユーザーモデルを作成します。
    /// </summary>
    /// <param name="user">作成するユーザーモデル</param>
    public async Task<int> CreateAsync(UserModel user)
    {
        _context.Users.Add(user);
        return await _context.SaveChangesAsync();
    }
}
