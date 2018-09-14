using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Algo.Tests.Part2
{
    public class TestHelpers
    {

        public static List<int> LinkedListToArrayList(ListItem head)
        {
            List<int> result = new List<int>();
            ListItem current = head;

            while (current != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }

            return result;
        }

        public static ListItem ArrayListToLinkedList(List<int> list)
        {
            ListItem result = null;

            for (int x = list.Count - 1; x >= 0; x--)
            {
                ListItem item = new ListItem(list[x]);
                item.Next = result;
                result = item;
            }

            return result;
        }
    }
}
