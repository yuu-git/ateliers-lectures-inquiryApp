using Ateliers.Lectures.InquiryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ateliers.Lectures.InquiryApp.Controllers
{
    /// <summary>
    /// �z�[���R���g���[���[�N���X
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// HomeController�̃R���X�g���N�^
        /// </summary>
        /// <param name="logger">���K�[</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// �C���f�b�N�X�A�N�V����
        /// </summary>
        /// <returns>�r���[</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// �G���[�A�N�V����
        /// </summary>
        /// <returns>�r���[</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
