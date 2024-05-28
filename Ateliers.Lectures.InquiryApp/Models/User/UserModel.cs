using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ateliers.Lectures.InquiryApp.Models.User
{
    /// <summary>
    /// ユーザーモデルクラス
    /// </summary>
    [Table("Users")]
    public class UserModel
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// ユーザー名
        /// </summary>
        [Required(ErrorMessage = "ユーザー名を入力してください")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ユーザー名は3文字以上50文字以下で入力してください")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// パスワード
        /// </summary>
        [NotMapped]
        [Required(ErrorMessage = "パスワードを入力してください")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "パスワードは6文字以上100文字以下で入力してください")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 確認パスワード
        /// </summary>
        [NotMapped]
        [Required(ErrorMessage = "確認パスワードを入力してください")]
        [Compare("Password", ErrorMessage = "パスワードと確認パスワードが一致しません")]
        public string ConfirmPassword { get; set; } = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        [Required(ErrorMessage = "メールアドレスを入力してください")]
        [EmailAddress(ErrorMessage = "無効なメールアドレス形式です")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// パスワードハッシュ
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;
    }
}
