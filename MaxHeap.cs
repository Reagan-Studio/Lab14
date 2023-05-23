using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    internal class MaxHeap : MinHeap
    {
        public MaxHeap(int maxLength) : base(maxLength) { }

        private void SiftUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            int parentindex = (index - 1) / 2;
            if (heapArr[index] > heapArr[parentindex]) 
            {
                Swap(index, parentindex);
                SiftUp(parentindex);
            }
        }

        private void SiftDown(int index)
        {
            int left = 2 * index + 1; 
            int right = 2 * index + 2;
            int maxIndex = index; 
            if ((left < count) && (heapArr[left] > heapArr[maxIndex])) 
            {
                maxIndex = left;
            }
            if ((right < count) && (heapArr[right] > heapArr[maxIndex])) 
            {
                maxIndex = right;
            }
            if (maxIndex != index)
            {
                Swap(index, maxIndex);
                SiftDown(maxIndex);
            }
        }

        public override string ToString()
        {
            Array.Reverse(heapArr, 0, count); 
            return base.ToString();
        }
    }
}
