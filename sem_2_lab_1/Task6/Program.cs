
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "1.csv";
            string filepath1 = "mydata1";
            string filepath2 = "mydata2";
            int numOfLines = 10;
            CreateFile(filepath, numOfLines);
            StreamReader sr = new StreamReader(filepath);
            (string, string, int) student;
            BinaryWriter bw = new BinaryWriter(new FileStream(filepath1, FileMode.Create));
            while (!sr.EndOfStream)
            {
                student = Split(sr.ReadLine());
                bw.Write(student.Item1);
                bw.Write(student.Item2);
                bw.Write(student.Item3);
            }
            sr.Close();
            bw.Close();
            BinaryReader br = new BinaryReader(new FileStream(filepath1, FileMode.Open));
            bw = new BinaryWriter(new FileStream(filepath2, FileMode.Create));
            while (true)
            {
                try
                {
                    student = (br.ReadString(), br.ReadString(), br.ReadInt32());
                    if (student.Item3 > 95)
                    {
                        bw.Write(student.Item1);
                        bw.Write(student.Item2);
                        bw.Write(student.Item3);
                    }
                }
                catch
                {
                    break;
                }
            }
            br.Close();
            bw.Close();
            /*br = new BinaryReader(new FileStream(filepath2, FileMode.Open));
            while (true)
            {
                try
                {
                    Console.WriteLine(br.ReadString() + br.ReadString() + br.ReadInt32());
                }
                catch
                {
                    break;
                }
            }
            br.Close();*/

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
            s += (char)random.Next(65, 91);
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
