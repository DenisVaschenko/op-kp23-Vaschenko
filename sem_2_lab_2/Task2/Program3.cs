
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