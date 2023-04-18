/*
 * Input:
 * 1
 * 2
 * 3
 */
abstract class Vessel
{
    public abstract void PrepareToMove();
    public abstract void Move();
}
class SailingVessel: Vessel
{
    public override void PrepareToMove()
    {
    }
    public override void Move()
    {
    }
}
class Submarine: Vessel
{
    public override void PrepareToMove()
    {
    }
    public override void Move()
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