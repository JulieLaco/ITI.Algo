using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ITI.Algo.Tests.Part2
{
    public class Exercise1
    {
        public void RemoveDuplicates(ListItem head)
        {
            if (head != null)
            {
                ListItem start = head;
                while (start != null)
                {
                    if (start.Next != null && start.Value == start.Next.Value)
                    {
                        start.Next = start.Next.Next;
                    }
                    else
                    {
                        start = start.Next;
                    }
                }
            }
        }

        public void RemoveDuplicatesProf(ListItem head)
        {
            if (head == null) return;
            HashSet<int> values = new HashSet<int>();
            values.Add(head.Value);

            ListItem current = head;
            while (current != null && current.Next != null)
            {
                if (values.Contains(current.Next.Value))
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    values.Add(current.Next.Value);
                    current = current.Next;
                }     
            }
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 1, 2, 3, 4, 1, 2, 3, 2, 4 }, new int[] { 1, 2, 3, 4 })]
        public void tests(int[] input, int[] expected)
        {
            ListItem head = TestHelpers.ArrayListToLinkedList(input.ToList());

            RemoveDuplicatesProf(head);

            List<int> result = TestHelpers.LinkedListToArrayList(head);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void linked_list_demo()
        {
            ListItem item4 = new ListItem(4); // 4 -> null
            ListItem item3 = new ListItem(3); // 4 -> null  3 -> null
            item3.Next = item4; // 3 -> 4 -> null
            ListItem item2 = new ListItem(2);
            item2.Next = item3; // 2 -> 3 -> 4 -> null 
            ListItem item1 = new ListItem(1);
            item1.Next = item2; // 1 -> 2 -> 3 -> 4 -> null
        }
    }
}
