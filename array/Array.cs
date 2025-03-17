﻿using DataStructures.Array.Contracts;

namespace DataStructures.Array;

public class Array<T> : StaticArray<T>, IDynamicArray<T>
{
    private int index = 0;

    public int Count => index;

    public int Capacity => Length;

    public Array()
    {

    }

    public Array(int size)
    {
        _innerArray = new T[size];
    }

    public Array(IEnumerable<T> items) : this()
    {
        AddRange(items);
    }

    public void Add(T value)
    {
        CheckDoubleArray();
        _innerArray[index] = value;
        index++;
    }

    public void AddRange(IEnumerable<T> items)
    {
        foreach(var item in items)
        {
            Add(item);
        }
    }

    public T RemoveAt(int position)
    {
        if (position < 0 || position > Count - 1)
        {
            throw new IndexOutOfRangeException();
        }


        var removedItem = _innerArray[position];

        _innerArray[position] = default;

        for (int i = position; i < Count - 1; i++)
        {
            Swap(i, i + 1);
        }
        index--;
        ShrinkArray();
        return removedItem;
    }

    public void Swap(int position1, int position2)
    {
        var temp = _innerArray[position1];
        _innerArray[position1] = _innerArray[position2];
        _innerArray[position2] = temp;
    }

    public void Concat(ICollection<T> arr) // İki diziyi birleştirir
    {
        AddRange(arr);
        /*var newArray = new T[Capacity + arr.ToList().Capacity];
        for (int i = 0; i < Count; i++)
            newArray[i] = _innerArray[i];

        int j = Count;

        for (int i = 0; i < arr.Count; i++) // Count + i => Count tan başlayarak yeni diziye eleman ekler
        {
            newArray[i] = arr.ElementAt(i);
            j++;
        }*/
           
    }

    public T[] Sort()
    {
        System.Array.Sort<T>(_innerArray, 0, index);
        return _innerArray;
    }
    public T GetValue(int position)
    {
        // throw new NotImplementedException();
        if (position < 0 || position >= _innerArray.Length)
            throw new IndexOutOfRangeException();
        return _innerArray[position];
    }

    public void SetValue(T value, int position)
    {
        if (position < 0 || position >= _innerArray.Length)
            throw new IndexOutOfRangeException();
        _innerArray[position] = value;
    }

    private void CheckDoubleArray()
    {
        //if (Count.Equals(Capacity))
        if (index.Equals(_innerArray.Length))
        {
            var newArray = new T[_innerArray.Length * 2];
            // For döngüsü yerine system copy kullanılabilir
            for (int i = 0; i < _innerArray.Length; i++)
            {
                newArray[i] = _innerArray[i];
            }
            _innerArray = newArray; // yeni oluşturulan dizinin adresi _innerArray'e verilir ve bu kod yapısının artık bir hükmü kalmaz
        }
    }

    // Dizinin sayısı dörtte birine inince dizi kapasitesi yarıya düşer
    private void ShrinkArray() // Boyut düşürür.
    {
        if (Count <= Capacity / 4)
        {
            var newArray = new T[Capacity / 2];
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = _innerArray[i];
            }
            _innerArray = newArray;
        }
    }
}
