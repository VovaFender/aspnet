using System;
using System.Collections.Generic;

namespace MvcApplication1.Models
{
    public partial class Writer
    {

        public Writer()
        {

            this.Books = new HashSet<Book>();

        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}