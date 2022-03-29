public class TurnManager
{
    private bool isPlayerTurn;

    public void Reset(bool isPlayerTurn)
    {
        this.isPlayerTurn = isPlayerTurn;
    }

    public void NextTurn()
    {
        isPlayerTurn = !isPlayerTurn;
    }
}
