using Lab14;
using System.Text;

//номер4-----------------------------------------------------------------------------------------------------------------

string[] lines = File.ReadAllLines("inNum4.txt");
int n = int.Parse(lines[0]);

MinHeap minHeap = new MinHeap(n);
StringBuilder output = new StringBuilder();

for (int i = 1; i <= n; i++)
{
    string operation = lines[i];
    if (operation.StartsWith("A"))
    {
        int element = int.Parse(operation.Substring(2));
        
        minHeap.Add(element);
    }
    else if (operation.StartsWith("X"))
    {
        if (minHeap.Count == 0)
        {
            output.AppendLine("*");
        }
        else
        {
            int minElement = minHeap.PullMin();
            output.AppendLine(minElement.ToString());
        }
    }
    else if (operation.StartsWith("D"))
    {
        string[] parts = operation.Split(' ');
        int index = int.Parse(parts[1]);
        int newKey = int.Parse(parts[2]);
        minHeap.DecreaseKey(index, newKey);
    }
}
File.WriteAllText("outNum4.txt", output.ToString());





//номер3---------------------------------------------------------------------------------------------------------------
//string[] lines = File.ReadAllLines("num1.txt");
//int n = int.Parse(lines[0]);
//int[] arr = Array.ConvertAll(lines[1].Split(), int.Parse);
//MinHeap minHeap = new MinHeap(n);
//minHeap.CreateHeap(arr);
//int[] sorted = minHeap.HeapSort();
//Console.WriteLine("Отсортированный массив: " + string.Join(", ", sorted[..sorted.Length]));





//номер2----------------------------------------------------------------------------------------------------------------
//string[] lines = File.ReadAllLines("num1.txt");
//int n = int.Parse(lines[0]);
//int[] arr = Array.ConvertAll(lines[1].Split(), int.Parse);
//MinHeap minHeap = new MinHeap(n);
//minHeap.CreateHeap(arr);
//Console.WriteLine("Куча: " + minHeap.ToString());





//номер1---------------------------------------------------------------------------------------------------------------
//static bool IsMinHeap(int[] arr)
//{
//    MinHeap minHeap = new MinHeap(arr.Length);
//    minHeap.CreateHeap(arr);
//    string heapString = minHeap.ToString();
//    Array.Sort(arr);
//    string sortedArrayString = string.Join(" ", arr);

//    return heapString == sortedArrayString;
//}


//string[] lines = File.ReadAllLines("num1.txt");
//int n = int.Parse(lines[0]); 
//int[] arr = Array.ConvertAll(lines[1].Split(), int.Parse);
//if (IsMinHeap(arr))
//{
//    Console.WriteLine("YES");
//}
//else
//{
//    Console.WriteLine("NO");
//}


