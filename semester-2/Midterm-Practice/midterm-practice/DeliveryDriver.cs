using System.Runtime.CompilerServices;

public class DeliveryDriver
{
    private IOrderable[] pkgs;
    private int count = 0;

    public DeliveryDriver(int l)
    {
        pkgs = new IOrderable[l];
    }

    private double totalWeight;
    public double TotalWeight => totalWeight;

    

    public void AddItem(IOrderable item)
    {
        if (count == pkgs.Length) throw (new DeliveryException("Nincs elég hely!"));

        pkgs[count] = item;
        count++;

        totalWeight += item.Weight;
    }

    public IOrderable[] FrozenSorted()
    {
        IOrderable[] frznPckgs = new IOrderable[count];
        int iterator = 0;

        foreach (IOrderable element in pkgs)
        {
            if (element is null) break;

            if (element is FrozenFoodPackage)
            {
                frznPckgs[iterator] = element;
                ++iterator;
            }
        }

        IOrderable[] sortedfrznpkgs = new IOrderable[iterator];
        
        for (int i = 0; i < iterator; i++)
        {
            sortedfrznpkgs[i] = frznPckgs[i];
        }

        for (int i = 0; i < sortedfrznpkgs.Length - 1; i++)
        {
            int min = i;

            for (int j = i + 1; j < sortedfrznpkgs.Length; j++)
            {
                if (sortedfrznpkgs[min].Weight > sortedfrznpkgs[j].Weight)
                {
                    min = j;
                }
            }

            IOrderable temp = sortedfrznpkgs[i];
            sortedfrznpkgs[i] = sortedfrznpkgs[min];
            sortedfrznpkgs[min] = temp;
        }

        return sortedfrznpkgs;
    }
    
    
}