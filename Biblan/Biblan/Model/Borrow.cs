using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblan.Model
{
    public class Borrow
    {
        public string ISBN
        {
            get;
            set;
        }

        public int CustomerID
        {
            get;
            set;
        }

        public int CopyID
        {
            get;
            set;
        }

        public int BDate
        {
            get;
            set;
        }


    }
}
