using UnityEngine;

public class RotateableMeshShape
{

    public MeshShape Up { get; set; }
    public MeshShape Right { get; set; }
    public MeshShape Down { get; set; }
    public MeshShape Left { get; set; }

    public MeshShape GetMeshShape(ShapeDirection direction)
    {
        switch(direction)
        {
            case ShapeDirection.Up:
                return Up;
            case ShapeDirection.Right:
                return Right;
            case ShapeDirection.Down:
                return Down;
            case ShapeDirection.Left:
                return Left;
            default:
                return null;
        }
    }
}
