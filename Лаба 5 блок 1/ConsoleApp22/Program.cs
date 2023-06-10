using System;

struct MyTime
{
    public int hour, minute, second;

    public MyTime(int h, int m, int s)
    {
        hour = h % 24; 
        minute = m % 60;
        second = s % 60;
    }

    public override string ToString()
    {
        return $"{hour}:{minute:D2}:{second:D2}";
    }
}

class Program
{
    static int TimeSinceMidnight(MyTime t)
    {
        return t.hour * 3600 + t.minute * 60 + t.second;
    }

    static MyTime TimeSinceMidnight(int t)
    {
        int hours = t / 3600;
        int minutes = (t % 3600) / 60;
        int seconds = (t % 3600) % 60;

        return new MyTime(hours, minutes, seconds);
    }

    static MyTime AddOneSecond(MyTime t)
    {
        int totalSeconds = TimeSinceMidnight(t) + 1;

        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = (totalSeconds % 3600) % 60;

        return new MyTime(hours, minutes, seconds);
    }

    static MyTime AddOneMinute(MyTime t)
    {
        int totalSeconds = TimeSinceMidnight(t) + 60;

        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = (totalSeconds % 3600) % 60;

        return new MyTime(hours, minutes, seconds);
    }

    static MyTime AddOneHour(MyTime t)
    {
        int totalSeconds = TimeSinceMidnight(t) + 3600;

        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = (totalSeconds % 3600) % 60;

        return new MyTime(hours, minutes, seconds);
    }

    static MyTime AddSeconds(MyTime t, int s)
    {
        int totalSeconds = TimeSinceMidnight(t) + s;

        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = (totalSeconds % 3600) % 60;

        return new MyTime(hours, minutes, seconds);
    }

    static int Difference(MyTime mt1, MyTime mt2)
    {
        int seconds1 = TimeSinceMidnight(mt1);
        int seconds2 = TimeSinceMidnight(mt2);
        return seconds1 - seconds2;
    }

    static string WhatLesson(MyTime mt)
    {
        MyTime lesson1Start = new MyTime(8, 0, 0);
        MyTime lesson1End = new MyTime(9, 20, 0);
        MyTime lesson2Start = new MyTime(9, 40, 0);
        MyTime lesson2End = new MyTime(11, 0, 0);
        MyTime lesson3Start = new MyTime(11, 20, 0);
        MyTime lesson3End = new MyTime(12, 40, 0);
        MyTime lesson4Start = new MyTime(13, 0, 0);
        MyTime lesson4End = new MyTime(14, 20, 0);
        MyTime lesson5Start = new MyTime(14, 40, 0);
        MyTime lesson5End = new MyTime(16, 0, 0);
        MyTime lesson6Start = new MyTime(16, 20, 0);
        MyTime lesson6End = new MyTime(17, 40, 0);

        if (IsBetween(mt, lesson1Start, lesson1End))
            return "1-а пара";
        else if (IsBetween(mt, lesson2Start, lesson2End))
            return "2-а пара";
        else if (IsBetween(mt, lesson3Start, lesson3End))
            return "3-я пара";
        else if (IsBetween(mt, lesson4Start, lesson4End))
            return "4-а пара";
        else if (IsBetween(mt, lesson5Start, lesson5End))
            return "5-а пара";
        else if (IsBetween(mt, lesson6Start, lesson6End))
            return "6-а пара";
        else if (IsBefore(mt, lesson1Start))
            return "пари ще не почалися";
        else if (IsAfter(mt, lesson6End))
            return "пари вже скінчилися";
        else if (IsBetween(mt, lesson1End, lesson2Start))
            return "перерва між 1-ю та 2-ю парами";
        else if (IsBetween(mt, lesson2End, lesson3Start))
            return "перерва між 2-ю та 3-ю парами";
        else if (IsBetween(mt, lesson3End, lesson4Start))
            return "перерва між 3-ю та 4-ю парами";
        else if (IsBetween(mt, lesson4End, lesson5Start))
            return "перерва між 4-ю та 5-ю парами";
        else if (IsBetween(mt, lesson5End, lesson6Start))
            return "перерва між 5-ю та 6-ю парами";
        else
            return "";
    }

    static bool IsBetween(MyTime t, MyTime start, MyTime end)
    {
        int seconds = TimeSinceMidnight(t);
        int startSeconds = TimeSinceMidnight(start);
        int endSeconds = TimeSinceMidnight(end);

        return seconds >= startSeconds && seconds <= endSeconds;
    }

    static bool IsBefore(MyTime t, MyTime other)
    {
        int seconds = TimeSinceMidnight(t);
        int otherSeconds = TimeSinceMidnight(other);

        return seconds < otherSeconds;
    }

    static bool IsAfter(MyTime t, MyTime other)
    {
        int seconds = TimeSinceMidnight(t);
        int otherSeconds = TimeSinceMidnight(other);

        return seconds > otherSeconds;
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Введіть години:");
        int hours = int.Parse(Console.ReadLine());

        Console.WriteLine("Введіть хвилини:");
        int minutes = int.Parse(Console.ReadLine());

        Console.WriteLine("Введіть секунди:");
        int seconds = int.Parse(Console.ReadLine());

        if (minutes > 59)
        {
            hours += minutes / 60;
            minutes = minutes % 60;
        }

        if (seconds > 59)
        {
            minutes += seconds / 60;
            seconds = seconds % 60;
        }

        MyTime time = new MyTime(hours, minutes, seconds);

        Console.WriteLine($"Час: {time}");
        Console.WriteLine($"Час після полуночі: {TimeSinceMidnight(time)} секунд");
        Console.WriteLine($"Додати секунду: {AddOneSecond(time)}");
        Console.WriteLine($"Додати хвилину: {AddOneMinute(time)}");
        Console.WriteLine($"Додати годину: {AddOneHour(time)}");
        Console.WriteLine($"Додати 300 секунд: {AddSeconds(time, 300)}");
        Console.WriteLine($"Різниця 10:30:45 між 12:45:00: {Difference(time, new MyTime(12, 45, 0))} секунд");
        Console.WriteLine($"Яка зараз пара {time}? {WhatLesson(time)}");
    }
}
