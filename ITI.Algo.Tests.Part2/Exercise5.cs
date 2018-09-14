using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace ITI.Algo.Tests.Part2
{
    [TestFixture]
    class Exercise5
    {
        public ListItem Sum(ListItem item1, ListItem item2)
        {
            ListItem result = null;
            ListItem last = null;
            ListItem curr1 = item1;
            ListItem curr2 = item2;

            int r = 0;

            while (curr1 != null || curr2 != null)
            {
                int v1 = curr1 != null ? curr1.Value : 0;
                int v2 = curr2 != null ? curr2.Value : 0;
                int n = v1 + v2 + r;
                r = n / 10;
                n = n % 10;

                ListItem item = new ListItem(n);
                if (result == null) result = item;
                else last.Next = item;
                last = item;

                if (curr1 != null) curr1 = curr1.Next;
                if (curr2 != null) curr2 = curr1.Next;
            }

            return result;
        }

        [TestCase(new int[] { 7, 1, 6 }, new int[] { 5, 9, 2 }, new int[] { 9, 1, 2 })]
        [TestCase(new int[] { 3, 3, 3 }, new int[] { 2, 7, 9 }, new int[] { 1, 3, 0, 5 })]
        public void tests(int[] v1, int[] v2, int[] expected)
        {
            ListItem value1 = TestHelpers.ArrayListToLinkedList(v1.ToList());
            ListItem value2 = TestHelpers.ArrayListToLinkedList(v2.ToList());
            ListItem head = Sum(value1, value2);
            CollectionAssert.AreEqual(TestHelpers.LinkedListToArrayList(head), expected);
        }
    }
}
