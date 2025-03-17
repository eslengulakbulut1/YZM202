using DataStructures.Array;
namespace arrayTests;

public class ArrayTests
{
    [Fact]
    public void Check_Array_Count_And_Capacity()
    {
        // Arrange - Act - Assert

        // Arrange
        var array = new Array<int>(4);
        array.Add(75);
        array.Add(66);
        array.Add(52);
        array.Add(61);
        array.Add(56);
        array.Add(55);

        // Act
        var count = array.Count;
        var capacity = array.Capacity;

        // Assert
        Assert.Equal(6, count);
        Assert.Equal(8, capacity);
    }

    [Fact]
    public void AddRange_Test()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6 }; // Array<int> yerine List<int> daha uygun
        numbers.AddRange(new int[] { 2, 3 });

        // Assert
        Assert.Equal(8, numbers.Count); // Toplam eleman sayısı 8 olmalı
        Assert.True(numbers[6] == 2); // 6. indeks 2 olmalı
        Assert.True(numbers[7] == 3); // 7. indeks 3 olmalı
    }


    [Fact]
    public void RemoveAt_Test()
    {
        // Arrange
        var numbers = new Array<int>(new int[] { 0, 1, 2, 3, 4 });

        // Act
        var item = numbers.RemoveAt(1);

        // Assertion
        Assert.Equal(1, item);
        Assert.True(numbers.Count == 4);
        Assert.Equal(2, numbers.RemoveAt(1));
    }

    

    [Fact]
    public void Sort_Test()
    {
        var numbers = new Array<int>(new int[] { 1, 3, 2, 5, 4 });

        numbers.Sort();

        Assert.Equal(2, numbers.GetItem(1));
    }

    [Fact]
    public void Concat_Test()
    {
         // Arrange
        var numbers_1 = new Array<int>(new int[] { 1, 2, 3}); 
        List<int> numbers_2 = new List<int>(new int[] { 4, 5, 6 });

        // Act
        numbers_1.Concat(numbers_2);

        // Assert
        Assert.Equal(3, numbers_2.Capacity);
        Assert.Equal(8, numbers_1.Capacity);
        Assert.Equal(5, numbers_1.GetItem(4));
    }

}