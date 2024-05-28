using Ateliers.Lectures.InquiryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ateliers.Lectures.InquiryApp.Controllers
{
    /// <summary>
    /// ホームコントローラークラス
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// HomeControllerのコンストラクタ
        /// </summary>
        /// <param name="logger">ロガー</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// インデックスアクション
        /// </summary>
        /// <returns>ビュー</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// エラーアクション
        /// </summary>
        /// <returns>ビュー</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
