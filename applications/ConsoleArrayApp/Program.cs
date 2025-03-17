using DataStructures.Array;

var numbers = new Array<int>(4);
numbers.Add(75);
numbers.Add(66);
numbers.Add(52);
numbers.Add(61);
numbers.Add(56);
numbers.Add(55);

foreach (var item in numbers)
{
    System.Console.WriteLine(item);
};
System.Console.WriteLine($"{numbers.Count}/{numbers.Capacity}");