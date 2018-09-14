using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace ITI.Algo.Tests.Part2
{
    public class ListItem
    {
        int _value;
        ListItem _next;

        public ListItem(int value)
        {
            _value = value;
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public ListItem Next
        {
            get { return _next; }
            set { _next = value; }
        }
     }
}
