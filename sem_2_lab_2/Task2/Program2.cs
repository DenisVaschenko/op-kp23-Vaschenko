
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