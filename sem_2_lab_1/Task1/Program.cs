namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = "LIME1";
            string line2 = "LINE2";
            string filePath = "1.txt";
            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(line1);
            sw.Write(line2);
            sw.Close();
            StreamReader sr = new StreamReader(filePath);
            Console.Write(sr.ReadLine() + "\n" + sr.ReadLine());
            sr.Close();
        }
    }
}