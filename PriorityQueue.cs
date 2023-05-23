using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    class PriorityQueue
    {
        private MinHeap minHeap;

        public PriorityQueue(int maxLength)
        {
            minHeap = new MinHeap(maxLength);
        }

        public void Enqueue(int el)
        {
            minHeap.Add(el);
        }

        public int Dequeue()
        {
            return minHeap.PullMin();
        }

        public void DecreaseKey(int el, int newKey)
        {
            minHeap.DecreaseKey(el, newKey);
        }
    }
}
