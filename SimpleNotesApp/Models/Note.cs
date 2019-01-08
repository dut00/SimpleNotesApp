using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNotesApp.Models
{
    public class Note
    {
        public int Id { get; set; }

        //public int OwnerId { get; set; }

        [DisplayName("Title")]
        [MaxLength(20)]
        public string Title { get; set; }

        [DisplayName("Text")]
        public string Text { get; set; }

        [DisplayName("Link to picture")]
        public string LinkToPic { get; set; }

        [DisplayName("Tags")]
        public string Tags { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Background color")]
        [DefaultValue(0)]
        public BaseColors BackgroundColor { get; set; }
    }
}
