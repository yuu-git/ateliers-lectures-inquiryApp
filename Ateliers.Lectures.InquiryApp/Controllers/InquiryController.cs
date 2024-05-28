using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ateliers.Lectures.InquiryApp.Models;
using Ateliers.Lectures.InquiryApp.Data;
using Ateliers.Lectures.InquiryApp.DTOs;
using Microsoft.AspNetCore.Authorization;
using Ateliers.Lectures.InquiryApp.Models.Inquiry;

namespace Ateliers.Lectures.InquiryApp.Controllers
{
    /// <summary>
    /// 問い合わせコントローラー
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly IInquiryDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"> 問い合わせDBコンテキスト </param>
        public InquiryController(IInquiryDbContext context)
        {
            _context = context;
        }

        // GET: api/Inquiry
        /// <summary>
        /// 全ての問い合わせを取得します。
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InquiryModel>>> GetInquiries()
        {
            return await _context.Inquiries.ToListAsync();
        }

        // GET: api/Inquiry/5
        /// <summary>
        /// 指定されたIDの問い合わせを取得します。
        /// </summary>
        /// <param name="id">問い合わせID</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<InquiryModel>> GetInquiry(int id)
        {
            var inquiry = await _context.Inquiries.FindAsync(id);

            if (inquiry == null)
            {
                return NotFound();
            }

            return inquiry;
        }

        // POST: api/Inquiry
        /// <summary>
        /// 問い合わせを作成します。
        /// </summary>
        /// <param name="inquiry">問い合わせオブジェクト</param>
        [HttpPost]
        public async Task<ActionResult<InquiryModel>> PostInquiry([FromBody] InquiryDTO inquiryModel)
        {
            if (ModelState.IsValid)
            {
                var inquiry = new InquiryModel
                {
                    Name = inquiryModel.Name,
                    Email = inquiryModel.Email,
                    PhoneNumber = inquiryModel.PhoneNumber,
                    CompanyName = inquiryModel.CompanyName,
                    Department = inquiryModel.Department,
                    Content = inquiryModel.Content,
                    CreatedAt = DateTime.Now,
                };

                foreach (var itemName in inquiryModel.InquiryItems)
                {
                    inquiry.InquiryItems.Add(new InquiryItem { Name = itemName });
                }

                foreach (var methodName in inquiryModel.FoundOutMethods)
                {
                    inquiry.FoundOutMethods.Add(new FoundOutMethod { Name = methodName });
                }

                _context.Inquiries.Add(inquiry);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "お問い合わせ内容を送信しました。" });
            }

            return BadRequest(new { success = false, message = "無効なデータです。" });
        }

        // PUT: api/Inquiry/5
        /// <summary>
        /// 指定されたIDの問い合わせを更新します。
        /// </summary>
        /// <param name="id">問い合わせID</param>
        /// <param name="inquiry">問い合わせオブジェクト</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInquiry(int id, [FromBody]InquiryModel inquiry)
        {
            if (id != inquiry.Id)
            {
                return BadRequest();
            }

            _context.Entry(inquiry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Inquiries.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Inquiry/5
        /// <summary>
        /// 指定されたIDの問い合わせを削除します。
        /// </summary>
        /// <param name="id">問い合わせID</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<InquiryModel>> DeleteInquiry(int id)
        {
            var inquiry = await _context.Inquiries.FindAsync(id);
            if (inquiry == null)
            {
                return NotFound();
            }

            _context.Inquiries.Remove(inquiry);
            await _context.SaveChangesAsync();

            return inquiry;
        }
    }
}
