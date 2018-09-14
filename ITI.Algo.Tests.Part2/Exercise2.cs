using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace ITI.Algo.Tests.Part2
{
    [TestFixture]
    public class Exercise2
    {
        public int GetIndex(ListItem head, int index)
        {
            ListItem current = head;
            for(int x = 0; x < index; x++) current = current.Next;

            ListItem next = head;
            while(current.Next != null)
            {
                current = current.Next;
                next = next.Next;
            }
         
            return next.Value;
        }

        [TestCase(3, 3)]
        [TestCase(0, 6)]
        [TestCase(5, 1)]
        public void tests(int index, int expected)
        {
            ListItem head = TestHelpers.ArrayListToLinkedList(new List<int> { 1, 2, 3, 4, 5, 6});
            int result = GetIndex(head, index);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
