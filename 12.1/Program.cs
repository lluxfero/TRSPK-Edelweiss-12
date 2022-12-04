// Вся реализация структур снизу (лучше сначала оттуда начать)

#region Объявление и инициализация
// Создание массива из чисел
int[] arr = new int[10];
FillArray(arr);

// Создание массива структур (я в данном случае создаю их по 10 элементов), создается с помощью конструктора
MyStruct[] myStructs = new MyStruct[10];
for (int i = 0; i < 10; i++)
{
    myStructs[i] = new MyStruct();
}


MyStruct2[] myStruct2s = new MyStruct2[10];
for (int i = 0; i < 10; i++)
{
    myStruct2s[i] = new MyStruct2();
}

// В этот массив мы потом другой закинем, поэтому пока что мы не знаем сколько в нем должно быть элементов. Это из пункта Г)
MyStruct3[] myStruct3s;

#endregion

#region Обычная реализация
//a
Console.WriteLine("ОБЫЧНАЯ РЕАЛИЗАЦИЯ:");
Console.WriteLine("A:");
PrintArray(arr);
// Используем свою функцию FindMax() для нахождения максимума
Console.WriteLine($"Max = {FindMax(arr)}");

//b
Console.WriteLine("B:");
// Используем свою функцию FindIndexOfMax() для нахождения индекса максимума
Console.WriteLine($"Max index = {FindIndexOfMax(arr)}");

//c
Console.WriteLine("C:");
PrintStruct(myStructs);
// Используем свою функцию FindMaxY() для нахождения максимального Y среди структур
Console.WriteLine($"\nMax Y = {FindMaxY(myStructs)}");

//d
Console.WriteLine("D:");
Console.Write("До сортировки: ");
PrintStruct2(myStruct2s);

// Используем свою функцию SortToStruct(), которая сначала сортирует по Y, а потом возвращает этот массив в myStruct3s
myStruct3s = SortToStruct(myStruct2s);
Console.WriteLine();
Console.Write("После сортировки: ");
PrintStruct3(myStruct3s);


// Заполнение массива
void FillArray(int[] ints)
{
    Random random = new();

    for (int i = 0; i < ints.Length; i++)
    {
        ints[i] = random.Next(-10, 10);
    }
}


// Поиск максимума в массиве
int FindMax(int[] ints)
{
    int max = int.MinValue;
    for (int i = 0; i < ints.Length; i++)
    {
        if (max < ints[i])
        {
            max = ints[i];
        }
    }
    return max;
}

// Поиск максимума (по Y) в массиве структур
int FindMaxY(MyStruct[] ints)
{
    int max = int.MinValue;
    for (int i = 0; i < ints.Length; i++)
    {
        if (max < ints[i].Y)
        {
            max = ints[i].Y;
        }
    }
    return max;
}

// Вывод массива на консоль
void PrintArray(int[] ints)
{
    for (int i = 0; i < ints.Length; i++)
    {
        Console.Write($" {ints[i]} ");
    }
    Console.WriteLine();
}

// Вывод массива MyStruct на консоль
void PrintStruct(MyStruct[] ints)
{
    for (int i = 0; i < ints.Length; i++)
    {
        Console.Write($" {ints[i].Y} ");
    }
}
// Вывод массива MyStruct3 на консоль
void PrintStruct3(MyStruct3[] ints)
{
    for (int i = 0; i < ints.Length; i++)
    {
        Console.Write($" {ints[i].Y} ");
    }
}
// Вывод массива MyStruct2 на консоль
void PrintStruct2(MyStruct2[] ints)
{
    for (int i = 0; i < ints.Length; i++)
    {
        Console.Write($" {ints[i].Y} ");
    }
}


// Поиск индекса максимального элемента в массиве
int FindIndexOfMax(int[] ints)
{
    int max = int.MinValue;
    int index = 0;
    for (int i = 0; i < ints.Length; i++)
    {
        if (max < ints[i])
        {
            max = ints[i];
            index = i;
        }
    }
    return index;
}


MyStruct3[] SortToStruct(MyStruct2[] myStruct2)
{
    // этот объект мы вернем в конце функции (пункт Г)
    MyStruct3[] myStruct3 = new MyStruct3[myStruct2.Length];

    // кладем самое маленькое значение double, которое только возможно(это для сортировки)
    double temp = double.MinValue;

    // сортировка пузырьком
    for (int j = 0; j <= myStruct2.Length - 2; j++)
    {
        for (int i = 0; i <= myStruct2.Length - 2; i++)
        {
            if (myStruct2[i].Y > myStruct2[i + 1].Y)
            {
                temp = myStruct2[i + 1].Y;
                myStruct2[i + 1].Y = myStruct2[i].Y;
                myStruct2[i].Y = temp;
            }
        }
    }

    // После сортировки заполняем наш пустой myStruct3
    for (int i = 0; i < myStruct3.Length; i++)
    {
        myStruct3[i].X = myStruct2[i].X;
        myStruct3[i].Y = (int)myStruct2[i].Y;
    }

    // А здесь возвращаем его, тем самым сделали преобразование [ MyStruct2[]  - >  MyStruct3[] ]
    return myStruct3;
}
#endregion

#region Удаляю все данные из созданных массивов для LINQ Реализации
FillArray(arr);
Array.Clear(myStruct3s);
Array.Clear(myStruct2s);
Array.Clear(myStructs);


for (int i = 0; i < 10; i++)
{
    // здесь удобнее еще раз вызвать конструкторы, чтобы закинуть новые рандомные значения
    myStructs[i] = new();
    myStruct2s[i] = new();
    myStruct3s[i] = new();
}
#endregion

#region LINQ Реализация
Console.WriteLine("\n\nLINQ РЕАЛИЗАЦИЯ:");
//a

Console.WriteLine("A:");
PrintArray(arr);
// вызов Linq Max()
Console.WriteLine($"Max = {arr.Max()}");

//b
Console.WriteLine("B:");
// вызов Linq IndexOf(arr - массив в котором ищем, arr.Ma() - элемент, индекс которого мы должны найти)
Console.WriteLine($"Index of Max = {Array.IndexOf(arr, arr.Max())}");

//c
int sortY = myStructs.Max(x => x.Y);
Console.WriteLine("C:");
PrintStruct(myStructs);
Console.WriteLine($"\nMax по Y : {sortY}");


//d
Console.WriteLine("D:");

// OrderBy(x => x.Y) - сортировка по Y  |  Select(x => x) - возвращаем отсортированные данные | Cast<MyStruct2>() преобразуем в MyStruct2 | Преобразуем в Array
MyStruct2[] last = myStruct2s.OrderBy(x => x.Y).Select(x => x).Cast<MyStruct2>().ToArray();

// Array.ConvertAll - конвертирует все элементу по алгоритму, заданному в конвертере. Конвертер - это делегат, а toMyStruct3 - метод, который мы в него помещаем
// toMyStruct3 - метод для перевода из MyStruct2   ->  в MyStruct3
MyStruct3[] hello = Array.ConvertAll(last, new Converter<MyStruct2, MyStruct3>(toMyStruct3));


Console.WriteLine("myStruct2s: ");
foreach (var item in last)
{
    Console.Write($"{item.Y} ");
}
Console.WriteLine("");
Console.WriteLine("myStruct3s: ");

foreach (var item in hello)
{
    Console.Write($"{item.Y} ");
}


MyStruct3 toMyStruct3(MyStruct2 v)
{
    MyStruct3 myStruct3 = new MyStruct3();
    myStruct3.X = v.X;
    myStruct3.Y = (int)v.Y;
    return myStruct3;
}



#endregion
//Реализация структур
struct MyStruct
{
    public int X { get; set; }
    public int Y { get; set; }

    public MyStruct()
    {
        Random random1 = new Random();
        X = random1.Next(-10, 10);
        Y = random1.Next(-10, 10);
    }

}

struct MyStruct2
{
    public int X { get; set; }
    public double Y { get; set; }

    public MyStruct2()
    {
        Random random1 = new Random();
        X = random1.Next(-10, 10);
        Y = random1.Next(-10, 10);
    }

}

struct MyStruct3
{
    public double X { get; set; }
    public int Y { get; set; }

    public MyStruct3()
    {
        Random random1 = new Random();
        X = random1.Next(-10, 10);
        Y = random1.Next(-10, 10);
    }


}


