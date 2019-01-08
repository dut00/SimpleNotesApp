using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleNotesApp.Data;
using SimpleNotesApp.Models;

namespace SimpleNotesApp.Services
{
    public class SqlNoteData : INoteData
    {
        private SimpleNotesAppDbContext _context;

        public SqlNoteData(SimpleNotesAppDbContext context)
        {
            _context = context;
        }

        public Note Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChangesAsync();
            return note;
        }

        public void Delete(int id)
        {
            //Note Note = await _context.Notes.FindAsync(id);

            //if (Note != null)
            //{
            //    _context.Notes.Remove(Note);
            //    await _context.SaveChangesAsync();
            //}

            Note note = _context.Notes.FirstOrDefault(r => r.Id == id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public Note Get(int id)
        {
            return _context.Notes.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes.OrderBy(r => r.Id);
        }

        public Note Update(Note note)
        {
            _context.Attach(note).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return note;
        }
    }
}
