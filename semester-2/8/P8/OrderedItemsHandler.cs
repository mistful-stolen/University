using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public enum SortingMethod { Selection, Bubble, Insertion }

class OrderedItemsHandler
{
    IComparable[] items;

    Func<IComparable, IComparable, bool> less;
    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public bool IsOrdered ( bool isAscending = true)
    {
        DefineLess(isAscending);

        for (int i = 1; i < items.Length; i++)
        {
            if (less(items[i], items[i - 1])) return true;
            
        }

        return true;
    }

    private void DefineLess(bool isAscending)
    {
        less = (a, b) => isAscending ? a.CompareTo(b) < 0 : b.CompareTo(a) < 0;
    }

    public void Sort(SortingMethod sortingMethod, bool isAscending = true)
    {
        DefineLess(isAscending);
        switch (sortingMethod)
        {
            case SortingMethod.Selection: break;
            case SortingMethod.Bubble: break;
            case SortingMethod.Insertion: break;
            default: break;
        }
        
    }

    public void SelectionSort()
    {
        for (int i = 0; i < items.Length; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < items.Length; j++)
            {
                if (less(items[j], items[minIdx]))
                {
                    minIdx = j;
                }
            }
            Swap(i, minIdx);
            
            
        }
   }

    private void BubbleSort()
    {
        int i = items.Length - 1;

        while (i > 0)
        {
            int lastSwap = 0;

            for (int j = 0; j < i; j++)
            {
                if (less(items[j+1], items[j]))
                {
                    Swap(j, j + 1);
                    lastSwap = j;
                }
            }
        }
    }

    public void Swap(int i, int j)
    {
        IComparable temp = items[i];
        items[i] = items[j];
        items[j] = temp;
    }

    private void InsertionSort()
    {
        for (int i = 1; i < items.Length; i++)
        {
            int j = i - 1;
            IComparable temp = items[i];

            while (j >= 0 && less(items[j], temp))
            {
                items[j + 1] = items[j];
                j--;
            }
            items[j + 1] = temp;
        }
    }
}