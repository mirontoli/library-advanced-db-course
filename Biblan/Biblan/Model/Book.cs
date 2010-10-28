using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblan.Model
{
    public class Book
    {
        public string ISBN
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public int NumberOfPages
        {
            get;
            set;
        }

        public int PrintYear
        {
            get;
            set;
        }

        public string Publisher
        {
            get;
            set;
        }

    }
}
