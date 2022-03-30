public class MovementController
{
    private IPlayerSelector playerSelector;
    private IDestinationSelector destinationSelector;
    private Hover hover;

    private GroundBlock from;
    private GroundBlock to;
    private bool isEnabled;

    public MovementController(IPlayerSelector playerSelector, IDestinationSelector destinationSelector, Hover hover)
    {
        this.playerSelector = playerSelector;
        this.destinationSelector = destinationSelector;
        this.hover = hover;
        playerSelector.PlayerSelected += HandlePlayerSelected;
    }

    public void SetEnabled(bool isEnabled)
    {
        this.isEnabled = isEnabled;
    }

    private void HandlePlayerSelected(object sender, GroundBlockSelectedEventArgs args)
    {
        this.from = args.groundBlock;
    }

    private void HandleDestinationSelected(object sender, GroundBlockSelectedEventArgs args)
    {
        this.to = args.groundBlock;
    }
}
