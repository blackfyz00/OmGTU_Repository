
class Program
{
    static void Main()
    {
        int count = 20;
        int[] soldier = new int[count];

        List<int> even = new List<int>(); List<int[]> evento = new List<int[]>();
        List<int> odd = new List<int>(); List<int[]> oddto = new List<int[]>();

        for (int i = 0;i<count;i++)
            soldier[i] = i+1;

        for (int i = 0; i < count; i++)
        {
            if (soldier[i] % 2 == 0) even.Add(soldier[i]);
            else odd.Add(soldier[i]);
        }

        while(true)
        {
            if (even.Count < 5) { break; }
            int[] three = new int[3];
            three[0] = even[0];
            three[1] = even[2];
            three[2] = even[4];
            evento.Add(three);

            even.Remove(even[4]);
            even.Remove(even[2]);
            even.Remove(even[0]); 
            
        }

        while (true)
        {
            if (odd.Count < 5) { break; }
            int[] three = new int[3];
            three[0] = odd[0];
            three[1] = odd[2];
            three[2] = odd[4];
            oddto.Add(three);

            odd.Remove(odd[4]);
            odd.Remove(odd[2]);
            odd.Remove(odd[0]);
        }

        Console.WriteLine(count);
        Console.WriteLine(oddto.Count + evento.Count);
    }
}