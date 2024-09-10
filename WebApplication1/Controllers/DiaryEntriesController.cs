using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            List<DiaryEntry> entries = _db.DiaryEntries.ToList();
            return View(entries);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DiaryEntry obj)
        {
            _db.DiaryEntries.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if(diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DiaryEntry obj)
        {
            _db.DiaryEntries.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DiaryEntry obj)
        {
            _db.DiaryEntries.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
