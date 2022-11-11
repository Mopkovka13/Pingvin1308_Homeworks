namespace LeetCodeZ
{
    internal class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public static class RemoveLinkedListElements
    {
        public static void Test()
        {
            ListNode listNode = new ListNode();
            ListNode listNode2 = new ListNode();
            ListNode listNode3 = new ListNode();
            listNode.val = 2;
            listNode2.val = 2;
            listNode3.val = 3;
            listNode.next = listNode2;
            listNode2.next = listNode3;

            ListNode newList = RemoveElements(listNode, 2);
            while (newList != null)
            {
                Console.WriteLine(newList.val);
                newList = newList.next;
            }
        }
        private static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy = new ListNode(0 ,head);

            ListNode current = head;
            ListNode prev = dummy;

            while (current != null)
            {
                if (current.val == val)
                    prev.next = current.next;
                else
                    prev = current;
                current = current.next;
            }
            return dummy.next;
            

        }
    }
}
