using UnityEngine;

public class MeshShape
{
    public Vector3[] Vertices { get; set; }
    public int[] Triangles { get; set; }
    public IntPositions[] Positions { get; set; }
    public (int, int, int, int) Bounds { get; set; }
}
