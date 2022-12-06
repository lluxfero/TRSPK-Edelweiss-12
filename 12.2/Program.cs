using System.Collections;

namespace LabDS5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            // Заключаем в фигурные скобки, чтобы не было конфликтов имён в дальнейшем
            {
                Console.WriteLine("Enter array1 size");
                int sizearr1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter array2 size");
                int sizearr2 = int.Parse(Console.ReadLine());

                int[] arr1 = new int[sizearr1];
                int[] arr2 = new int[sizearr2];
                // Заполняем массивы
                for (int i = 0; i < arr1.Length; ++i)
                {
                    Console.WriteLine($"Enter element {i} of array1");
                    arr1[i] = int.Parse(Console.ReadLine());
                }
                for (int i = 0; i < arr2.Length; ++i)
                {
                    Console.WriteLine($"Enter element {i} of array2");
                    arr2[i] = int.Parse(Console.ReadLine());
                }

                {
                    Console.WriteLine("Without LINQ");
                    int divided_by_five = 0;
                    // Ходим по каждому массиву и считаем числа, делимые на 5 
                    foreach (var i in arr1) _ = i % 5 == 0 ? ++divided_by_five : 0;
                    foreach (var i in arr2) _ = i % 5 == 0 ? ++divided_by_five : 0;

                    Console.WriteLine($"Number count divided by 5 : {divided_by_five}");
                    Console.WriteLine();
                }
                {
                    Console.WriteLine("With LINQ");
                    // Конкатенируем два массива и выбираем те элементы, которые делятся на 5
                    // затем считаем их количество
                    Console.WriteLine($"Number count divided by 5 : {(from a in arr1.Concat(arr2) where (a % 5 == 0) select a).Count()}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Task 2");
            {
                Console.WriteLine("Enter elements count in string array");
                int count = int.Parse(Console.ReadLine());
                string[] arr = new string[count];

                for (int i = 0; i < count; ++i)
                {
                    Console.WriteLine($"Enter string {i}");
                    arr[i] = Console.ReadLine();
                }

                {
                    Console.WriteLine("Without LINQ");
                    List<string> contains_ot = new();
                    // Находим подстроку "от" ручками
                    foreach (var str in arr)
                    {
                        // Конвертируем строку в нижний регистр, чтобы 
                        // искать подстроку в любом регистре
                        var lstr = str.ToLower();
                        for (int i = 0; i < lstr.Length - 1; ++i)
                        {
                            if (lstr[i] == 'о' && lstr[i + 1] == 'т')
                            {
                                contains_ot.Add(str);
                            }
                        }
                    }
                    // Sort не считается linq`ом (вроде как) поэтому можем его использовать
                    // для сортировки
                    contains_ot.Sort();

                    Console.WriteLine("Sorted array of strings with substring \'от\'");
                    foreach (var str in contains_ot)
                    {
                        Console.WriteLine(str);
                    }
                    Console.WriteLine();
                }
                {
                    Console.WriteLine("With LINQ");
                    // Для строки s в массиве, выбираем ту, в нижнем регистре, которая содержит "от"
                    var collection = (from s in arr where s.ToLower().Contains("от") select s).OrderBy(x => x).ToList();

                    Console.WriteLine("Sorted array of strings with substring \'от\'");
                    foreach (var str in collection)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Task 3");
            {
                Console.WriteLine("Enter s1");
                string s1 = Console.ReadLine();
                string s2 = Console.ReadLine();
                {
                    Console.WriteLine("Without LINQ");
                    // Если строки не совпадают по длине - это не обратные строки
                    bool reversed = s1.Length == s2.Length;
                    if (reversed)
                    {
                        for (int i = 0; i < s1.Length; ++i)
                        {
                            if (s1[i] != s2[s1.Length - i - 1])
                            {
                                reversed = false;
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"Strings {(reversed ? "are" : "are not")} reversed");
                    Console.WriteLine();
                }
                {
                    Console.WriteLine("With LINQ");
                    // IEnumerable нельзя нормально преобразовать в строку
                    // поэтому мы создаём новую строку из массива символов
                    bool reversed = s1 == new string(s2.Reverse().ToArray());
                    Console.WriteLine($"Strings {(reversed ? "are" : "are not")} reversed");
                }

            }

            Console.WriteLine();
            Console.WriteLine("Task 4");
            {
                Console.WriteLine("Enter array size");
                int sizearr = int.Parse(Console.ReadLine());
                int[] arr = new int[sizearr];
                for (int i = 0; i < arr.Length; ++i)
                {
                    Console.WriteLine($"Enter element {i}");
                    arr[i] = int.Parse(Console.ReadLine());
                }
                {
                    Console.WriteLine("Without LINQ");
                    List<int> evens = new();
                    List<int> odds = new();
                    // Группируем числа
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        if (arr[i] % 2 == 1) odds.Add(arr[i]);
                        else evens.Add(arr[i]);
                    }

                    evens.Sort();
                    odds.Sort();

                    Console.WriteLine("Sorted even numbers:");
                    foreach (var num in evens) Console.WriteLine(num);
                    Console.WriteLine("Sorted odd numbers:");
                    foreach (var num in odds) Console.WriteLine(num);
                    Console.WriteLine();
                }
                {
                    Console.WriteLine("With LINQ");
                    // Для числа n в массиве, выбираем те, которые чётные/нечётные
                    var evens = (from n in arr where (n % 2 == 0) select n).OrderBy(x => x).ToList();
                    var odds = (from n in arr where (n % 2 == 1) select n).OrderBy(x => x).ToList();

                    Console.WriteLine("Sorted even numbers:");
                    foreach (var num in evens) Console.WriteLine(num);
                    Console.WriteLine("Sorted odd numbers:");
                    foreach (var num in odds) Console.WriteLine(num);
                    Console.WriteLine();
                }
            }
        }

    }
}
