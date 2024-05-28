using System.ComponentModel.DataAnnotations;

namespace Ateliers.Lectures.InquiryApp.Models.Inquiry
{
    /// <summary>
    /// 見つけ出した方法クラス
    /// </summary>
    public class FoundOutMethod
    {
        /// <summary>
        /// 見つけ出した方法ID
        /// </summary>
        [Key]
        public int Id { get; set; } = 0;

        /// <summary>
        /// 見つけ出した方法の項目名
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// お問い合わせID
        /// </summary>
        public int InquiryId { get; set; } = 0;

        /// <summary>
        /// お問い合わせエンティティ
        /// </summary>
        public InquiryModel Inquiry { get; set; } = null!;
    }
}
