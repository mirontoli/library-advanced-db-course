using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblan.Model
{
    public class Borrowing
    {

        public Customer Customer
        {
            get;
            set;
        }

        public BookCopy BookCopy
        {
            get;
            set;
        }

        public DateTime BorrowDate
        {
            get;
            set;
        }
        public DateTime ReturnDate
        {
            get;
            set;
        }



    }
}
