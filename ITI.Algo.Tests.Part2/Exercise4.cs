using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;

namespace ITI.Algo.Tests.Part2
{
    [TestFixture]
    public class Exercise4
    {
        public ListItem Partition(ListItem head, int pivot)
        {
            ListItem current = head;
            ListItem greaterValuesTail = null;
            ListItem greaterValuesHead = null;
            ListItem lowerValuesTail = null;
            ListItem lowerValuesHead = null;

            while (current != null)
            {
                if (pivot > current.Value)
                {
                    if (lowerValuesTail != null) lowerValuesTail.Next = current;       
                    else lowerValuesHead = current;           
                    lowerValuesTail = current;          
                }
                else
                {
                    if (greaterValuesTail != null) greaterValuesTail.Next = current;    
                    else greaterValuesHead = current;        
                    greaterValuesTail = current;          
                }
                current = current.Next;
            }

            if (lowerValuesTail != null)
            {
                lowerValuesTail.Next = greaterValuesHead;
                return lowerValuesHead;
            }

            return greaterValuesHead;
        }

        //[TestCase(new int[] { 3, 6, 8, 5, 10, 2, 1 }, 6, new int[] { 3, 2, 1, 5, 8, 6, 10 })]
        //[TestCase(new int[] { 3, 5, 8, 5, 10, 2, 1 }, 0, new int[] { 3, 5, 8, 5, 10, 2, 1 })]
        //[TestCase(new int[] { 3, 5, 8, 5, 10, 2, 1 }, 15, new int[] { 3, 5, 8, 5, 10, 2, 1 })]
        [TestCase(new int[] { 3, 5, 12, 4, 7, 1, 13 }, 6, new int[] { 3, 5, 4, 1, 12, 7, 13 })]
        [TestCase(new int[] { 3, 5, 12, 4, 7, 1, 13 }, 10, new int[] { 3, 5, 4, 7, 1, 12, 13 })]
        [TestCase(new int[] { 3, 5, 12, 4, 7, 1, 13 }, 0, new int[] { 3, 5, 12, 4, 7, 1, 13 })]
        [TestCase(new int[] { 3, 5, 12, 4, 7, 1, 13 }, 15, new int[] { 3, 5, 12, 4, 7, 1, 13 })]
        public void tests(int[] input, int pivot, int[] expected)
        {
            ListItem head = TestHelpers.ArrayListToLinkedList(input.ToList());
            head = Partition(head, pivot);
            CollectionAssert.AreEqual(TestHelpers.LinkedListToArrayList(head), expected);
        }
    }
}
