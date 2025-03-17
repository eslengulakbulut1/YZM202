using DataStructures.Array;
using System.Collections.Generic;

// BruteForce => ne demek? 
// BruteForce => kaba kuvvet anlamına gelir.
// BruteForce => bir problemi çözmek için bilgisayarın gücünü kullanarak tüm olasılıkları denemektir.
(int,int) TwoSumWithBruteForce(Array<int> array, int target)
{
    for (int i = 0; i < array.Length; i++) // 0,1,2,3,4 => 5 elemanlı bir dizi var. 
    {
        for (int j = i + 1; j < array.Length; j++) // i=0 için j=1,2,3,4 => 4 tane eleman var. 
        {
            if ((array.GetItem(i) + array.GetItem(j)) == target) // 1+2=3 
            {
                return (i, j);
            }
        }
    }
    return (-1, -1);
}

(int, int) TwoSumWithHashMap(Array<int> array, int target)
{
    Dictionary<int, int> map = new Dictionary<int, int>();
    // Key var. Key =1 keye karşılık gelen değer var. 

    for (int i = 0; i < array.Count; i++)
    {
        var minus = target - array.GetValue(i);
        if (map.ContainsKey(minus))
        {
            return (map[minus], i);
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

var result = TwoSumWithBruteForce(arr, target);
var result_2 = TwoSumWithHashMap(arr, target);

Console.WriteLine(result);
Console.WriteLine(result_2);

/*******************************************************************************************************************************/
// Brute force ile hash map arasındaki farklar nelerdir?
// Brute force => O(n^2) zaman karmaşıklığına sahiptir.
// Hash map => O(n) zaman karmaşıklığına sahiptir.
// Brute force => O(1) hafıza karmaşıklığına sahiptir.
// Hash map => O(n) hafıza karmaşıklığına sahiptir.
/*
 Brute-force yaklaşımı:

Tüm olası ikilileri karşılaştırarak hedef değeri kontrol eder.
İç içe iki döngü kullanarak her elemanı diğerleriyle toplar.
Zaman karmaşıklığı: O(n²) (n elemanlı dizide her eleman diğerleriyle karşılaştırıldığı için).
Diziler ve GetItem metodu:

Array<int> kullanılmış (Ancak, C#’ta standart olarak List<int> veya int[] tercih edilir).
array.GetItem(i) ve array.GetItem(j) çağrıları kullanılarak elemanlar alınmış.
Tuple (Çift Değer Döndürme):

(int, int) döndürerek indeks çiftini verir.
 */

/*
 İlk döngü (i): İlk elemanı seçer.
İkinci döngü (j): İlk elemandan sonraki elemanları gezerek tüm ikilileri oluşturur.
Koşul kontrolü: Eğer iki elemanın toplamı target değerine eşitse, bunların indeksleri (i, j) olarak döndürülür.
Eğer hiçbir çift uygun değilse, (-1, -1) döndürülür.
 */
/*******************************************************************************************************************************/

/*
 Dictionary (HashMap) kullanımı:

Anahtar (Key): Dizi elemanları.
Değer (Value): Elemanların dizideki indeksleri.
Daha önce gördüğümüz elemanları saklamak için kullanılır.
Tek döngü ile optimizasyon:

O(n^2) olan brute-force yöntemi yerine O(n) zaman karmaşıklığı sağlar.
Her eleman için target - array[i] değeri önceden eklenmiş mi diye kontrol edilir.

Dictionary (map) oluşturulur: Daha önce görülen elemanları saklamak için.
Dizi içinde gezinilir:
minus = target - array[i] hesaplanır.
Eğer minus değeri daha önce map içinde varsa, bu iki elemanın indeksleri döndürülür.
Yoksa array[i] değeri ve indeksi map içine eklenir.
Hiçbir eşleşme bulunamazsa (-1, -1) döndürülür.
*/