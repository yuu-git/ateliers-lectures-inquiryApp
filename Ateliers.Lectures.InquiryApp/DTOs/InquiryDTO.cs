namespace Ateliers.Lectures.InquiryApp.DTOs
{
    /// <summary>
    /// 問い合わせDTOクラス
    /// </summary>
    public class InquiryDTO
    {
        /// <summary>
        /// 問い合わせ項目リスト
        /// </summary>
        public List<string> InquiryItems { get; set; } = new List<string>();

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 電話番号
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// 会社名
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// 部署
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// 知った方法リスト
        /// </summary>
        public List<string> FoundOutMethods { get; set; } = new List<string>();

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; } = string.Empty;
    }
}
