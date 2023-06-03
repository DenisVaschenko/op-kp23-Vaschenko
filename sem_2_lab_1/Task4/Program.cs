
using System.Collections;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "1.csv";
            int numOfLines = 10;
            bool f = false;
            CreateFile(filepath, numOfLines);
            StreamReader sr = new StreamReader(filepath);
            (string, string, int) student;
            while (!sr.EndOfStream)
            {
                student = Split(sr.ReadLine());
                if (student.Item3 < 60)
                {
                    f = true;
                    Console.WriteLine(student.Item1 + " " + student.Item2);
                }
            }
            sr.Close();
            if (!f) Console.WriteLine("There are not such students");

        }
        static void CreateFile(string filepath, int count)
        {
            Random random = new Random();
            FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < count; i++)
            {
                sw.Write(GenerateWord(random.Next(3, 10)) + "," + GenerateWord(random.Next(3, 10)) + "," + random.Next(101));
                if (i < count - 1) sw.Write("\n");
            }
            sw.Close();
        }
        static string GenerateWord(int length)
        {
            Random random = new Random();
            string s = "";
            s += (char)random.Next(65,91);
            for (int i = 1; i < length; i++)
            {
                s += (char)random.Next(97, 122);
            }
            return s;
        }
        static (string, string, int) Split(string s)
        {
            int count = 0;
            string[] strings = new string[3];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ',') strings[count] += s[i];
                else count++;
            }
            return (strings[0], strings[1], Convert.ToInt32(strings[2]));
        }
    }
}
