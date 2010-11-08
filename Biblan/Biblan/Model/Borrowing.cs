using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblan.Model
{
    public class Borrowing
    {

        public int CustomerID
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
