using System;

public interface IDestinationSelector
{
    public void SetEnabled(bool isEnabled);
    public event EventHandler<GroundBlockSelectedEventArgs> DestinationSelected;
}
