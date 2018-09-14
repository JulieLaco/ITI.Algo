using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace ITI.Algo.Tests.Part2
{
    [TestFixture]
    public class Exercise3
    {
        public void Remove(ListItem item)
        {
            ListItem current = item;

            while (current.Next != null) 
            {
                current.Value = current.Next.Value;
                current.Next = current.Next.Next;
                current = current.Next;
            }

            current.Next = null;
        }

        [Test]
        public void tests()
        {
            ListItem head = TestHelpers.ArrayListToLinkedList(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
            ListItem item = head.Next.Next.Next;
            Remove(item);
            CollectionAssert.AreEqual(TestHelpers.LinkedListToArrayList(head), new[] { 1, 2, 3, 5, 6, 7 });
        }
    }
}
