using SimpleNotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNotesApp.Services
{
    public interface INoteData
    {
        IEnumerable<Note> GetAll();
        Note Get(int id);
        Note Add(Note note);
        void Delete(int id);
        Note Update(Note note);
    }
}
