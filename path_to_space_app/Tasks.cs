using System.Text;
using System.Text.RegularExpressions;

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
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        int stepCounter = 0;
        int part = 0;
        while (Array.TrueForAll(numbers, n => n > 0))
        {
            if (numbers[0] > numbers[1])
            {
                part = numbers[0] / numbers[1];
                numbers[0] -= numbers[1] * part;
                stepCounter += part;
            }
            else
            {
                part = numbers[1] / numbers[0];
                numbers[1] -= numbers[0] * part;
                stepCounter += part;
            }
        }
        Console.WriteLine($"{stepCounter} {numbers.Max()}");
    }
    public static void PerformTask2015()//Простые на отрезке 
    {
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (IsPrime(i))
                Console.WriteLine(i);
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
        var toDictionary = numbers.GroupBy((n) => (n)).ToDictionary((c) => (c.Key), (c) => (c.Count()));
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
                if (i != j)
                    counter = numbers[j] % numbers[i] == 0 ? counter + 1 : counter;
            }
        }
        Console.WriteLine(counter);
    }
    public static void PerformTask2023()//Поиск во втором массиве
    {
        int n1 = Convert.ToInt32(Console.ReadLine());
        int[] numbers1 = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int n2 = Convert.ToInt32(Console.ReadLine());
        int[] numbers2 = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int[] resultArray = new int[n1];
        for (int i = 0, j = 0; i < n1; i++)
        {
            if (numbers2.Contains(numbers1[i]))
            {
                resultArray[j] = numbers1[i];
                j++;
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
                if (nums1[i] != nums2[i])
                    answer++;
            }
        }
        else
        {
            int[] nums1 = numbers.Take(n / 2).ToArray();
            int[] nums2 = numbers.Skip(n / 2 + 1).Reverse().ToArray();
            for (int i = 0; i < n / 2; i++)
            {
                if (nums1[i] != nums2[i])
                    answer++;
            }
        }
        Console.WriteLine(answer);
    }
    public static void PerformTask2025()//Запросы минимума на подмассиве
    {
        int n = Convert.ToInt32(Console.ReadLine());//не понадобилось но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int m = Convert.ToInt32(Console.ReadLine());
        int[] resultArray = new int[m];
        int[] twoNumbers = new int[2];
        for (int i = 0; i < m; i++)
        {
            twoNumbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
            resultArray[i] = numbers.Skip(twoNumbers[0] - 1).Take(twoNumbers[1] - twoNumbers[0] + 1).Min();
        }
        for (int i = 0; i < m; i++)
        {
            Console.WriteLine(resultArray[i]);
        }
    }
    public static void PerformTask2026()//Ближайший справа больший
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int[] resultArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            resultArray[i] = numbers.Skip(i).FirstOrDefault((s) => (s > numbers[i]), 0);
        }
        foreach (var number in resultArray)
        {
            Console.Write(number + " ");
        }
    }
    public static void PerformTask2027()//Два переворота
    {
        int n = Convert.ToInt32(Console.ReadLine());//не понадобилось но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int[] twoNumbers = new int[2];
        twoNumbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        MakeFlip(numbers, twoNumbers[0], twoNumbers[1]);
        twoNumbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        MakeFlip(numbers, twoNumbers[0], twoNumbers[1]);
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
    }
    private static void MakeFlip(int[] startArray, int a, int b)
    {
        int tampVal = 0;
        int centre = (b - a) == 1 ? a : (b - a) / 2 + a;
        for (int i = a - 1, j = 0; i < centre; i++, j++)
        {
            tampVal = startArray[i];
            startArray[i] = startArray[b - 1 - j];
            startArray[b - 1 - j] = tampVal;
        }
    }
    public static void PerformTask2028()//Числа 0-4
    {
        int n = Convert.ToInt32(Console.ReadLine());//не понадобилось но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        var toDictionary = numbers.GroupBy((num) => (num)).ToDictionary((c) => (c.Key), (c) => (c.Count())).OrderBy((d) => (d.Key));

        foreach (var number in toDictionary)
        {
            Console.WriteLine($"{number.Key}  {number.Value}");
        }
    }
    public static void PerformTask2029()//Средний минимум
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int minNumber = numbers.Min();
        int countMinNumber = numbers.Count(x => x == minNumber);
        int needSkipNumber = countMinNumber % 2 == 0 ? countMinNumber / 2 : countMinNumber / 2 + 1;
        int i = 0;
        for (; i < n && needSkipNumber > 0; i++)
        {
            if (numbers[i] == minNumber)
                needSkipNumber--;
        }
        Console.WriteLine(i);
    }
    public static void PerformTask2030()//Подмассивы с нулевой суммой
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int pairNumberCounter = 0;
        int tempSum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                for (int k = i; k <= j; k++)
                {
                    tempSum += numbers[k];
                }
                if (tempSum == 0)
                    pairNumberCounter++;
                tempSum = 0;
            }
        }
        Console.WriteLine(pairNumberCounter);
    }
    public static void PerformTask2031()//Антиуникальные числа
    {
        int n = Convert.ToInt32(Console.ReadLine());//не понадобилось но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int[] nonUniqueNumber = numbers.GroupBy((num) => (num)).Where((z) => (z.Count() >= 2)).Select((x) => (x.Key)).ToArray();
        Array.Sort(nonUniqueNumber);
        Console.WriteLine(nonUniqueNumber.Length);
        foreach (var number in nonUniqueNumber)
        {
            Console.Write(number + " ");
        }
    }
    public static void PerformTask2032()//Сравнение длинных чисел
    {
        int n1 = Convert.ToInt32(Console.ReadLine());
        int[] number1 = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int n2 = Convert.ToInt32(Console.ReadLine());
        int[] number2 = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        bool isEqual = true;
        if (n1 < n2)
        {
            Console.WriteLine(-1);
        }
        else if (n1 > n2)
        {
            Console.WriteLine(1);
        }
        else
        {
            for (int i = 0; i < n1; i++)
            {
                if (number1[i] < number2[i])
                {
                    Console.WriteLine(-1);
                    isEqual = false;
                    break;
                }
                else if (number1[i] > number2[i])
                {
                    Console.WriteLine(1);
                    isEqual = false;
                    break;
                }
            }
            if (isEqual)
                Console.WriteLine(0);
        }
    }
    public static void PerformTask2033()//Прибавление единицы к длинному числу
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] number = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int[] result = new int[n + 1];
        bool needPlus = true;
        for (int i = n - 1; i >= 0; i--)
        {
            if (needPlus)
            {
                if (number[i] + 1 != 10)
                {
                    result[i + 1] = number[i] + 1;
                    needPlus = false;
                }
                else
                {
                    result[i + 1] = 0;
                }
            }
            else
            {
                result[i + 1] = number[i];
            }
        }
        result[0] = result[1] == 0 ? 1 : 0;
        if (result[0] == 0)
        {
            Console.WriteLine(n);
            for (int i = 1; i < n + 1; i++)
                Console.Write(result[i] + " ");
        }
        else
        {
            Console.WriteLine(n + 1);
            foreach (int num in result)
                Console.Write(num + " ");
        }
    }
    public static void PerformTask2034()//Наидлиннейший почти константный подмассив
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] number = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int countMaxLenght = 0;
        int a = 0;
        int b = 0;
        int tempLenghtL = 0;
        int tempLenghtR = 0;
        int tempLenght = 0;
        for (int i = 0; i < n - countMaxLenght; ++i)
        {
            var tempCollect = number.Skip(i);
            tempLenghtL = tempCollect.TakeWhile((n) => (number[i] - n == -1 || number[i] - n == 0)).ToArray().Length;
            tempLenghtR = tempCollect.TakeWhile((n) => (number[i] - n == 1 || number[i] - n == 0)).ToArray().Length;
            tempLenght = tempLenghtL > tempLenghtR ? tempLenghtL : tempLenghtR;
            if (tempLenght > countMaxLenght)
            {
                a = i + 1;
                b = a + tempLenght - 1;
                countMaxLenght = tempLenght;
            }
        }
        Console.WriteLine($"{a} {b}");
    }
    public static void PerformTask2035()//Период массива
    {
        int n = Convert.ToInt32(Console.ReadLine());
        List<int> numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s)).ToList<int>();
        int[] arrayDivider = GetNumberDivider(n);
        int answer = 0;
        List<int> tempShortArray = new List<int>();
        List<int> tempLongtArray = new List<int>();
        for (int i = 0; i < arrayDivider.Length; i++)
        {
            tempShortArray = numbers.GetRange(0, arrayDivider[i]);
            int j = 0;
            for (; j < n / arrayDivider[i]; j++)
            {
                tempLongtArray.AddRange(tempShortArray);
            }
            if (tempLongtArray.SequenceEqual(numbers))
            {
                answer = arrayDivider[i];
                break;
            }
            tempLongtArray = new List<int>();
        }
        Console.WriteLine(answer);
    }
    private static int[] GetNumberDivider(int n)
    {
        List<int> resultArray = new List<int>() { };
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                resultArray.Add(i);
            }
        }
        return resultArray.ToArray();
    }
    public static void PerformTask2036()//Строки. Странные слова
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] words = new string[n];
        for (int i = 0; i < n; i++)
        {
            string tempString = Console.ReadLine()!;
            if (ChekcWord(tempString))
            {
                words[i] = tempString;
            }
        }
        foreach (string word in words)
        {
            if (word != null)
                Console.WriteLine(word);
        }
    }
    private static bool ChekcWord(string startString)
    {
        char[] chars = { 'e', 'y', 'u', 'i', 'o', 'a' };
        int threeObserver = 0;
        for (int i = 0; i < startString.Length && threeObserver < 3; i++)
        {
            if (chars.Contains(startString[i]))
                threeObserver++;
            else
                threeObserver = 0;
        }
        return threeObserver == 3 ? false : true;
    }
    public static void PerformTask2037()//Строки. Слишком короткие слова
    {
        string startString = Console.ReadLine()!;
        int k = Convert.ToInt32(Console.ReadLine());
        string[] words = startString.Split(',');
        Console.WriteLine(string.Join(",", words.Where((s) => (s.Length >= k)).ToArray()));
    }
    public static void PerformTask2038()//Строки. Самое длинное слово
    {
        string startString = Console.ReadLine()!;
        char[] separators = startString.GroupBy((ch) => (ch)).Where((ch) => (!Char.IsLetter(ch.Key))).Select((ch) => (ch.Key)).ToArray();
        string[] words = startString.Split(separators);
        Console.WriteLine(words.Select((st) => (st.Length)).Max());
    }
    public static void PerformTask2039()//Строки. Количество слов в тексте
    {
        string startString = Console.ReadLine()!;
        char[] separators = startString.GroupBy((ch) => (ch)).Where((ch) => (!Char.IsLetter(ch.Key))).Select((ch) => (ch.Key)).ToArray();
        string[] words = startString.Split(separators).Where((s) => (s != "")).ToArray();
        Console.WriteLine(words.Length);
    }
    public static void PerformTask2040()//Строки. Наименьший циклический сдвиг
    {
        string startString = Console.ReadLine()!;
        string minShift = startString;
        for (int k = 0; k < startString.Length; k++)
        {
            string tempSt = string.Join("", startString.Skip(k).Concat(startString.Take(k)).ToArray());
            if (String.Compare(minShift, tempSt) > 0)
            {
                minShift = tempSt;
            }
        }
        Console.WriteLine(minShift);
    }
    public static void PerformTask2041()//Строки. Два палиндрома
    {
        string startString = Console.ReadLine()!;
        for (int i = 0; i < startString.Length; i++)
        {
            if (CheckPalindrome(startString.Take(i)) && CheckPalindrome(startString.Skip(i)))
            {
                Console.WriteLine("YES");
                return;
            }
        }
        Console.WriteLine("NO");
    }
    private static bool CheckPalindrome(IEnumerable<Char> startString)
    {
        int stringLength = startString.Count();
        var leftArray = startString.Take(stringLength / 2);
        var rightArray = startString.Skip(stringLength % 2 == 0 ? stringLength / 2 : stringLength / 2 + 1).Reverse();
        bool isPalindrome = Enumerable.SequenceEqual(leftArray, rightArray);
        if (stringLength == 0 || stringLength == 1 || isPalindrome)
        {
            return true;
        }
        return false;
    }
    public static void PerformTask2042()//Строки. Поиск образца в тексте
    {
        char[] startString = (Console.ReadLine()!).ToArray();
        int startStringLenght = startString.Length;
        string pattern = Console.ReadLine()!;
        int patternLength = pattern.Length;
        pattern = pattern.Replace("?", "\\w");
        Regex regex = new Regex(pattern);
        List<int> answers = new List<int>();
        for (int i = 0; i < startStringLenght; i++)
        {
            if (regex.IsMatch(String.Join("", startString.Take(patternLength).ToArray())))
            {
                answers.Add(i);
            }
            startString = startString.Skip(1).ToArray();
        }
        foreach (int i in answers)
        {
            Console.Write((i + 1) + " ");
        }
    }
    public static void PerformTask2043()//Строки. Простой XML
    {
        char[] startString = (Console.ReadLine()!).ToArray();
        int startStringLenght = startString.Length;
        Regex regex = new Regex(@"<\w>");
        int spaceCounter = -1;
        string tempString = "";
        for (int i = 0; i < startStringLenght - 4; i++)
        {
            tempString = String.Join("", startString.Take(3).ToArray());
            if (regex.IsMatch(tempString))
            {
                spaceCounter++;
                for (int j = 0; j < spaceCounter * 2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(tempString + "\n");
                startString = startString.Skip(3).ToArray();
            }
            else
            {
                for (int j = 0; j < spaceCounter * 2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(String.Join("", startString.Take(4).ToArray()) + "\n");
                spaceCounter--;
                startString = startString.Skip(4).ToArray();
            }
        }
    }
    public static void PerformTask2044()//Строки. Декодирование по алгоритму Хаффмана
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Dictionary<string, string> codeHuffman = new Dictionary<string, string>();
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine()!.Split();
            codeHuffman.Add(data[1], data[0]);
        }
        string[] code = codeHuffman.Keys.ToArray();
        char[] startString = (Console.ReadLine()!).ToArray();
        for (int i = 0, j = 1; startString.Length > 0; i++)
        {
            while (!code.Contains(String.Join("", startString.Take(j).ToArray())))
            {
                j++;
            }
            Console.Write(codeHuffman[String.Join("", startString.Take(j).ToArray())]);
            startString = startString.Skip(j).ToArray();
            j = 1;
        }
    }
    public static void PerformTask2045()//Строки. Пунктуация
    {
        string[] startString = Console.ReadLine()!.Split().Where((s) => (s != "")).ToArray();
        char[] punctuationMarks = { '.', ',', '!', '?' };
        for (int i = 0; i < startString.Length; i++)
        {
            if (punctuationMarks.Contains(startString[i][0]))
            {
                startString[i - 1] = startString[i - 1] + startString[i][0];
                startString[i] = startString[i].Substring(1) == "" ? " " : startString[i].Substring(1);
                i--;
            }
            else if (startString[i].Take(startString[i].Length - 1).ToArray().Intersect(punctuationMarks).Count() != 0)
            {
                int tempLenght = startString[i].Length;
                for (int j = 0; j < tempLenght - 1; j++)
                {
                    if (punctuationMarks.Contains(startString[i][j]))
                    {
                        startString[i] = startString[i].Insert(++j, " ");
                        tempLenght++;
                    }
                }
            }
        }
        Console.WriteLine(String.Join(" ", startString.Where((s) => (s != " "))));
    }
    public static void PerformTask2046()//Морской бой 
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] answers = new string[n];
        char[][] battlefield = new char[10][];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                battlefield[j] = (Console.ReadLine()!).ToArray();
            }
            if (battlefield.Select((b) => (b.Count((c) => (c == '*')))).Sum() == 20)
            {
                int smallShipCounter = 0;
                for (int j = 1; j < 9; j++)
                {
                    for (int k = 1; k < 9; k++)
                    {
                        if (battlefield[j][k] == '*')
                        {
                            bool starOnDiagonal = battlefield[j - 1][k - 1] == '*' || battlefield[j + 1][k + 1] == '*' || battlefield[j - 1][k + 1] == '*' || battlefield[j + 1][k - 1] == '*';
                            bool starsOnCross = (battlefield[j - 1][k] == '*' || battlefield[j + 1][k] == '*') && (battlefield[j][k - 1] == '*' || battlefield[j][k + 1] == '*');
                            if (starOnDiagonal || starsOnCross)
                            {
                                answers[i] = "NO";
                            }
                            if (battlefield[j - 1][k] == '0' && battlefield[j + 1][k] == '0' && battlefield[j][k - 1] == '0' && battlefield[j][k + 1] == '0')
                            {
                                smallShipCounter++;
                            }

                        }
                    }
                }
                for (int j = 1; j < 9; j++)
                {
                    if (battlefield[0][j] == '*' && battlefield[0][j + 1] == '0' && battlefield[0][j - 1] == '0' && battlefield[1][j] == '0')
                    {
                        smallShipCounter++;
                    }
                    if (battlefield[9][j] == '*' && battlefield[9][j + 1] == '0' && battlefield[9][j - 1] == '0' && battlefield[8][j] == '0')
                    {
                        smallShipCounter++;
                    }
                    if (battlefield[j][0] == '*' && battlefield[j + 1][0] == '0' && battlefield[j - 1][0] == '0' && battlefield[j][1] == '0')
                    {
                        smallShipCounter++;
                    }
                    if (battlefield[j][9] == '*' && battlefield[j + 1][9] == '0' && battlefield[j - 1][9] == '0' && battlefield[j][8] == '0')
                    {
                        smallShipCounter++;
                    }
                }
                if (battlefield[0][0] == '*' && battlefield[0][1] == '0' && battlefield[1][0] == '0')
                {
                    smallShipCounter++;
                }
                if (battlefield[9][9] == '*' && battlefield[9][8] == '0' && battlefield[8][9] == '0')
                {
                    smallShipCounter++;
                }
                if (battlefield[0][9] == '*' && battlefield[0][8] == '0' && battlefield[1][9] == '0')
                {
                    smallShipCounter++;
                }
                if (battlefield[9][0] == '*' && battlefield[8][0] == '0' && battlefield[9][1] == '0')
                {
                    smallShipCounter++;
                }
                if (smallShipCounter != 4)
                {
                    answers[i] = "NO";
                }
                smallShipCounter = 0;
                for (int j = 4; j < 6; j++)
                {
                    for (int k = 4; k < 6; k++)
                    {
                        if (battlefield[j][k] == '*')
                        {
                            bool havUp = battlefield[j - 1][k] == '*' && battlefield[j - 2][k] == '*' && battlefield[j - 3][k] == '*' && battlefield[j - 4][k] == '*';
                            bool havDown = battlefield[j + 1][k] == '*' && battlefield[j + 2][k] == '*' && battlefield[j + 3][k] == '*' && battlefield[j + 4][k] == '*';
                            bool havRight = battlefield[j][k + 1] == '*' && battlefield[j][k = 2] == '*' && battlefield[j][k + 3] == '*' && battlefield[j][k + 4] == '*';
                            bool havLeft = battlefield[j][k - 1] == '*' && battlefield[j][k - 2] == '*' && battlefield[j][k - 3] == '*' && battlefield[j][k - 4] == '*';
                            if (havUp || havDown || havRight || havLeft)
                            {
                                answers[i] = "NO";
                            }
                        }
                    }
                }
            }
            else
            {
                answers[i] = "NO";
            }
            if (i != n - 1)
            {
                Console.ReadLine();
            }
            answers[i] = answers[i] == "NO" ? "NO" : "YES";
        }
        foreach (var i in answers)
        {
            Console.WriteLine(i);
        }
    }
    public static void PerformTask2047()//Выравнивание по центру
    {
        List<string> text = new List<string>();
        string tempString = "Ну работай плиз";
        do
        {
            tempString = Console.ReadLine()!;
            if (tempString != null)
                text.Add(tempString);

        } while (tempString != null);
        int maxLenght = text.Select((t) => (t.Length)).Max();
        for (int i = 0; i < maxLenght + 2; i++)
            Console.Write("*");
        Console.Write("\n");
        int leftObserver = 0;
        int rightObserver = 0;
        bool leftOrRight = true;
        for (int i = 0; i < text.Count(); i++)
        {
            int tempLenght = text[i].Length;
            Console.Write("*");
            if ((maxLenght - tempLenght) % 2 == 0)
            {
                leftObserver = 0;
                rightObserver = 0;
            }
            else if (leftOrRight)
            {
                leftObserver = 0;
                rightObserver = 1;
                leftOrRight = false;
            }
            else
            {
                leftObserver = 1;
                rightObserver = 0;
                leftOrRight = true;
            }
            for (int j = 0; j < (maxLenght - tempLenght) / 2 + leftObserver; j++)
            {
                Console.Write(" ");
            }
            Console.Write(text[i]);
            for (int j = 0; j < (maxLenght - tempLenght) / 2 + rightObserver; j++)
            {
                Console.Write(" ");
            }

            Console.Write("*\n");
        }
        for (int i = 0; i < maxLenght + 2; i++)
            Console.Write("*");
    }
    public static void PerformTask2048()//Каталоги
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] paths = new string[n];
        for (int i = 0; i < n; i++)
        {
            paths[i] = Console.ReadLine()!;
        }
        Array.Sort(paths);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (paths[j].IndexOf("/" + new string(paths[i].TakeWhile(x => x != '/').ToArray())) != -1 && i != j)
                {
                    paths[i] = new string(paths[j].Take(paths[j].IndexOf("/" + new string(paths[i].TakeWhile(x => x != '/').ToArray())) + 1).ToArray()) + paths[i];
                    break;
                }
            }
        }
        StringBuilder spacePath = new StringBuilder();
        List<string> answers = new List<string>();
        foreach (string path in paths)
        {
            string endPath = path;
            for (int i = 0; i <= path.Count(p => p == '/'); i++)
            {
                string startPath = new string(endPath.TakeWhile(x => x != '/').ToArray());
                endPath = new string(endPath.Skip(startPath.Length + 1).ToArray());
                for (int j = 0; j < i; j++)
                {
                    spacePath.Append('+');
                }
                spacePath.Append(startPath);
                answers.Add(spacePath.ToString());
                spacePath.Clear();
            }
        }
        foreach (string path in answers.Distinct())
        {
            Console.WriteLine(path);
        }
    }
    public static void PerformTask2049()//Менеджер памяти
    {
        int[] data = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        bool[] memory = new bool[data[1]];
        Dictionary<int, int[]> fragment = new Dictionary<int, int[]>();
        for (int i = 0, k = 1; i < data[0]; i++)
        {
            string operation = Console.ReadLine()!;
            if (operation[0] == 'a')
            {
                int needMermory = Convert.ToInt32(string.Join("", operation.Skip(6).ToArray()));
                bool isDone = false;
                for (int j = 0; j < data[1] - needMermory + 1; j++)
                {
                    if (memory.Skip(j).Take(needMermory).Count(m => m == false) == needMermory)
                    {
                        fragment.Add(k, new int[] { j, needMermory });
                        Console.WriteLine(k);
                        for (int h = j; h < j + needMermory; h++)
                        {
                            memory[h] = true;
                        }
                        isDone = true;
                        k++;
                        break;
                    }
                }
                if (!isDone)
                {
                    Console.WriteLine("NULL");
                    isDone = false;
                }
            }
            else if (operation[0] == 'e')
            {
                int fragmentDelete = Convert.ToInt32(string.Join("", operation.Skip(6).ToArray()));
                if (fragment.ContainsKey(fragmentDelete))
                {
                    for (int j = fragment[fragmentDelete][0]; j < fragment[fragmentDelete][0] + fragment[fragmentDelete][1]; j++)
                    {
                        memory[j] = false;
                    }
                    fragment.Remove(fragmentDelete);
                }
                else
                    Console.WriteLine("ILLEGAL_ERASE_ARGUMENT");
            }
            else
            {
                int busyMemory = memory.Count(m => m == true);
                memory = new bool[data[1]];
                for (int j = 0; j < busyMemory; j++)
                {
                    memory[j] = true;
                }
                int memoryObserver = 0;
                foreach (var temp in fragment.OrderBy(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value))
                {
                    fragment[temp.Key] = new int[] { memoryObserver, fragment[temp.Key][1] };
                    memoryObserver += fragment[temp.Key][1];
                }
            }
        }
    }
    public static void PerformTask2050()//Ini-файл
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] iniFail = new string[n];
        for (int i = 0; i < n; i++)
        {
            iniFail[i] = Console.ReadLine()!;
        }
        iniFail = iniFail.Select(s => s.Contains('=') ? string.Join("", s.TakeWhile(t => t != '=').ToArray()).Trim() + "=" + string.Join("", s.SkipWhile(t => t != '=').Skip(1).ToArray()).Trim() : s.Replace(" ", "")).Where(s => s != "" && s[0] != ';'&& s != "\n").ToArray();
        Dictionary<string, string[]> iniBlocks = new Dictionary<string, string[]>();
        iniBlocks.Add("[]", new string[] { });
        string[] tempString = new string[] { };
        for (int i = 0; i < iniFail.Length; i++)
        {
            if (iniFail[i].StartsWith("["))
            {
                tempString = iniFail.Skip(i + 1).TakeWhile(s => !s.StartsWith("[")).ToArray();
                if (iniBlocks.ContainsKey(iniFail[i]))
                {
                    iniBlocks[iniFail[i]] = iniBlocks[iniFail[i]].Concat(tempString).ToArray();
                }
                else
                {
                    iniBlocks.Add(iniFail[i], tempString);
                }
                i += tempString.Length;
            }
            else
            {
                tempString = iniFail.Skip(i).TakeWhile(s => !s.StartsWith("[")).ToArray();
                iniBlocks["[]"] = iniBlocks["[]"].Concat(tempString).ToArray();
                i += tempString.Length - 1;
            }
        }
        string[] fragments = iniBlocks.Keys.ToArray();
        Array.Sort(fragments);
        foreach (string key in fragments)
        {
            if (key != "[]")
                Console.WriteLine(key);
            string[] tempArray = iniBlocks[key].ToArray();
            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    if (tempArray[j].StartsWith(string.Join("", tempArray[i].TakeWhile(s => s != '=').ToArray()) + "="))
                    {
                        tempArray[i] = "";
                        break;
                    }
                }
            }
            Array.Sort(tempArray);
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] != "")
                    Console.WriteLine(tempArray[i]);
            }
        }
    }
    public static void PerformTask2051()//Структуры данных. Скобочки
    {
        char[] PSP = Console.ReadLine()?.ToArray()!;
        Stack<int> tempBag = new Stack<int>();
        int[][] answers = new int[PSP.Length / 2][];
        for (int i = 0, j = 0; i < PSP.Length; i++)
        {
            if (PSP[i] == '(')
                tempBag.Push(i + 1);
            else
                answers[j++] = new int[] { tempBag.Pop(), (i + 1) };
        }
        foreach (var temp in answers.OrderBy(t => t[0]))
        {
            Console.WriteLine(temp[0] + " " + temp[1]);
        }
    }
    public static void PerformTask2052()//Структуры данных. Вычеркиваем числа
    {
        int[] parametrs = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        List<int> numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s)).ToList<int>();
        int[] data = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        for (int i = 0; i < parametrs[1]; i++)
        {
            int j = data[i];
            for (; j <= numbers.Count();)
            {
                numbers[j - 1] = 0;
                j += data[i];
            }
            numbers = numbers.Where(x => x != 0).ToList();
        }
        foreach (int i in numbers)
            if (i != 0)
                Console.Write(i + " ");
    }
    public static void PerformTask2053()//Структуры данных. Шифрование
    {
        List<string> text = new List<string>();
        string tempString = "Ну работай плиз";
        do
        {
            tempString = Console.ReadLine()!;
            if (tempString != null)
                text.Add(tempString);

        } while (tempString != null);
        Dictionary<string, int> coding = new Dictionary<string, int>();
        int codihgCounter = 1;
        for (int i = 0; i < text.Count(); i++)
        {
            string[] splitText = text[i].Split(' ');
            for (int j = 0; j < splitText.Length; j++)
            {
                if (coding.ContainsKey(splitText[j].Replace("\n", "").ToLower()) && splitText[j] != "")
                {
                    Console.Write(coding[splitText[j].Replace("\n", "").ToLower()] + " ");
                }
                else if (splitText[j] != "")
                {
                    Console.Write(codihgCounter + " ");
                    coding.Add(splitText[j].Replace("\n", "").ToLower(), codihgCounter);
                    codihgCounter++;
                }
            }
        }
    }
    public static void PerformTask2054()//Структуры данных. Последовательности
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Dictionary<int, List<int>> answers = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s))).Skip(1).ToArray();
            for (int j = 0; j < numbers.Length; j++)
            {
                if (answers.ContainsKey(numbers[j]))
                {
                    answers[numbers[j]].Add(i + 1);
                }
                else
                {
                    answers.Add(numbers[j], new List<int>() { i + 1 });
                }
            }
        }
        int[] keys = answers.Keys.ToArray();
        Array.Sort(keys);
        foreach (int key in keys)
        {
            Console.Write(key + " ");
            List<int> tempBag = answers[key].Distinct().ToList();
            tempBag.Sort();
            foreach (int value in tempBag)
            {
                Console.Write(value + " ");
            }
            Console.Write("\n");
        }
    }
    public static void PerformTask2055()//Структуры данных.Период и предпериод
    {
        int[] data = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        int a = data[0];
        int X = data[1];
        int Y = data[2];
        int M = data[3];
        Dictionary<int, string> uniqueNumbers = new Dictionary<int, string>();
        uniqueNumbers.Add(a, "");
        int next = -1;
        while (true)
        {
            next = (X * a + Y) % M;
            a = next;
            if (uniqueNumbers.ContainsKey(next))
                break;
            else
                uniqueNumbers.Add(next, "");
        }
        int cycleLength = uniqueNumbers.Keys.SkipWhile(x => x != a).Count();
        int NumberOutCycleElemts = uniqueNumbers.Keys.TakeWhile(x => x != a).Count();
        Console.WriteLine(cycleLength + " " + NumberOutCycleElemts);
    }
    public static void PerformTask2056()//Структуры данных. Самое популярное слово
    {
        List<string> text = new List<string>();
        string tempString = "Ну работай плиз";
        do
        {
            tempString = Console.ReadLine()!;
            if (tempString != null)
                text.Add(tempString);

        } while (tempString != null);
        Dictionary<string, int> wordCounter = new Dictionary<string, int>();
        for (int i = 0; i < text.Count(); i++)
        {
            string[] splitText = text[i].Split(' ');
            for (int j = 0; j < splitText.Length; j++)
            {
                string tempWord = splitText[j].Replace("\n", "").ToLower();
                if (wordCounter.ContainsKey(tempWord) && splitText[j] != "")
                {
                    wordCounter[tempWord] += 1;
                }
                else if (splitText[j] != "")
                {
                    wordCounter.Add(tempWord, 1);
                }
            }
        }
        int numberCommonWord = wordCounter.Values.Max();
        string[] answers = wordCounter.Where(x => x.Value == numberCommonWord).Select(x => x.Key).ToArray();
        Array.Sort(answers);
        foreach (string answer in answers)
            Console.WriteLine(answer);
    }
    public static void PerformTask2057()//Структуры данных.Множество
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Dictionary<int, int> numberCounter = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            int[] data = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
            if (data[0] == 1)
            {
                if (numberCounter.ContainsKey(data[1]))
                {
                    numberCounter[data[1]] += 1;
                }
                else
                {
                    numberCounter.Add(data[1], 1);
                    numberCounter = numberCounter.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                }
            }
            else
            {
                if (numberCounter[numberCounter.Keys.ToArray()[0]] - 1 != 0)
                {
                    Console.WriteLine(numberCounter.Keys.ToArray()[0]);
                    numberCounter[numberCounter.Keys.ToArray()[0]] -= 1;
                }
                else
                {
                    Console.WriteLine(numberCounter.Keys.ToArray()[0]);
                    numberCounter.Remove(numberCounter.Keys.ToArray()[0]);
                }
            }
        }
    }
    public static void PerformTask2058()//Структуры данных. Количество подстрок
    {
        char[] startString = Console.ReadLine()?.ToArray()!;
        Dictionary<string, int> subStrings = new Dictionary<string, int>();
        for (int i = 1; i <= startString.Length; i++)
        {
            for (int j = 0; j + i <= startString.Length; j++)
            {
                string tempKey = string.Join("", startString.Skip(j).Take(i).ToArray());
                if (!subStrings.ContainsKey(tempKey))
                {
                    subStrings.Add(tempKey, 0);
                }
            }
        }
        Console.WriteLine(subStrings.Count());
    }
    public static void PerformTask2059()//Структуры данных. Левее, больше... но меньше
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] startData = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        Dictionary<int, string> uniqueNumber = new Dictionary<int, string>();
        for (int i = 0; i < n; i++)
        {
            var tempNumbers = uniqueNumber.Keys.Where(x => x > startData[i]);
            if (uniqueNumber.ContainsKey(startData[i]))
            {
                Console.Write((tempNumbers.Count() > 0 ? uniqueNumber.Keys.Where(x => x > startData[i]).Min() : -1) + " ");
            }
            else
            {
                Console.Write((tempNumbers.Count() > 0 ? uniqueNumber.Keys.Where(x => x > startData[i]).Min() : -1) + " ");
                uniqueNumber.Add(startData[i], "");
            }
        }
    }
    public static void PerformTask2060()//Структуры данных. Система учета оценок
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Dictionary<string, List<int>> answers = new Dictionary<string, List<int>>();
        for (int i = 0; i < n; i++)
        {
            string[] nameRating = Console.ReadLine()?.Split()!;
            if (answers.ContainsKey(nameRating[0]))
            {
                answers[nameRating[0]].Add(Convert.ToInt32(nameRating[1]));
            }
            else
            {
                answers.Add(nameRating[0], new List<int>() { Convert.ToInt32(nameRating[1]) });
            }
        }
        string[] names = answers.Keys.ToArray();
        Array.Sort(names);
        foreach (string name in names)
        {
            Console.WriteLine(name + " " + (int)answers[name].Sum() / answers[name].Count());
        }
    }
    public static void PerformTask2061()//Структуры данных. Форум
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Dictionary<string, List<string>> answers = new Dictionary<string, List<string>>();
        for (int i = 0; i < n - 1; i++)
        {
            string[] data = Console.ReadLine()?.Split()!;
            if (answers.ContainsKey(data[1]))
            {
                answers[data[1]].Add(data[0]);
            }
            else
            {
                answers.Add(data[1], new List<string>() { data[0] });
            }
        }
        string tempName = "main";
        Console.WriteLine(tempName);
        GetDescendants(answers, tempName, 0);
    }
    private static void GetDescendants(Dictionary<string, List<string>> answers, string tempName, int n)
    {
        if (!answers.ContainsKey(tempName))
        {
            return;
        }
        n++;
        answers[tempName].Sort();
        foreach (var temp in answers[tempName])
        {
            for (int i = 1; i <= n * 2; i++)
                Console.Write(" ");
            Console.WriteLine(temp);
            GetDescendants(answers, temp, n);
        }
    }
    public static void PerformTask2062()//Структуры данных. Точки
    {
        int[] startData = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        Dictionary<string, Point> points = new Dictionary<string, Point>();
        for (int i = 0; i < startData[0]; i++)
        {
            string represent = Console.ReadLine()!;
            int[] coordinats = Array.ConvertAll(represent.Split(), (s) => (int.Parse(s)));
            points.Add(represent, new Point(coordinats[0], coordinats[1]));
        }
        for (int i = 0; i < startData[1]; i++)
        {
            string[] srtPoint = points.Keys.ToArray();
            foreach (string srt in srtPoint)
            {
                string upPoint = points[srt].x + " " + (points[srt].y + 1);
                string dowmPoint = points[srt].x + " " + (points[srt].y - 1);
                string leftPoint = (points[srt].x - 1) + " " + points[srt].y;
                string rightPoint = (points[srt].x + 1) + " " + points[srt].y;
                if (!points.ContainsKey(upPoint))
                    points.Add(upPoint, new Point(points[srt].x, points[srt].y + 1));
                if (!points.ContainsKey(dowmPoint))
                    points.Add(dowmPoint, new Point(points[srt].x, points[srt].y - 1));
                if (!points.ContainsKey(leftPoint))
                    points.Add(leftPoint, new Point(points[srt].x - 1, points[srt].y));
                if (!points.ContainsKey(rightPoint))
                    points.Add(rightPoint, new Point(points[srt].x + 1, points[srt].y));
            }
        }
        Point[] tempPoints = points.Values.ToArray();
        Array.Sort(tempPoints);
        foreach (Point point in tempPoints)
            Console.WriteLine(point.ToString());
    }
    public static void PerformTask2063()//Техника программирования. Игра Бум
    {
        int[] data = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int t = data[1];
        List<Player[]> teams = new List<Player[]>();
        Dictionary<int, List<string>> teamPoint = new Dictionary<int, List<string>>();
        for (int i = 0; i < data[0]; i++)
        {
            int[] teamdData = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
            Player[] team = new Player[] { new Player(teamdData[0], teamdData[1]), new Player(teamdData[2], teamdData[3]) };
            teams.Add(team);
            teamPoint.Add(i, new List<string>());
        }
        int m = Convert.ToInt32(Console.ReadLine());
        Queue<Card> deck = new Queue<Card>();
        for (int i = 1; i <= m; i++)
        {
            string word = Console.ReadLine()!;
            int c = Convert.ToInt32(Console.ReadLine());
            deck.Enqueue(new Card(word, c));
        }
        int playersCounter = 0;
        int tempTime = t;
        while (deck.Count > 0)
        {
            Card actionCard = deck.Dequeue();
            Player[] team = teams[playersCounter];
            int maveTime = Math.Max(1, actionCard.c - (team[0].a + team[1].b) - actionCard.GetExtraTime(playersCounter));
            if (tempTime > maveTime)
            {
                teamPoint[playersCounter].Add(actionCard.word);
                tempTime -= maveTime;
            }
            else if (tempTime == maveTime)
            {
                teamPoint[playersCounter].Add(actionCard.word);
                tempTime = t;
                playersCounter++;
            }
            else
            {
                actionCard.PutExtraTime(playersCounter, tempTime);
                deck.Enqueue(actionCard);
                tempTime = t;
                playersCounter++;
            }
            if (playersCounter == data[0])
            {
                for (int i = 0; i < data[0]; i++)
                {
                    teams[i] = Player.SwapPlayers(teams[i]);
                }
                playersCounter = 0;
            }
        }
        foreach (var teamResult in teamPoint)
        {
            Console.Write(teamResult.Value.Count());
            foreach (var playerResult in teamResult.Value)
                Console.Write(" " + playerResult);
            Console.WriteLine();
        }
    }
    public static void PerformTask2064()//Техника программирования. Таблица
    {
        string[] columnsName = Console.ReadLine()!.Split();
        string[] sortParams = Console.ReadLine()!.Split(',').Select(x => x.Trim()).ToArray();
        List<string[]> table = new List<string[]>();
        string tempLine = "Ну работай плиз";
        do
        {
            tempLine = Console.ReadLine()!;
            if (tempLine != null)
                table.Add(tempLine.Split());
        }
        while (tempLine != null);
        List<intBool> sortOrders = new List<intBool>();
        foreach (string sortOrd in sortParams)
        {
            if (sortOrd.Contains(" DESC"))
            {
                sortOrders.Add(new intBool(Array.IndexOf(columnsName, new string(sortOrd.TakeWhile(x => x != ' ').ToArray())), false));
            }
            else
            {
                sortOrders.Add(new intBool(Array.IndexOf(columnsName, new string(sortOrd.TakeWhile(x => x != ' ').ToArray())), true));
            }
        }
        IOrderedEnumerable<string[]> tempTable = sortOrders[0].ascDesc ? table.OrderBy(x => x[sortOrders[0].index]) : table.OrderByDescending(x => x[sortOrders[0].index]);
        for (int i = 1; i < sortOrders.Count(); i++)
        {
            int index = sortOrders[i].index;
            bool ascDesc = sortOrders[i].ascDesc;
            tempTable = ascDesc ? tempTable.ThenBy(x => x[index]) : tempTable.ThenByDescending(x => x[index]);
        }
        table = tempTable.ToList();
        foreach (var line in table)
        {
            foreach (var word in line)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }
    }
    public static void PerformTask2065()//Рекурсия.Фрактал
    {
        int[] data = Array.ConvertAll(Console.ReadLine()?.Split()!, (s) => (int.Parse(s)));
        while (data[0] != 1)
        {
            if (data[1] > (int)Math.Pow(2, data[0] - 1) && data[2] <= (int)Math.Pow(2, data[0] - 1))
            {
                Console.WriteLine("WHITE");
                return;
            }
            else if (data[1] <= (int)Math.Pow(2, data[0] - 1) && data[2] > (int)Math.Pow(2, data[0] - 1))
            {
                Console.WriteLine(data[0] % 2 == 0 ? "BLACK" : "WHITE");
                return;
            }
            else
            {
                if (data[1] > (int)Math.Pow(2, data[0] - 1) && data[2] > (int)Math.Pow(2, data[0] - 1))
                {
                    data[1] -= (int)Math.Pow(2, data[0] - 1);
                    data[2] -= (int)Math.Pow(2, data[0] - 1);
                }
                data[0] -= 1;
            }
        }
        if (data[1] == 1 && data[2] == 2)
            Console.WriteLine("WHITE");
        else
            Console.WriteLine("BLACK");
    }
    public static void PerformTask2066()//Рекурсия. Перемешивание массива
    {
        int n = Convert.ToInt32(Console.ReadLine());//не понадобилось но в задаче должно быть
        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        int[] result = GetResultArray(numbers);
        foreach (int number in result)
            Console.Write(number + " ");
    }
    private static int[] GetResultArray(int[] startArray)
    {
        if (startArray.Length == 2 || startArray.Length == 1)
            return startArray.Reverse().ToArray();
        int[] tempArray = startArray.Reverse().ToArray();
        int[] leftPart = tempArray.Take(startArray.Length / 2).ToArray();
        int[] rightPart = tempArray.Skip(startArray.Length / 2).ToArray();
        return GetResultArray(leftPart).Concat(GetResultArray(rightPart)).ToArray();
    }
    public static void PerformTask2067()//Рекурсия. Шифр
    {
        string cipher = Console.ReadLine()!;
        Console.WriteLine(UnCiphering(cipher));
    }
    private static int UnCiphering(string cipher)
    {
        if (cipher.Length == 1)
            return Convert.ToInt32(cipher);
        else if (cipher.Length == 0)
            return 0;
        int maxNumber = Array.ConvertAll(string.Join(" ", cipher.ToArray()).Split(), s => int.Parse(s)).Max();
        int x = cipher.IndexOf(maxNumber.ToString());
        string leftStr = string.Join("", cipher.Take(x).ToArray());
        string rightStr = string.Join("", cipher.Skip(x + 1).ToArray());
        return UnCiphering(rightStr) + maxNumber - UnCiphering(leftStr);
    }
}

struct Point : IComparable<Point>
{
    public int x;
    public int y;
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public int CompareTo(Point tempPoint)
    {
        if (x < tempPoint.x)
            return -1;
        else if (x > tempPoint.x)
            return 1;
        else if (x == tempPoint.x && y < tempPoint.y)
            return -1;
        else if (x == tempPoint.x && y > tempPoint.y)
            return 1;
        else
            return 0;
    }
    public override string ToString()
    {
        return x + " " + y;
    }
}

struct intBool
{
    public int index;
    public bool ascDesc;
    public intBool(int x, bool y)
    {
        index = x;
        ascDesc = y;
    }
}

struct Player
{
    public int a;
    public int b;
    public Player(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    public Player(Player player)
    {
        this.a = player.a;
        this.b = player.b;
    }
    public static Player[] SwapPlayers(Player[] team)
    {
        return new Player[] { new Player(team[1]), new Player(team[0]) };
    }
}

struct Card
{
    public string word;
    public int c;
    public Dictionary<int, int> extraTime;
    public Card(string word, int c)
    {
        this.word = word;
        this.c = c;
        extraTime = new Dictionary<int, int>();
    }
    public int GetExtraTime(int team)
    {
        if (extraTime.ContainsKey(team))
            return extraTime[team];
        else
            return 0;
    }
    public void PutExtraTime(int team, int time)
    {
        if (extraTime.ContainsKey(team))
            extraTime[team] += time;
        else
            extraTime.Add(team, time);
    }
}

