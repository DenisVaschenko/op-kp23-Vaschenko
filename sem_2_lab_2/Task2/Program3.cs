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
    }
    public void Move()
    {
    }
}
class Submarine : Vessel
{
    public void PrepareToMove()
    {
    }
    public void Move()
    {
    }
}
class Program
{
    static void Main(string[] args)
    {
    }
}
/*
 * Output:
 * Sailing Vessel is preparing to move...
 * Sailing Vessel is moving
 * Submarine is preparing to move...
 * Submarine is moving
 */