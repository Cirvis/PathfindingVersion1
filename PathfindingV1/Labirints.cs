using System;

public class Labirints : IPathNode<Object>
{
    public Int32 Platums { get; set; }
    public Int32 Augstums { get; set; }
    public Boolean Siena { get; set; }

    public bool NavSiena(Object unused)
    {
        return !Siena;
    }
}
