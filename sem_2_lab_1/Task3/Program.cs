using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Globalization;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfWords = 40;
            int maxLength = 80;
            string[] words = new string[numOfWords];
            string filepath = "1.txt";
            string filepath1 = "2.txt";
            CreateFile(filepath, maxLength, numOfWords);
            StreamReader sr = new StreamReader(filepath);
            int count = 0;
            while (!sr.EndOfStream)
            {
                words[count] = sr.ReadLine();
                count++;
            }
            sr.Close();
            //display(words);
            words = sort(words);
            StreamWriter sw = new StreamWriter(new FileStream(filepath1, FileMode.Create));
            for (int i = 0; i < words.Length - 1; i++)
            {
                sw.WriteLine(words[i]);
            }
            sw.Write(words[words.Length - 1]);
            sw.Close();
        }
        static void CreateFile(string filepath, int maxLength, int countOfWords)
        {
            Random random = new Random();
            FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            int length;
            for (int i = 0; i < countOfWords; i++)
            {
                length = random.Next(1, maxLength + 1);
                for (int j = 0; j < length; j++)
                {
                    sw.Write((char)random.Next(97, 123));
                }
                if (i < countOfWords - 1) sw.Write("\n");
            }
            sw.Close();
        }
        static bool Compare(string s1, string s2)
        {
            int length = s1.Length;
            if (s1.Length > s2.Length) length = s2.Length;
            for (int i = 0; i < length; i++)
            {
                if (s1[i] > s2[i]) return true;
                else if (s1[i] < s2[i]) return false;
            }
            return s1.Length > s2.Length;
        }
        static string[] sort(string[] s)
        {
            string tmp;
            for (int d = s.Length / 2; d >= 1; d /= 2)
            {
                for (int i = d; i < s.Length; i++)
                {
                    for (int j = i; j >= d && Compare(s[j - d], s[j]); j -= d)
                    {
                        tmp = s[j];
                        s[j] = s[j - d];
                        s[j - d] = tmp;
                    }
                }
            }
            return s;
        }
        static void display(string[] words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}

