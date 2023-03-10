namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string filepath = "1.txt";
            FileStream fs = new FileStream(filepath,FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            string filepath2 = "max.txt";
            FileStream fs2 = new FileStream(filepath2, FileMode.Create);
            double num;
            for (int i = 0; i < 15; i++)
            {
                num = random.Next(-99,100) + (double)random.Next(-99,100)/100;
                sw.Write("{0:F2}",num);
                if (i < 14) sw.Write("\n");
            }
            sw.Close();
            StreamReader sr = new StreamReader(filepath);
            double max = Convert.ToDouble(sr.ReadLine());
            while (!sr.EndOfStream)
            {
                num = Convert.ToDouble(sr.ReadLine());
                if (num > max)
                {
                    max = num;
                }
            }
            sw = new StreamWriter(fs2);
            sw.Write(max);
            sr.Close();
            sw.Close();
        }
    }
}
