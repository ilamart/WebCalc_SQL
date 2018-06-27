using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Threading.Tasks;
using AppCalculate;
using System;

namespace WebApplication1.Pages.History
{
    public class IndexModel : PageModel
    {
        private readonly HistoryContext _context;
        public List<Note> History { get; set; }

        public IndexModel(HistoryContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            History = _context.History.AsNoTracking().ToList();
        }

        [BindProperty]
        public Note Note { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Note.Host = "1.1.1.1";
                StringCalc Calc = new StringCalc();
                Note.Result = Calc.DoCalculation(Note.Expression).ToString();
                DateTime myDateTime = DateTime.Now;
                Note.CreatedDateTime = myDateTime;
                _context.History.Add(Note);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}