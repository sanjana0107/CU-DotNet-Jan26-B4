using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Data;
using StudentManagementMVC.ViewModel;
using StudentManagementMVC.Models;
using StudentManagementMVC.Services;

namespace StudentManagementMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentHttpService _service;


        public StudentController(StudentHttpService service)
        {
            _service = service; ;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            var students = JsonSerializer.Deserialize<IEnumerable<Student>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            return View(students);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _service.GetById(id ?? 0);
            var student = JsonSerializer.Deserialize<Student>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Age,Course")] StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _service.GetById(id ?? 0);
            var student = JsonSerializer.Deserialize<Student>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Course")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }
            await _service.Update(student);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _service.GetById(id ?? 0);
            var student = JsonSerializer.Deserialize<Student>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive=true}); 
            if (student == null)
            {                
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _service.GetById(id);
            var student = JsonSerializer.Deserialize<Student>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive=true});
            if (student != null)
            {
                await _service.Delete(student);
            }            
            return RedirectToAction(nameof(Index));
        }
      
    }
}
