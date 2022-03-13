using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject startLevelModal;
    private GameGridCreator gameGridCreator;
    private PlayersSetup playerSetup;
    private GenericGrid<Block2D> grid;
    public void Construct(GameGridCreator gameGridCreator, GenericGrid<Block2D> grid, PlayersSetup playerSetup)
    {
        this.gameGridCreator = gameGridCreator;
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
        var gameGrid = gameGridCreator.Create(grid);
        //playerSetup.Setup(gameGrid);
    }
}
