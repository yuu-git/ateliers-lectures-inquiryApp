namespace Ateliers.Lectures.InquiryApp.Models
{
    /// <summary>
    /// �G���[�r���[���f���N���X
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// ���N�G�X�gID
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// ���N�G�X�gID�̕\����
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
