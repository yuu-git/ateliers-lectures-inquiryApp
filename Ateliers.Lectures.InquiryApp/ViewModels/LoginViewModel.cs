using System.ComponentModel.DataAnnotations;

namespace Ateliers.Lectures.InquiryApp.ViewModels
{
    /// <summary>
    /// ログインビューモデル
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// ユーザー名
        /// </summary>
        [Required(ErrorMessage = "ユーザー名を入力してください")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ユーザー名は3文字以上50文字以下で入力してください")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// パスワード
        /// </summary>
        [Required(ErrorMessage = "パスワードを入力してください")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "パスワードは6文字以上100文字以下で入力してください")]
        public string Password { get; set; } = string.Empty;
    }
}
