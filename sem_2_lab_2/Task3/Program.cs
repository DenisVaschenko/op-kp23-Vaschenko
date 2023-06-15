using System.Collections.Specialized;
class Program
{
    /*
     * Input: (2,5;3,5;-4) + (-3,5;-8,4)
     * Output: -15,9
     */
    static void Main(string[] args)
    {
        string[] v;
        while (true)
        {
            Console.WriteLine("Enter operation;  Enter 0 to exit");
            string[] s = Console.ReadLine().Split();
            if (s[0] == "0") return;
            try
            {
                v = s[0].Split('(')[1].Split(')')[0].Split(';');
                Vector vector1 = new Vector();
                for (int i = 0; i < v.Length; i++)
                {
                    vector1.AddNumber(Convert.ToDouble(v[i]));
                }
                v = s[2].Split('(')[1].Split(')')[0].Split(';');
                Vector vector2 = new Vector();
                for (int i = 0; i < v.Length; i++)
                {
                    vector2.AddNumber(Convert.ToDouble(v[i]));
                }
                if (s[1] == "+") Console.WriteLine(vector1 + vector2);
                else if (s[1] == "-") Console.WriteLine(vector1 - vector2);
                else if (s[1] == "*") Console.WriteLine(vector1 * vector2);
                else if (s[1] == "/") Console.WriteLine(vector1 / vector2);
                else throw new Exception();
            }
            catch
            {
                Console.WriteLine("Entered data is incorrect");
            }
        }
    }
}
class Vector
{
    List<double> numbers;
    public Vector()
    {
        numbers = new List<double>();
    }
    public Vector(List<double> numbers)
    {
        this.numbers = numbers;
    }
    public void AddNumber(double num)
    {
        numbers.Add(num);
    }
    public static double operator +(Vector v1, Vector v2)
    {
        double sum = 0;
        foreach (double x in v1.numbers)
        {
            if (x<0) sum += x;
        }
        foreach (double x in v2.numbers)
        {
            if (x < 0) sum += x;
        }
        return sum;
    }
    public static double operator *(Vector v1, Vector v2)
    {
        double result = 1;
        for (int i = 1; i < v1.numbers.Count(); i += 2)
        {
            result *= v1.numbers[i];
        }
        for (int i = 1; i < v2.numbers.Count(); i += 2)
        {
            result *= v2.numbers[i];
        }
        return result;
    }
    public static int operator /(Vector v1, Vector v2)
    {
        int count = 0;
        for (int i = 0; i < v1.numbers.Count(); i++)
        {
            if (v1.numbers[i] == 0) count++;
        }
        for (int i = 0; i < v2.numbers.Count(); i++ )
        {
            if (v2.numbers[i] == 0) count++;
        }
        return count;
    }
    public static Vector operator -(Vector v)
    {
        for (int i = 0; i < v.numbers.Count(); i++)
        {
            v.numbers[i] = -v.numbers[i];
        }
        return v;
    }
    public static double operator -(Vector v1, Vector v2)
    {
        return v1 + (-v2);
    }
}