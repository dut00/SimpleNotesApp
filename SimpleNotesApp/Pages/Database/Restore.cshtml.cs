using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleNotesApp.Data;
using SimpleNotesApp.Models;
using SimpleNotesApp.Services;

namespace SimpleNotesApp.Pages.Database
{
    public class RestoreModel : PageModel
    {
        private SimpleNotesAppDbContext _context;

        public RestoreModel(SimpleNotesAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            var notes = new List<Note> {
                new Note { Title = "Kosmos",
                            Text ="Wydajemy na to masę pieniędzy, a – rozglądając się wokoło – nie widać z tego żadnych korzyści.Po co latać w kosmos? Po co lądować na Marsie? Po co budować drogie teleskopy? No właśnie. Po co?",
                            LinkToPic ="https://wf4.xcdn.pl/files/15/04/14/999278_852786milkywaygalaxypic_83.jpg",
                            Tags ="spacex,nasa",
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.primary},
                new Note { Title = "Nr telefonu do banku",
                            Text ="800 302 302",
                            LinkToPic = null,
                            Tags ="pko",
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.info},
                new Note { Title = null,
                            Text = null,
                            LinkToPic ="http://bi.gazeta.pl/im/fe/90/14/z21563646V,Pies-nie-meczy-sie-bieganiem--ono-go-tylko-nakreca.jpg",
                            Tags = null,
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.white},
                new Note { Title = "Phase-shift keying",
                            Text = "PSK is a digital modulation process which conveys data by changing (modulating) the phase of a constant frequency reference signal (the carrier wave). The modulation is accomplished by varying the sine and cosine inputs at a precise time. It is widely used for wireless LANs, RFID and Bluetooth communication.",
                            LinkToPic = "https://upload.wikimedia.org/wikipedia/commons/a/a5/Pi-by-4-QPSK_Gray_Coded.svg",
                            Tags = "wiki",
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.info},
                new Note { Title = null,
                            Text ="Choose a job you love, and you will never have to work a day in your life",
                            LinkToPic =null,
                            Tags = "quote",
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.warning},
                new Note { Title = null,
                            Text =null,
                            LinkToPic ="https://img.grouponcdn.com/deal/3GEWaZtpETLkouh9o1muyihmUwX9/3G-2048x1229/v1/c700x420.jpg",
                            Tags = "Gdansk,dzwig,motlawa",
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.light},
                new Note { Title = null,
                            Text =null,
                            LinkToPic =null,
                            Tags = "to,tylko,tagi",
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.success},
                new Note { Title = "Boston dynamics",
                            Text ="",
                            LinkToPic ="https://i.blogs.es/956af6/spotmini/450_1000.jpg",
                            Tags = "creepy",
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.danger},
                new Note { Title = "The Beatless",
                            Text ="Lucy in the Sky with Diamonds",
                            LinkToPic =null,
                            Tags = null,
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.light},
                new Note { Title = "Lorem ipsum",
                            Text ="dolor sit amet tellus consectetuer ut, diam. Donec at lorem eu diam. Donec enim diam lorem, iaculis odio non nisl pellentesque ligula. Nam nunc ac turpis sed ipsum non porta urna. Phasellus sagittis malesuada. Etiam ornare facilisis urna viverra nunc. Donec rutrum consectetuer dignissim, lorem nec magna dolor, luctus at, quam. Pellentesque malesuada et, justo. Phasellus ut viverra pede porta nisl. Sed eget elit. Cum sociis natoque penatibus et malesuada velit libero fermentum sed, vehicula faucibus, fermentum sem ullamcorper orci vitae metus. Sed mattis. Aliquam luctus laoreet. Aenean et mauris nulla, convallis ac, eleifend adipiscing dolor gravida vitae, bibendum ac, laoreet urna.",
                            LinkToPic =null,
                            Tags = null,
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.dark},
                new Note { Title = "Kwas pantotenowy",
                            Text ="Organiczny związek chemiczny, bardzo rozpowszechniony w świecie roślinnym i zwierzęcym. Jest on niezbędny dla każdej żywej komórki, ale w stanie wolnym rzadko występuje w przyrodzie. Chemicznie kwas pantotenowy jest amidem kwasu pantoinowego i β-alaniny.",
                            LinkToPic ="https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/%28R%29-Pantothenic_acid_Formula_V.1.svg/1200px-%28R%29-Pantothenic_acid_Formula_V.1.svg.png",
                            Tags = "Witmaina,B5",
                            CreatedDate =DateTime.Now,
                            ModifiedDate =DateTime.Now,
                            BackgroundColor =BaseColors.light}
            };

            _context.Notes.AddRange(notes);
            _context.SaveChanges();


            return RedirectToPage("/Index");
        }
    }



}
