using UnityEngine;

class Line1ShapeCreator
{
    private MeshShape upShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.right * 8.0f, Vector3.up * 8.0f, new Vector3(1f, 1f, 0f) * 8.0f
        },

        Triangles = new int[] {
            0, 2, 1, 1, 2, 3
        },

        Positions = new IntPositions[] { new IntPositions(0, 0) },

        Bounds = (0, 0, 0, 0)
    };

    public RotateableMeshShape CreateShape()
    {
        return new RotateableMeshShape()
        {
            Up = upShape,
            Right = upShape,
            Down = upShape,
            Left = upShape
        };
    }
}
