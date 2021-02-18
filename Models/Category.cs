using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lucaci_Ioana_ProiectFinal.Models
{
    public class Category
    {

        public int ID { get; set; }
        public string Name { get; set; }        
        public ICollection<Article> Articles { get; set; }
        [Display(Name = "Articles Count")]
        public int ArticlesCount
        {
            get
            {
                return this.Articles.Count;
            }
        }
    }
}