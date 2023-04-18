using System.Dynamic;
using System.IO.Pipes;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Transactions;
class Program
{
    public static Statement statement;

    static void Main(string[] args)
    {
    }
    static void SetData(int count)
    {
    }
    static void GetData()
    {
    }
    static int NumberLength(int n)
    {
    }
    static void Print(char c, int n)
    {
    }
}
class Client
{
    public string surname;
    public int salary;
    public int held;
    public int received;
    public Client(string surname, int salary, int held)
    {
    }
}
class Statement
{
    public List<Client> clients = new List<Client>();
    public int sum1;
    public int sum2;
    public int sum3;
    public void AddClient(Client client)
    {
    }
    public void AddClient(string surname, int salary, int held)
    {
    }
    public void CountSummary()
    {
    }
}