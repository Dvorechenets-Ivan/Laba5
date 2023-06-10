﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_laboratory
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;
        public Student(string lineWithAllData)
        {
            surName = ""; firstName = ""; patronymic = ""; sex = ' '; dateOfBirth = "";
            mathematicsMark = ' '; physicsMark = ' '; informaticsMark = ' '; scholarship = 0;
            if (lineWithAllData == ""|| lineWithAllData == " ") {
                Console.WriteLine("Помилка! Документ має пустi рядки.");
                return;
            }
            string[] data = lineWithAllData.Split(' ');

            surName = data[0];
            firstName = data[1];
            patronymic = data[2];

            if (data[3] == "M" || data[3] == "Ч") sex = 'M';
            else if (data[3] == "F" || data[3] == "Ж") sex = 'F';
            else
            {
                Console.WriteLine("Помилка! Некоректно введена стать. Дані не будуть збережені.");
                return;
            }
            dateOfBirth = data[4];

            if (data[5].Length != 1)
            {
                Console.WriteLine("Помилка! Некоректно введена оцінка з математики. Дані не будуть збережені.");
                return;
            }
            else if(data[5] == "-")
            {        
                    mathematicsMark = char.Parse("2");      
            }
            else
            {
                mathematicsMark = char.Parse(data[5]);
            }
           

            if (data[6].Length != 1)
            {
                Console.WriteLine("Помилка! Некоректно введена оцінка з фізики. Дані не будуть збережені.");
                return;
            }
            else if (data[6] == "-")
            {
                physicsMark = char.Parse("2");
            }
            else
            {
                physicsMark = char.Parse(data[6]);
            }
            

            if (data[7].Length != 1)
            {
                Console.WriteLine("Помилка! Некоректно введена оцінка з інформатики. Дані не будуть збережені.");
                return;
            }
            else if (data[7] == "-")
            {
                informaticsMark = char.Parse("2");
            }
            else
            {
                informaticsMark = char.Parse(data[7]);
            }
            if (data[8] == "")
            {
                Console.WriteLine("Помилка! Некоректно введена стипендія. Дані не будуть збережені.");
                return;
            }
            scholarship = int.Parse(data[8]);
        }
    }
}
