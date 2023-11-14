namespace path_to_space_app;

internal static class Tasks
{
    static public void PerformTask2001()//A+B
    {
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        Console.WriteLine(numbers.Sum());
    }
    static public void PerformTask2002()//Сумма чисел
    {
        Console.ReadLine();//не нужно, но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        Console.WriteLine(numbers.Sum());
    }
    static public void PerformTask2003()//Альтернированная сумма чисел
    {
        Console.ReadLine();//не нужно, но в задаче должно быть
        int negativator = 0;
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s) * (int)Math.Pow(-1, negativator++));
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
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
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
        int maxWeight = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s))[1];
        int[] cargoWeights = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int numberLoads = 0;
        int loadWeight = 0;
        foreach (int weight in cargoWeights)
        {
            if (maxWeight > loadWeight + weight)
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
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int resultSum = 0;
        for (int i = 1, j = 1; i < arrayLength; i = (int)Math.Pow(2, j++))
        {
            resultSum += numbers[i - 1];
        }
        Console.WriteLine(resultSum);
    }
    public static void PerformTask2010()//Алгоритм Евклида 
    {
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
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
    public static void PerformTask2012() { }
    public static void PerformTask2013() { }
    public static void PerformTask2014() { }
    public static void PerformTask2015() { }
    public static void PerformTask2016() { }
    public static void PerformTask2017() { }
    public static void PerformTask2018() { }
    public static void PerformTask2019() { }
    public static void PerformTask2020() { }
}
