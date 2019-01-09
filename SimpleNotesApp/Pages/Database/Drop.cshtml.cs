using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleNotesApp.Data;
using SimpleNotesApp.Models;

namespace SimpleNotesApp.Pages.Database
{
    public class DropModel : PageModel
    {
        private SimpleNotesAppDbContext _context;

        public DropModel(SimpleNotesAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var notes = _context.Set<Note>();

            _context.Notes.RemoveRange(notes);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}