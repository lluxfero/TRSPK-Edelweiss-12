using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;

#region ПУНКТ И

int[] arr0 = { -5, 4, 9, -2, 3, 15, 1, 7, -6, 10};

Console.WriteLine("=== И (обычный) ===");
MyCollection mycollection0 = new MyCollection();
for (int i = 0; i < arr0.Length; i++)
{
    if (arr0[i] % 2 == 0) // проверка на четность
    {
        mycollection0.EvenGr.Add(arr0[i]);
        mycollection0.EvenSum += arr0[i];
    }
    else
    {
        mycollection0.UnevenGr.Add(arr0[i]);
        mycollection0.UnevenSum += arr0[i];
    }
}
Console.WriteLine(mycollection0);


Console.WriteLine("\n==== И (LINQ) =====");
MyCollection mycollection1 = new MyCollection();
var select0 = arr0
    .GroupBy(a => a % 2 == 0);

mycollection1.EvenGr = select0.ToList(); // получение списка
mycollection1.UnevenGr = select1.ToList();
mycollection1.EvenSum = select0.Sum(); // получение суммы списка
mycollection1.UnevenSum = select1.Sum();
Console.WriteLine(mycollection1);

#endregion


#region ПУНКТ К

var arrWorkers = new Worker[]
{
    new Worker ("Петров", 115),
    new Worker ("Сидоров", 206),
    new Worker ("Новиков", 73),
    new Worker ("Петров", 244),
    new Worker ("Жуков", 122),
    new Worker ("Новиков", 58),
    new Worker ("Петров", 139)
};


Console.WriteLine("\n=== К (обычный) ===");
List<Worker> listResult0 = new() { arrWorkers[0] };
Console.WriteLine(listResult0.Count);

for (int i = 1; i < arrWorkers.Length; i++)
{
    bool f = true;
    for (int j = 0; j < listResult0.Count; j++)
    {
        if (string.Compare(arrWorkers[i].Name, listResult0[j].Name) == 0) // есть ли в списке результата работник с такой фамилией
        {
            f = false; 
            listResult0[j].Salary += arrWorkers[i].Salary; // прибавляем, есть есть
            break;
        }
    }
    if (f) listResult0.Add(arrWorkers[i]); // добавляем в результирующий список, если нет
}
for (int j = 0; j < listResult0.Count; j++) Console.WriteLine(listResult0[j]);


Console.WriteLine("\n==== К (LINQ) =====");
List<Worker> listResult1 = arrWorkers
    .GroupBy(w => w.Name)
    .Select(w => new Worker(w.Key, w.First().Salary))
    .ToList(); 

for (int j = 0; j < listResult1.Count; j++) Console.WriteLine(listResult1[j]);

#endregion


#region ПУНКТ Л

int[] arr_l = { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 33, 33, 33 }; // коллекция повторяющихся элементов
Console.WriteLine("\nЭлементы исходного массива:");
for (int i = 0; i < arr_l.Length; i++)
    Console.Write($"{arr_l[i]} ");

Console.WriteLine("\n=== Л (обычный) ===");
int[,] arr_l_count = new int[2, arr_l.Length]; // массив подсчёта повторений каждого элемента массива arr_l
List<int> arr_l_unique = new();
for (int i = 0; i < arr_l.Length; i++) // заполнение массива подсчёта
{
    int j = 0;
    while (j < arr_l_count.GetLength(1) && arr_l_count[1, j] != 0) // если кол-во текущего элемента ноль, то мы его встречаем первый раз => выходим из цикла и добавляем
    {
        if (arr_l_count[0, j] == arr_l[i])
        {
            arr_l_count[1, j]++;
            break;
        }
        j++;
    }

    if (arr_l_count[1, j] == 0)
    {
        arr_l_count[0, j] = arr_l[i];
        arr_l_count[1, j] = 1;
    }
}

for (int i = 0; (i < arr_l_count.GetLength(1)) && (arr_l_count[1, i] != 0); i++)
{
    if (arr_l_count[1, i] == 3)
        arr_l_unique.Add(arr_l_count[0, i]);
}


Console.WriteLine();
Console.WriteLine("Элементы, которые повторяются ровно 3 раза:");
for (int i = 0; i < arr_l_unique.Count; i++)
    Console.Write($"{arr_l_unique[i]} ");


Console.WriteLine("\n=== Л (LINQ) ===");

var select_l = arr_l
    .GroupBy(a => a)
    .Where(a => a.Count() == 3)
    .Select(a => new { Value = a.Key, Count = a.Count() });

List<int> result_l = new();

foreach (var select in select_l)
{
    result_l.Add(select.Value);
}

Console.WriteLine("Элементы, которые повторяются ровно 3 раза:");
for (int i = 0; i < result_l.Count; i++)
    Console.Write($"{result_l[i]} ");

#endregion


#region ПУНКТ М

List<(int, int)> collection_m = new();
collection_m.Add((1, 2));
collection_m.Add((1, 4));
collection_m.Add((2, 1));
collection_m.Add((1, 3));
collection_m.Add((2, 5)); // в этих строчках заполняем коллекцию
List<(int, int)> collection_norm = collection_m; // копируем коллекцию
Console.WriteLine("Элементы коллеции без сортировки:");
for (int i = 0; i < collection_m.Count; i++)
    Console.WriteLine(collection_m[i].ToString()); // вывод коллекции

Console.WriteLine("\n=== М (обычный) ===");

for (int i = collection_norm.Count - 1; i >= 0; i--) // сортировка по первому элементу
{
    for (int j = 0; j < i; j++)
    {
        if (collection_norm[j].Item1 > collection_norm[j + 1].Item1)
        {
            var temp = collection_norm[j];
            collection_norm[j] = collection_norm[j + 1];
            collection_norm[j + 1] = temp;
        }
    }
}

for (int i = collection_norm.Count - 1; i >= 0; i--) // соритровка по второму элементу, не изменяя порядок по первому
{
    for (int j = 0; j < i; j++)
    {
        if (collection_norm[j].Item2 < collection_norm[j + 1].Item2 && collection_norm[j].Item1 == collection_norm[j + 1].Item1)
        {
            var temp = collection_norm[j];
            collection_norm[j] = collection_norm[j + 1];
            collection_norm[j + 1] = temp;
        }
    }
}

Console.WriteLine("Элементы коллеции с сортировкой:"); // вывод отсортированной
for (int i = 0; i < collection_norm.Count; i++)
    Console.WriteLine(collection_norm[i].ToString());

Console.WriteLine("\n=== М (LINQ) ===");

List<(int, int)> collection_linq = collection_m;
var result_m = collection_linq
    .OrderByDescending(x => x.Item2) // соритруем в обратном порядке по второму элементу
    .OrderBy(x => x.Item1) // соритруем обычно по первому, порядок по второму при этом не изменяется
    .ToList(); // преобразовываем в список

Console.WriteLine("Элементы коллеции с сортировкой:"); // выводим
for (int i = 0; i < result_m.Count; i++)
    Console.WriteLine(result_m[i].ToString());

#endregion


#region ПУНКТ Н

Console.WriteLine("\n=== Н (LINQ) ===");

var arra = new List<int> { 1, 2, 3 };

var arrb = new List<double> { 1.1, 2.2, 3.3 };

var arrc = new List<string> { "one", "two", "three" };

var result_n = arra
    .Join(arrb,  // присоединяем второй список
    ara => 1,  // 1 и там, и там, чтобы объединялись все поля
    arb => 1, 
    (ara, arb) => new { a = ara, b = arb }) // и выводим их в анонимный класс с двумя полями
    .Join(arrc, // тут же объединяем с третьим списком
    arab => 1,  // те же условия
    arc => 1,
    (arab, arc) => new { ab = arab, c = arc}); // выводим в анонимный класс, где первое поле - экземпляр первого анонимного класс { (a, b), c }
string abc_str = String.Empty;
foreach(var abc in result_n)
{
    abc_str += $"({abc.ab.a}, {abc.ab.b}, {abc.c}), "; // записываем в строку
}
abc_str = abc_str.Trim(); // обрезаем пробел
abc_str = abc_str.Trim(','); // обрезаем запятую

Console.WriteLine(abc_str);

#endregion


class MyCollection // для пункта И
{
    public List<int> EvenGr { get; set; } = new List<int> { };
    public List<int> UnevenGr { get; set; } = new List<int> { };
    public int EvenSum { get; set; } = 0;
    public int UnevenSum { get; set; } = 0;
    public string WriteList(List<int> list) // метод, получающий строку с элементами списка
    {
        string s = string.Empty;
        for (int i = 0; i < list.Count; i++)
        {
            s += $"{list[i]} ";
        }
        return s;
    }
    public override string ToString()
    {
        return $"четная группа: {WriteList(EvenGr)}| ее сумма: {EvenSum}\nнечетная группа: {WriteList(UnevenGr)}| ее сумма: {UnevenSum}\n";
    }
}

class Worker // для пункта К
{
    public string Name { get; set; } = string.Empty;
    public int Salary { get; set; } = 0;
    public Worker(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }
    public override string ToString()
    {
        return $"фамилия: {Name} | зарплата: {Salary}";
    }
}

