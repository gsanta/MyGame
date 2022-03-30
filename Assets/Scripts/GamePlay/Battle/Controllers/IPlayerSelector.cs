using System;

public interface IPlayerSelector
{
    public void SetEnabled(bool isEnabled);
    public event EventHandler<GroundBlockSelectedEventArgs> PlayerSelected;
}
