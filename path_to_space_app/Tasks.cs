using System.Text;

namespace path_to_space_app;

internal static class Tasks//что бы скормить задания сайту нужно убрать элементы nullable контекста( ?. и !)
                           //и убрать форматирование строк типо $"{numberLoads} {loadWeight}" заменив на numberLoads +" " + loadWeight
{
    static public void PerformTask2001()//A+B
    {
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        Console.WriteLine(numbers.Sum());
    }
    static public void PerformTask2002()//Сумма чисел
    {
        Console.ReadLine();//не нужно, но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        Console.WriteLine(numbers.Sum());
    }
    static public void PerformTask2003()//Альтернированная сумма чисел
    {
        Console.ReadLine();//не нужно, но в задаче должно быть
        int negativator = 0;
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s) * (int)Math.Pow(-1, negativator++)));
        Console.WriteLine(numbers.Sum());
    }
    static public void PerformTask2004()//Високосный год
    {
        int year = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine((year % 4 == 0 && year % 100 != 0) || year % 400 == 0 ? 1 : 0);
    }
    static public void PerformTask2005()//Индекс первого минимума
    {
        Console.ReadLine();//не нужно, но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        Console.WriteLine(Array.IndexOf(numbers, numbers.Min()) + 1);
    }
    static public void PerformTask2006()//Измерение длин в Бадене
    {
        //1 дюйм = 3см, 1 фут = 12 дюймов = 36 см
        int centimeters = Convert.ToInt32(Console.ReadLine());
        int foot = centimeters / 36;
        int centimetersWithoutFoot = centimeters % 36;
        int inch = centimetersWithoutFoot / 3 + (centimetersWithoutFoot % 3 >= 2 ? 1 : 0);
        Console.WriteLine($"{foot} {inch}");
    }
    static public void PerformTask2007()//Круглые числа в двоичной системе счисления
    {
        int n = Convert.ToInt32(Console.ReadLine());
        bool observerParity = n % 2 == 0 ? true : false;
        int zeroCounter = 0;
        while (observerParity)
        {
            zeroCounter++;
            n = n / 2;
            observerParity = n % 2 == 0 ? true : false;
        }
        Console.WriteLine(zeroCounter);
    }
    static public void PerformTask2008()//Загрузка грузовика
    {
        int maxWeight = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)))[1];
        int[] cargoWeights = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        int numberLoads = 0;
        int loadWeight = 0;
        foreach (int weight in cargoWeights)
        {
            if (maxWeight >= loadWeight + weight)
            {
                numberLoads++;
                loadWeight += weight;
            }
        }
        Console.WriteLine($"{numberLoads} {loadWeight}");
    }
    public static void PerformTask2009()//Сумма на степенях двоек
    {
        int arrayLength = Convert.ToInt32(Console.ReadLine());
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        int resultSum = 0;
        for (int i = 1, j = 1; i <= arrayLength; i = (int)Math.Pow(2, j++))
        {
            resultSum += numbers[i - 1];
        }
        Console.WriteLine(resultSum);
    }
    public static void PerformTask2010()//Алгоритм Евклида 
    {
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        int stepCounter = 0;
        while (Array.TrueForAll(numbers, n => n > 0))
        {
            if (numbers[0] > numbers[1])
            {
                numbers[0] -= numbers[1];
            }
            else
            {
                numbers[1] -= numbers[0];
            }
            stepCounter++;
        }
        Console.WriteLine($"{stepCounter} {numbers.Max()}");
    }
    public static void PerformTask2011()//Анализ возраста
                                        //что бы скормить задание сайту нужно переписать switch в цепочку if
    {
        int age = Convert.ToInt32(Console.ReadLine());
        string massage = age switch
        {
            < 7 => "preschool child",
            <= 17 => $"schoolchild {age - 6}",
            <= 22 => $"student {age - 17}",
            _ => "specialist"
        };
        Console.WriteLine(massage);
    }
    public static void PerformTask2012()//Разрезание квадрата
    {
        int[] reactangle1 = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        int[] reactangle2 = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        string answer = "NO";
        if (reactangle1.Contains(reactangle2.Max()) && reactangle1.Min() + reactangle2.Min() == reactangle2.Max())
        {
            answer = "YES";
        }
        Console.WriteLine(answer);
    }
    public static void PerformTask2013()//Количество минимумов 
    {
        Console.ReadLine();//не нужно, но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        Console.WriteLine(numbers.Count((n) => (n == numbers.Min())));
    }
    public static void PerformTask2014()//Алгоритм Евклида
    {
        // не понятно
    }
    public static void PerformTask2015()//Простые на отрезке 
    {
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (IsPrime(i)) { Console.WriteLine(i); }
        }
    }
    private static bool IsPrime(int n)
    {
        for (int i = 2; i < (int)Math.Sqrt(n) + 1; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return n == 1 ? false : true;
    }
    public static void PerformTask2016()//Количество корней уравнения
                                        //что бы скормить задание сайту нужно переписать switch в цепочку if
    {
        int[] coefficients = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        int discriminant = (int)Math.Pow(coefficients[1], 2) - 4 * coefficients[0] * coefficients[2];
        int answer = (coefficients[0], coefficients[1], coefficients[2]) switch
        {
            (0, 0, 0) => -1,
            (0, 0, _) => 0,
            (0, _, 0) => 1,
            (0, _, _) => 1,
            _ => discriminant < 0 ? 0 : discriminant == 0 ? 1 : 2
        };
        Console.WriteLine(answer);
    }
    public static void PerformTask2017()//Числа с наибольшим количеством делителей
    {
        int[] border = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        int[] numbers = GetRangeArray(border[0], border[1]);
        int[] numbersDivider = GetNumberDividerArray(numbers);
        int numberMaxDivider = numbersDivider.Count((n) => (n == numbersDivider.Max()));
        Console.WriteLine(numberMaxDivider);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbersDivider[i] == numbersDivider.Max())
                sb.Append(numbers[i] + ",");
        }
        Console.WriteLine(sb.Remove(sb.Length - 1, 1).ToString());
    }
    private static int[] GetRangeArray(int a, int b)
    {
        int[] numbers = new int[b - a + 1];
        for (int i = 0; i < numbers.Length; i++, a++)
        {
            numbers[i] = a;
        }
        return numbers;
    }
    private static int FindNumberDivider(int n)
    {
        int dividerCounter = 0;
        for (int i = 1; i <= n; i++)
        {
            dividerCounter = n % i == 0 ? dividerCounter + 1 : dividerCounter;
        }
        return dividerCounter;
    }
    private static int[] GetNumberDividerArray(int[] startArray)
    {
        int[] countdividerArray = new int[startArray.Length];
        for (int i = 0; i < countdividerArray.Length; i++)
        {
            countdividerArray[i] = FindNumberDivider(startArray[i]);
        }
        return countdividerArray;
    }
    public static void PerformTask2018()//Хитрая сумма чисел
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        int[] signArray = GetSignArray(numbers, n);
        int resultSum = 0;
        for (int i = 0; i < n; i++)
        {
            resultSum += signArray[i] * numbers[i];
        }
        Console.WriteLine(resultSum);
    }
    private static int[] GetSignArray(int[] startArray, int n)
    {
        int[] signArray = new int[n];
        int blocCounter = 1;
        int negativeObserver = 1;
        for (int i = 0; i < n;)
        {
            for (int j = 0; j < blocCounter && i < n; j++, i++)
            {
                signArray[i] = negativeObserver;
            }
            blocCounter++;
            negativeObserver *= -1;
        }
        return signArray;
    }
    public static void PerformTask2019()//Треугольная полка
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int shelfNumber = 0;
        int bookOnShelf = 1;
        int numberAllBook = 0;
        while (numberAllBook < n)
        {
            numberAllBook += bookOnShelf++;
            shelfNumber++;
        }
        Console.WriteLine(shelfNumber);
    }
    public static void PerformTask2020()//Наиболее частое значение
    {
        Console.ReadLine();//не нужно, но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        var toDictionary = numbers.GroupBy((n) => (n)).Select((g) => (new { key = g.Key, val = g.Count() })).ToDictionary((c) => (c.key), (c) => (c.val));
        int maxNumberInclusions = toDictionary.Values.Max();
        var answer = toDictionary.Where((n) => (n.Value == maxNumberInclusions)).ToDictionary((c) => (c.Key), (c) => (c.Value)).Keys.Min();
        Console.WriteLine($"{answer} {maxNumberInclusions}");
    }
    public static void PerformTask2021()//Делим максимум
    {
        Console.ReadLine();//не нужно, но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        numbers = numbers.Select((n) => (n == numbers.Max() ? (int)n / 2 : n)).ToArray();
        numbers = numbers.Select((n) => (n == numbers.Max() ? (int)n / 2 : n)).ToArray();
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
    }
    public static void PerformTask2022()//Делящиеся пары
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        Array.Sort(numbers);
        int counter = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i != j) { counter = numbers[j] % numbers[i] == 0 ? counter + 1 : counter; }
            }
        }
        Console.WriteLine(counter);
    }
    public static void PerformTask2023()//Поиск во втором массиве//----------------не проходит все тесты и я хрен знает почему
    {
        int n1 = Convert.ToInt32(Console.ReadLine());
        int[] numbers1 = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int n2 = Convert.ToInt32(Console.ReadLine());
        int[] numbers2 = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        Dictionary<int, int> reapeats = new Dictionary<int, int>();
        int[] resultArray = new int[n1];
        for (int i = 0, j = 0; i < n1; i++)
        {
            if (numbers2.Contains(numbers1[i]))
            {
                if (!reapeats.ContainsKey(numbers1[i]))
                {
                    reapeats.Add(numbers1[i], 1);
                    resultArray[j] = numbers1[i];
                    j++;
                }
                else
                {
                    if (numbers2.Count((n) => (n == numbers1[i])) > reapeats[numbers1[i]])
                    {
                        reapeats[numbers1[i]] += 1;
                        resultArray[j] = numbers1[i];
                        j++;
                    }
                }
            }
        }
        Console.WriteLine(resultArray.Count((n) => (n != 0)));
        foreach (var number in resultArray)
        {
            if (number != 0) Console.Write(number + " ");
        }
    }
    public static void PerformTask2024()//Сделать палиндром
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int answer = 0;
        if (n % 2 == 0)
        {
            int[] nums1 = numbers.Take(n / 2).ToArray();
            int[] nums2 = numbers.Skip((n / 2)).Reverse().ToArray();
            for (int i = 0; i < n / 2; i++)
            {
                if (nums1[i] != nums2[i]) answer++;
            }
        }
        else
        {
            int[] nums1 = numbers.Take(n / 2).ToArray();
            int[] nums2 = numbers.Skip(n / 2 + 1).Reverse().ToArray();
            for (int i = 0; i < n / 2; i++)
            {
                if (nums1[i] != nums2[i]) answer++;
            }
        }
        Console.WriteLine(answer);
    }
    public static void PerformTask2025() { }
    public static void PerformTask2026() { }
    public static void PerformTask2027() { }
    public static void PerformTask2028() { }
    public static void PerformTask2029() { }
    public static void PerformTask2030() { }
    public static void PerformTask2031() { }
    public static void PerformTask2032() { }
    public static void PerformTask2033() { }
    public static void PerformTask2034() { }
    public static void PerformTask2035() { }
}
