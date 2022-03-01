


public struct IntPositions
{
    public int x;
    public int y;

    public IntPositions(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public IntPositions Add(int x, int y)
    {
        return new IntPositions(this.x + x, this.y + y);
    }
}

public interface ProceduralShape
{
    IntPositions[] GetPositions();
}
