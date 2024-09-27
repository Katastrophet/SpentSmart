using Microsoft.AspNetCore.Mvc;
using SpentSmart.Models;
using System.Diagnostics;

namespace SpentSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SpentSmartDbContext _context;

        public HomeController(ILogger<HomeController> logger, SpentSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            return View(allExpenses);
        }

        public IActionResult CreateEditExpense(int? id)
        {   
            // saved upon form submission in CreateEditExpenseForm
            if(id == null)
            {
                return View();
            } else
            {
                var expense = _context.Expenses.Find(id);
                if(expense == null) {
                    return NotFound();
                } else {
                    return View(expense);
                }
            }
        }

        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            if(expense == null) {
                return NotFound();
            } else {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
                return RedirectToAction("Expenses");
            }
        }

        public IActionResult CreateEditExpenseForm(Expense expense) 
        { 
            if(expense.Id != 0)
            {
                _context.Expenses.Update(expense);
            } else {
                _context.Expenses.Add(expense);
            }
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
