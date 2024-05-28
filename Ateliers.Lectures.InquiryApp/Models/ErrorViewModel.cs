namespace Ateliers.Lectures.InquiryApp.Models
{
    /// <summary>
    /// エラービューモデルクラス
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// リクエストID
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// リクエストIDの表示可否
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
