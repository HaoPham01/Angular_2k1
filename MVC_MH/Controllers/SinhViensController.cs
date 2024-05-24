using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_MH.Data;


namespace MVC_MH.Controllers
{
    public class SinhViensController : Controller
    {
        private readonly QlsvContext _context;

        public SinhViensController(QlsvContext context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { set; get; }
        public string ErrorMessage { set; get; }
        // GET: SinhViens
        public IActionResult Index(string searchString, int? page)
        {
            ViewData["CurrentFilter"] = searchString;

            var sinhViens = from sv in _context.SinhViens
                            select sv;

            if (!string.IsNullOrEmpty(searchString))
            {
                sinhViens = sinhViens.Where(sv => sv.MaSv.Contains(searchString));
            }

            int pageSize = 5; // Số lượng mục trên mỗi trang
            int pageNumber = (page ?? 1); // Trang hiện tại (nếu không được chỉ định, mặc định là trang 1)

            var pagedSinhViens = sinhViens.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)sinhViens.Count() / pageSize);
            ViewBag.CurrentPage = pageNumber;

            return View(pagedSinhViens);
        }

        // GET: SinhViens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("MaSv,HoTen,NamSinh,DiaChi,Email,Sdt")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                StatusMessage = "Thêm thành công";
                return Redirect(Url.Action("Index", "SinhViens"));
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSv,HoTen,NamSinh,DiaChi,Email,Sdt")] SinhVien sinhVien)
        {
            if (id != sinhVien.MaSv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                    StatusMessage = "Thay đổi thành công";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSv))
                    {
                        ErrorMessage = "Thay đổi thất bại";
                        return NotFound();
                        
                    }
                    else
                    {
                        ErrorMessage = "Thay đổi thất bại";
                        throw;
                    }
                    
                }
                return Redirect(Url.Action("Index", "SinhViens"));
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhViens.Remove(sinhVien);
                StatusMessage = "Xóa thành công";
            }

            await _context.SaveChangesAsync();
            return Redirect(Url.Action("Index", "SinhViens"));
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhViens.Any(e => e.MaSv == id);
        }
    }
}
