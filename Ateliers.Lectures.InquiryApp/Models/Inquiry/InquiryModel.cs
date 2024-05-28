using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ateliers.Lectures.InquiryApp.Models.Inquiry
{
    /// <summary>
    /// お問い合わせフォームを表すクラスです。
    /// </summary>
    [Tags("Inquiry")]
    public class InquiryModel
    {
        /// <summary>
        /// お問い合わせの一意の識別子を取得または設定します。
        /// </summary>
        [Key]
        public int Id { get; set; } = 0;

        /// <summary>
        /// お問い合わせ項目のリストを取得または設定します。
        /// </summary>
        [Required]
        public ICollection<InquiryItem> InquiryItems { get; set; } = new List<InquiryItem>();

        /// <summary>
        /// お問い合わせを行った人の名前を取得または設定します。
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// お問い合わせを行った人のメールアドレスを取得または設定します。
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// お問い合わせを行った人の電話番号を取得または設定します。
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// お問い合わせを行った人の会社名を取得または設定します。
        /// </summary>
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// お問い合わせを行った人の所属部署を取得または設定します。
        /// </summary>
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// お問い合わせを知った方法を取得または設定します。
        /// </summary>
        public ICollection<FoundOutMethod> FoundOutMethods { get; set; } = new List<FoundOutMethod>();

        /// <summary>
        /// お問い合わせの内容を取得または設定します。
        /// </summary>
        [Required]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// お問い合わせが作成された日時を取得または設定します。
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
