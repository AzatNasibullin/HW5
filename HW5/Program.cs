
//Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:
//
//int[,] labirynth1 = new int[,]
//{
//{ 1, 1, 1, 1, 1, 1, 1 },
//{ 1, 0, 0, 0, 0, 0, 1 },
//{ 1, 0, 1, 1, 1, 0, 1 },
//{ 0, 0, 0, 0, 1, 0, 0 },
//{ 1, 1, 0, 0, 1, 1, 1 },
//{ 1, 1, 1, 0, 1, 1, 1 },
//{ 1, 1, 1, 0, 1, 1, 1 }
//};
//
//Сигнатура метода:
//
//static int HasExit(int startI, int startJ, int[,] l)

using System;

public class Labyrinth
{
    int[,] labirynth1 = new int[,]
       {
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 0, 0, 0, 0, 0, 1 },
        {1, 0, 1, 1, 1, 0, 1 },
        {2, 0, 0, 0, 1, 0, 2 },
        {1, 1, 0, 0, 1, 1, 1 },
        {1, 1, 1, 0, 1, 1, 1 },
        {1, 1, 1, 2, 1, 1, 1 }
       };

    public int HasExit(int startI, int startJ)
    {
        if (labirynth1[startI, startJ] == 1)
            Console.WriteLine("Начальная точка в стене!");
        else if (labirynth1[startI, startJ] == 2)
            Console.WriteLine("Выход найден");

        var stack = new Stack<Tuple<int, int>>();
        stack.Push(new(startI, startJ));
        int ExitCount = 0;

        while (stack.Count > 0)
         {
            var temp = stack.Pop();

            if (labirynth1[temp.Item1, temp.Item2] == 2 )
                ExitCount++;

            labirynth1[temp.Item1, temp.Item2] = 1;

            if (temp.Item2 > 0 && labirynth1[temp.Item1, temp.Item2 - 1] != 1)
                 stack.Push(new(temp.Item1, temp.Item2 - 1)); //вверх
            if (temp.Item2 + 1 < labirynth1.GetLength(1) && labirynth1[temp.Item1, temp.Item2 + 1] != 1)
                 stack.Push(new(temp.Item1, temp.Item2 + 1)); //низ
            if (temp.Item1 > 0 && labirynth1[temp.Item1 - 1, temp.Item2] != 1)
                 stack.Push(new(temp.Item1 - 1, temp.Item2)); //лево
            if (temp.Item1 + 1 < labirynth1.GetLength(0) && labirynth1[temp.Item1 + 1, temp.Item2] != 1)
                 stack.Push(new(temp.Item1 + 1, temp.Item2)); //право
         }

        return ExitCount;
    }
       
    
    public static void Main()
    {
        int ExitCount = new Labyrinth().HasExit(3, 3);
        if (ExitCount > 0)
            Console.WriteLine("Найдено выходов:" + ExitCount);
        else 
            Console.WriteLine("Выходов не найдено!");


    }
   
}

    