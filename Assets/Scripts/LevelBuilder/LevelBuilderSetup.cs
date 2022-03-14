public class LevelBuilderSetup
{
    private GridLineRenderer gridLineRenderer;
    private LevelBuilderSetup levelBuilderSetup;

    public LevelBuilderSetup(GridLineRenderer gridLineRenderer, LevelBuilderSetup levelBuilderSetup)
    {
        this.gridLineRenderer = gridLineRenderer;
        this.levelBuilderSetup = levelBuilderSetup;
    }

    public void TearDown()
    {
        levelBuilderSetup.TearDown();
    }
}
