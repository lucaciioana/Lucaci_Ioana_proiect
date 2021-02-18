using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lucaci_Ioana_ProiectFinal.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
       public int CategoryID { get; set; }
       public Category Category { get; set; }
    }
}
