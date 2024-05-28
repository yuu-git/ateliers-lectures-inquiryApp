using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ateliers.Lectures.InquiryApp.Models;
using Ateliers.Lectures.InquiryApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace Ateliers.Lectures.InquiryApp.Controllers
{
    /// <summary>
    /// 問い合わせの管理を行うコントローラーです。
    /// </summary>
    [Authorize]
    public class InquiryManagementController : Controller
    {
        private readonly IInquiryDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"> 問い合わせのデータベースコンテキスト </param>
        public InquiryManagementController(IInquiryDbContext context)
        {
            _context = context;
        }

        // GET: InquiryManagement
        /// <summary>
        /// すべての問い合わせを取得して表示します。
        /// </summary>
        /// <returns>問い合わせの一覧を含むビュー</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inquiries.ToListAsync());
        }

        // GET: InquiryManagement/Details/5
        /// <summary>
        /// 指定されたIDの問い合わせの詳細を表示します。
        /// </summary>
        /// <param name="id">問い合わせのID</param>
        /// <returns>問い合わせの詳細を含むビュー</returns>
        public async Task<IActionResult> Details(int id)
        {
            var inquiry = await _context.Inquiries
                .Include(i => i.InquiryItems)
                .Include(i => i.FoundOutMethods)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (inquiry == null)
            {
                return NotFound();
            }

            return View(inquiry);
        }
    }
}
