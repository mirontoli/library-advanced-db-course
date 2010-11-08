using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblan.Model
{
    public class BookCopy
    {
        public Book Book
        {
            get;
            set;
        }
        public int CopyNumber
        {
            get;
            set;
        }
        /// <summary>
        /// If BorrowedTo is null
        /// it means the copy is available
        /// if it is not null, it provides the reference to Customer
        /// </summary>
        public Customer BorrowedTo
        {
            get;
            set;
        }
        /// <summary>
        /// Default we don't load the history while retrieving 
        /// from database 
        /// but if we need, we map history to this Property
        /// </summary>
        public List<Borrowing> PreviousBorrowings
        {
            get;
            set;
        }
    }
}
