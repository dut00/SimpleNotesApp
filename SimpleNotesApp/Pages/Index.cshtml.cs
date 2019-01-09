using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleNotesApp.Data;
using SimpleNotesApp.Models;
using SimpleNotesApp.Services;

namespace SimpleNotesApp.Pages
{
    public class IndexModel : PageModel
    {
        private INoteData _noteData;
        private SimpleNotesAppDbContext _context;

        public IndexModel(INoteData noteData, SimpleNotesAppDbContext context)
        {
            _noteData = noteData;
            _context = context;
        }

        public IEnumerable<Note> Notes { get; set; }

        public IActionResult OnGet()
        {
            Notes = _noteData.GetAll();
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }


        // To żądanie uzupełnia formularz w modalu Edit (ajax)
        public IActionResult OnGetEditModalFormPartial(int id)
        {
            Note = _context.Notes.Find(id);
            return new PartialViewResult() { ViewName = "_EditModalFormPartial", ViewData = this.ViewData };
        }


        // Add note
        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (Note.Title == null &&
                Note.Text == null &&
                Note.LinkToPic == null &&
                Note.Tags == null)
            {
                //Notes = _noteData.GetAll();
                //return Page();
                return RedirectToPage("Index");
            }

            //Set note create date
            Note.CreatedDate = DateTime.Now;

            if (Note.Tags != null)
            {
                //Removes spaces from string
                Note.Tags = Note.Tags.Replace(" ", String.Empty);
                //Removes all commas from the beginning and end of a string
                Note.Tags = Note.Tags.TrimStart(',').TrimEnd(',');
                //Removes all duplicate commas
                Note.Tags = Regex.Replace(Note.Tags, ",{2,}", ",");
            }

            _context.Notes.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");

        }

        // Update note
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("./");  // ("Notes");
            }

            if (Note.Title == null &&
                Note.Text == null &&
                Note.LinkToPic == null &&
                Note.Tags == null)
            {
                //Notes = _noteData.GetAll();
                //return Page();
                return RedirectToPage("Index");
            }

            //Set note new create date?!
            //chyba powineniem przyjać inną nazwę np. ModificationDate??
            Note.CreatedDate = DateTime.Now;

            if (Note.Tags != null)
            {
                //Removes spaces from string
                Note.Tags = Note.Tags.Replace(" ", String.Empty);
                //Removes all commas from the beginning and end of a string
                Note.Tags = Note.Tags.TrimStart(',').TrimEnd(',');
                //Removes all duplicate commas
                Note.Tags = Regex.Replace(Note.Tags, ",{2,}", ",");
            }

            _noteData.Update(Note);
            
            return RedirectToPage("Index");
        }
     

        // Delete note
        [BindProperty]
        public int? NoteId { get; set; }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (NoteId == null)
            {
                return NotFound();
            }

            _noteData.Delete(NoteId.GetValueOrDefault());

            return RedirectToPage("Index");
        }
    }
}
