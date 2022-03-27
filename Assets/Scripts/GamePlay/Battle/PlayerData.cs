public class PlayerData
{
    public PlayerType type;
    public bool isEnemy;

    public PlayerData(PlayerType type, bool isEnemy)
    {
        this.type = type;
        this.isEnemy = isEnemy;
    }
}

public enum PlayerType
{
    Musician, Balloon, Acrobat
}
