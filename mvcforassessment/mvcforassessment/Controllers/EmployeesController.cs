using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcforassessment.Data;
using mvcforassessment.Models;
using X.PagedList;


namespace mvcforassessment.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employee.Include(e => e.department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.department)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        //seraching--------------------------------------------------------------------------
        //--------------------------------------------------------------------
        public IActionResult search()
        {
            var data = _context.Employee.ToList();
            return View(data);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult search(IFormCollection form)
        {
            var fieldname = form["FieldName"].ToString();
            var keyword = form["keyword"].ToString();
            IList<Employee> employees = new List<Employee>();
            switch (fieldname)
            {
                case "EmpId":
                    var empid = int.Parse(keyword);
                    employees = _context.Employee.Where(d => d.EmpId.Equals(empid)).ToList();
                    break;
                case "EmpName":

                    employees = _context.Employee.Where(d => d.EmpName.StartsWith(keyword)).ToList();
                    break;
                case "City":

                    employees = _context.Employee.Where(d => d.City.StartsWith(keyword)).ToList();
                    break;

            }
            return View(employees);
        }
        //paging--------------------------------------------------------
        public async Task<IActionResult> Paging(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 4;

            var data = _context.Employee.OrderBy(e => e.EmpId).ToPagedList(pageNumber, pageSize);
            return View(data);
        }
        //rawquery
        public IActionResult rawquery(int id)
        {
            var sql = "Select *FROM EMPLOYEE";
            var data = _context.Employee.FromSqlRaw(sql, id).ToList();
            return View(data);
        }





        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Set<Department>(), "DeptId", "DeptId");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpName,City,Salary,DeptId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Set<Department>(), "DeptId", "DeptId", employee.DeptId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Set<Department>(), "DeptId", "DeptId", employee.DeptId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,EmpName,City,Salary,DeptId")] Employee employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Set<Department>(), "DeptId", "DeptId", employee.DeptId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.department)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmpId == id);
        }
    }
}
