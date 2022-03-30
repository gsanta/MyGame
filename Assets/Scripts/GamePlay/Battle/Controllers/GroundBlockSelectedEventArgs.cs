using System;

public class GroundBlockSelectedEventArgs : EventArgs
{
    public GroundBlock groundBlock;

    public GroundBlockSelectedEventArgs(GroundBlock groundBlock)
    {
        this.groundBlock = groundBlock;
    }
}