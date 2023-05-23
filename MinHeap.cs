using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    internal class MinHeap
    {
        protected int[] heapArr;
        protected int count;

        public int Count { get { return count; } }

        public MinHeap(int maxLength)
        {
            heapArr = new int[maxLength];
            count = 0;
        }

        public int Parent(int index)
        {
            if (index == 0)
            {
                throw new Exception("У корневого элемента нет родителя");
            }
            return heapArr[(index - 1) / 2];
        }

        public int LeftChild(int index)
        {
            return 2 * index + 1;
        }

        public int RightChild(int index)
        {
            return 2 * index + 2;
        }

        protected void Swap(int index1, int index2)
        {
            int temp = heapArr[index1];
            heapArr[index1] = heapArr[index2];
            heapArr[index2] = temp;
        }

        protected void SiftUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            int parentindex = (index - 1) / 2;
            if (heapArr[index] < heapArr[parentindex])
            {
                Swap(index, parentindex);
                SiftUp(parentindex);
            }

        }

        private void SiftDown(int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int minIndex = index;
            if ((left < count) && (heapArr[left] < heapArr[minIndex]))
            {
                minIndex = left;
            }
            if ((right < count) && (heapArr[right] < heapArr[minIndex]))
            {
                minIndex = right;
            }
            if (minIndex != index)
            {
                Swap(index, minIndex);
                SiftDown(minIndex);
            }
        }

        public void CreateHeap(int[] arr)
        {
            if (arr.Length > heapArr.Length)
            {
                throw new Exception("Выбранный массив превосходит кучу");
            }
            count = arr.Length;
            for (int i = 0; i < count; i++)
            {
                heapArr[i] = arr[i];
            }
            for (int i = count / 2; i >= 0; i--)
            {
                SiftDown(i);
            }
        }


        public void Add(int el)
        {
            if (heapArr.Length == count)
            {
                throw new Exception("Куча заполнена");
            }
            heapArr[count++] = el;
            SiftUp(count);
        }

        public int PullMin()
        {
            if (count == 0)
            {
                throw new Exception("Куча пуста");
            }
            int min = heapArr[0];
            count--;
            heapArr[0] = heapArr[count];
            SiftDown(0);
            return min;
        }


        public int[] HeapSort()
        {
            int[] sortedArr = new int[count];
            for (int i = 0; i < sortedArr.Length; i++)
            {
                sortedArr[i] = PullMin();
            }
            heapArr = sortedArr;
            count = sortedArr.Length;
            return sortedArr;
        }


        public bool Contains(int el)
        {
            for (int i = 0; i < count; i++)
            {
                if (heapArr[i] == el)
                {
                    return true;
                }
            }
            return false;
        }

        public void DecreaseKey(int el, int newKey)
        {
            if (!Contains(el))
            {
                throw new Exception();
            }
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (heapArr[i] == el)
                {
                    index = i;
                    break;
                }
            }
            if (newKey > heapArr[index])
            {
                throw new Exception();
            }
            heapArr[index] = newKey;
            SiftUp(index);
        }


        public override string ToString()
        {
            return string.Join(", ", heapArr[..count]);
        }



    }
}
