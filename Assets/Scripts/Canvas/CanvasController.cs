using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject startLevelModal;
    private GameGridSetup gameGridSetup;
    private LevelBuilderSetup levelGuilderSetup;
    private PlayersSetup playerSetup;
    private GenericGrid<Block2D> grid;
    public void Construct(GameGridSetup gameGridSetup, LevelBuilderSetup levelGuilderSetup, GenericGrid<Block2D> grid, PlayersSetup playerSetup)
    {
        this.gameGridSetup = gameGridSetup;
        this.levelGuilderSetup = levelGuilderSetup;
        this.playerSetup = playerSetup;
        this.grid = grid;
    }
    public void EndSetupLevel()
    {
        startLevelModal.SetActive(true);
    }

    public void StartLevel()
    {
        startLevelModal.SetActive(false);
        var gameGrid = gameGridSetup.Create(grid);
        levelGuilderSetup.TearDown();
        playerSetup.Setup(gameGrid);
    }
}
