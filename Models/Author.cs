using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lucaci_Ioana_ProiectFinal.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public ICollection<Article> Articles { get; set; }

        [Display(Name = "Author Full Name")]
        public string DisplayName
        {
            get
            {
                return this.FirstName + " '" + Nickname + "' " + LastName;
            }
        }

        [Display(Name ="Written Articles")]
        public string DisplayAllArticleTitles
        {
            get
            {
                string ArticleTitles = "";
                foreach (var item in this.Articles)
                {
                    ArticleTitles = String.Concat(ArticleTitles, item.Title, ", ");
                }
                return ArticleTitles;
            }
        }

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
