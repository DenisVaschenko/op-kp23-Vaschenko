/*
 * Input:
 * 1
 * 2
 * 3
 */
interface Vessel
{
    public void PrepareToMove();
    public void Move();
}
class SailingVessel : Vessel
{
    public void PrepareToMove()
    {
        Console.WriteLine("Sailing Vessel is preparing to move...");
    }
    public void Move()
    {
        Console.WriteLine("Sailing Vessel is moving");
    }
}
class Submarine : Vessel
{
    public void PrepareToMove()
    {
        Console.WriteLine("Submarine is preparing to move...");
    }
    public void Move()
    {
        Console.WriteLine("Submarine is moving");
    }
}
class Program
{
    static void Main(string[] args)
    {
        int n;
        Vessel vessel;
        while (true)
        {
            Console.WriteLine("Enter 1 - to move Sailing Vessel; 2 - to move Submarine; 3 - to exit the program");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 1) vessel = new SailingVessel();
                else if (n == 2) vessel = new Submarine();
                else if (n == 3) return;
                else throw new Exception();
                vessel.PrepareToMove();
                vessel.Move();

            }
            catch
            {
                Console.WriteLine("Entered data is incorrect");
                continue;
            }
        }
    }
}
/*
 * Output:
 * Sailing Vessel is preparing to move...
 * Sailing Vessel is moving
 * Submarine is preparing to move...
 * Submarine is moving
 */