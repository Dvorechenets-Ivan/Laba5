using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using _5_laboratory;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData(string fileName)
        {
            List<Student> list = new List<Student>();
            using (StreamReader stream = new StreamReader(fileName, Encoding.UTF8))
            {
                while (!stream.EndOfStream)
                {
                    list.Add(new Student(stream.ReadLine()));
                }
            }
            return list.ToArray();
        }
        static void runMenu(Student[] studs)
        {
            for (int i = 0; i < studs.Length; i++)
            {
                double avarege = (double.Parse(Convert.ToString(studs[i].informaticsMark)) + double.Parse(Convert.ToString(studs[i].mathematicsMark)) + double.Parse(Convert.ToString(studs[i].physicsMark))) / 3;
                if (avarege > 4.5)
                {
                    Console.WriteLine($"{studs[i].surName} {studs[i].firstName} {studs[i].patronymic} {avarege}");
                }
            }
        }
        static void Main(string[] args)
        {

            Student[] studs = ReadData(@"data.txt");
            runMenu(studs);
            Console.ReadKey();
        }
    }
}