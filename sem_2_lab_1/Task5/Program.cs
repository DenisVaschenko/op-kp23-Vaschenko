namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "1.txt";
            StreamReader sr = new StreamReader(filePath);
            string line;
            int numOfWords = 0;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line != null) numOfWords += WordsCounter(line);
            }
            Console.WriteLine(numOfWords);
            sr.Close();
        }
        static int WordsCounter(string s)
        {
            int answer = 0;
            if (IsLetter(s[0]))
            {
                answer++;
            }
            for (int i = 1; i < s.Length; i++)
            {
                if (IsLetter(s[i]) && !IsLetter(s[i - 1]))
                {
                    answer++;
                }
            }
            return answer;
        }
        static bool IsLetter(char c)
        {
            if ((c >= 65 && c <= 90) || (c >= 97 && c <= 122) || (c >= 48 && c<=57)) return true;
            return false;
        }
    }
}
