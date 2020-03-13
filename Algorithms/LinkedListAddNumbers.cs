using System;
using Algorithms.Classes;

namespace Algorithms
{
    class LinkedListAddNumbers
    {
        static void Main()
        {
            //ListNode l1 = new ListNode(9);
            //ListNode l2 = new ListNode(1);
            //l2.next = new ListNode(9);
            //l2.next.next = new ListNode(9);
            //l2.next.next.next = new ListNode(9);
            //l2.next.next.next.next = new ListNode(9);
            //l2.next.next.next.next.next = new ListNode(9);
            //l2.next.next.next.next.next.next = new ListNode(9);
            //l2.next.next.next.next.next.next.next = new ListNode(9);
            //l2.next.next.next.next.next.next.next.next = new ListNode(9);
            //l2.next.next.next.next.next.next.next.next.next = new ListNode(9);

            ListNode l1 = new ListNode(2);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(3);
            ListNode l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);

            AddTwoNumbers(l1, l2);
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode l3 = new ListNode(0);
            PopulateListNode(l1, l2, ref l3, 0);
            return l3;
        }

        static void PopulateListNode(ListNode l1, ListNode l2, ref ListNode node, int carryOver)
        {
            var keepRunning = true;
            var firstEnd = false;
            var secondEnd = false;
            int firstNumber = 0;
            int secondNumber = 0;

            if (l1 != null)
            {
                firstNumber = l1.val;
                l1 = l1.next;
            }

            if (l1 == null)
            {
                firstEnd = true;
            }

            if (l2 != null)
            {
                secondNumber = l2.val;
                l2 = l2.next;
            }

            if (l2 == null)
            {
                secondEnd = true;
            }

            if (firstEnd && secondEnd)
            {
                keepRunning = false;
            }

            var total = firstNumber + secondNumber + carryOver;
            if (total > 9)
            {
                carryOver = total / 10;
                var reminder = total % 10;
                node = new ListNode(reminder);
            }
            else
            {
                carryOver = 0;
                node = new ListNode(total);
            }

            if (keepRunning)
            {
                PopulateListNode(l1, l2, ref node.next, carryOver);
            }
            else
            {
                if (carryOver > 0)
                {
                    node.next = new ListNode(carryOver);
                }
            }
        }
    }
}
