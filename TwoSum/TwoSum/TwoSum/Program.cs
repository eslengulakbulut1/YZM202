using DataStructures.Array;

(int, int) TwoSumWhitBruteForce(Array<int> array, int target)
{
    for (int i = 0; i < array.Count - 1; i++)
    {
        for (int j = i + 1; j < array.Count; j++)
        {
            if ((array.GetItem(i) + array.GetItem(j)) == target)
            {
                return (i, j);
            }
        }
    }
    return (-1, -1);
}

(int, int) TwoSumWithHashTable(Array<int> array, int target)
{
    for (int i = 0; i < array.Count; i++)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        var minus = target - array.GetValue(i);
        if (map.ContainsKey(minus))
        {
            return (array.GetValue(i), i);
        }
        if (!map.ContainsKey(array.GetValue(i)))
        {
            map.Add(array.GetValue(i), i);
        }
    }
    return (-1, -1);
}

Array<int> arr = new Array<int>(new int[] { 1, 2, 3, 4, 5 });
int target = 7;

var result = TwoSumWhitBruteForce(arr, target);

Console.WriteLine(result);