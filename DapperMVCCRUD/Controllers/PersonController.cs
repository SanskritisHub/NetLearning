using DapperMVCCRUD.Data.Models.Domain;
using DapperMVCCRUD.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperMVCCRUD.UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepo;
        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;   
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(person);
                bool addPersonResult = await _personRepo.AddAsync(person);
                if(addPersonResult)
                    TempData["msg"] = "Success";
                else
                    TempData["msg"] = "Failure";
            }
            catch(Exception ex)
            {
                TempData["msg"] = "Failure";
            }
            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            return View();
        }


        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personRepo.GetByIdAsync(id);
            return View(person);
        }

        public async Task<IActionResult> DisplayAll()
        {
            var people = await _personRepo.GetAllAsync();
            return View(people);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleteResult = await _personRepo.DeleteAsync(id);
            return RedirectToAction(nameof(DisplayAll));
        }
    }
}
