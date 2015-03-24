
using System;
using System.Collections.Generic;

namespace MvcApplication1.Models
{

    public partial class Book
    {

        public Book()
        {

            this.Writers = new HashSet<Writer>();

        }

        public int ID { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string Genre { get; set; }


        public virtual ICollection<Writer> Writers { get; set; }

    }

}