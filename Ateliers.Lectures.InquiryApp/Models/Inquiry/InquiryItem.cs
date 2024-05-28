using System.ComponentModel.DataAnnotations;

namespace Ateliers.Lectures.InquiryApp.Models.Inquiry
{
    /// <summary>
    /// 問い合わせ項目クラス
    /// </summary>
    public class InquiryItem
    {
        /// <summary>
        /// 項目ID
        /// </summary>
        [Key]
        public int Id { get; set; } = 0;

        /// <summary>
        /// 項目名
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 問い合わせID
        /// </summary>
        public int InquiryId { get; set; } = 0;

        /// <summary>
        /// 問い合わせエンティティ
        /// </summary>
        public InquiryModel Inquiry { get; set; } = null!;
    }
}
