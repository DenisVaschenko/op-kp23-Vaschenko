using System.Dynamic;
using System.IO.Pipes;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Transactions;
/*
        Input:
        3
        Mitchel 3000 1200
        Locky 98800 12670
        Surname13234 9856354 365897
 */
class Program
{
    public static Client[] clients;
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of clients");
        SetData(Convert.ToInt32(Console.ReadLine()));
        GetData();
    }
    static void SetData(int count)
    {
        string[] s;
        clients = new Client[count];
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Enter data for " + (i + 1) + "th client");
            s = Console.ReadLine().Split();
            try
            {
                clients[i] = new Client(s[0], Convert.ToDouble(s[1]), Convert.ToDouble(s[2]));
            }
            catch
            {
                Console.WriteLine("Entered data is incorrect");
                i--;
                continue;
            }
            Console.WriteLine("Data is added successfully");
        }
    }
    static void GetData()
    {
        Console.WriteLine();
        double sum1 = 0; double sum2 = 0; double sum3 = 0;
        Console.WriteLine("N     Surname     salary     held     received");
        for (int i = 0; i < clients.Length; i++)
        {
            sum1 += clients[i].salary;
            sum2 += clients[i].held;
            sum3 += clients[i].received;
            Console.Write((i + 1) + " ");
            int j = NumberLength(i + 1) + 2;
            if (j < 7)
            {
                Print(' ', 7 - j);
                j = 7;
            }
            Console.Write("{0:F2} ", clients[i].surname);
            j += clients[i].surname.Length + 1;
            if (j < 19)
            {
                Print(' ', 19 - j);
                j = 19;
            }
            Console.Write("{0:F2} ", clients[i].salary);
            j += NumberLength((int)Math.Floor(clients[i].salary)) + 4;
            if (j < 30)
            {
                Print(' ', 30 - j);
                j = 30;
            }
            Console.Write("{0:F2} ", clients[i].held);
            j += NumberLength((int)Math.Floor(clients[i].held)) + 4;
            if (j < 39)
            {
                Print(' ', 39 - j);
                j = 39;
            }
            Console.Write("{0:F2} \n", clients[i].received);
        }
        Console.WriteLine("{1:F2}", "Sum of salary: ", sum1);
        Console.WriteLine("{1:F2}", "Sum of held: ", sum2);
        Console.WriteLine("{1:F2}", "Sum of received: ", sum3);
    }
    static int NumberLength(int n)
    {
        int i = 0;
        while (n > 0)
        {
            n = (int)n / 10;
            i++;
        }
        return i;
    }
    static void Print(char c, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(c);
        }
    }
}
class Client
{
    public string surname;
    public double salary;
    public double held;
    public double received;
    public Client(string surname, double salary, double held)
    {
        if (salary < held)
        {
            throw new Exception();
        }
        this.surname = surname;
        this.salary = salary;
        this.held = held;
        received = salary - held;
    }
    
}
/*Output:
        N     Surname     salary     held     received
        1     Mitchel     3000       1200     1800
        2     Locky       98800      12670    86130
        3     Surname13234 9856354   365897   9490457
        Sum of salary: 9958154
        Sum of held: 379767
        Sum of received: 9578387
*/
