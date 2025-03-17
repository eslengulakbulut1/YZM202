using DataStructures.Array;

<<<<<<< HEAD
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
=======
var numbers = new Array<int>(5);
numbers.Add(19);
numbers.Add(25);
numbers.Add(71);
numbers.Add(77);
numbers.Add(52);
numbers.Add(31);

foreach (var number in numbers)
{
    Console.WriteLine(number);
}

System.Console.WriteLine(numbers.Count + "/" + numbers.Capacity);
>>>>>>> 832a0495ccd30ae37b6d8f221d8167250345d334
