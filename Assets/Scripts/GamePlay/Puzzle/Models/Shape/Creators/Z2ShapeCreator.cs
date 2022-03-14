using UnityEngine;

class Z2ShapeCreator
{
    private MeshShape upShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero, Vector3.up * 8.0f * 2, Vector3.right * 8.0f, new Vector3(1f, 2f, 0f) * 8.0f,
            new Vector3(1f, 1f, 0) * 8.0f, new Vector3(2f, 1f, 0) * 8.0f, new Vector3(2f, 0, 0) * 8.0f,
            new Vector3(0, 1f, 0) * 8.0f, new Vector3(-1f, 1f, 0) * 8.0f, new Vector3(-1f, 2f, 0) * 8.0f
        },

        Triangles = new int[] {
            0, 1, 3, 0, 3, 2, 2, 5, 6, 4, 5, 2, 7, 8, 9, 7, 9, 1
        },

        Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(0, 1), new IntPositions(1, 0), new IntPositions(-1, 1) },

        Bounds = (-1, 0, 1, 1)
    };

    private MeshShape rightShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero, Vector3.right * 8.0f * 2, Vector3.up* 8.0f, new Vector3(2f, 1f, 0f) * 8.0f,
            new Vector3(1f, 1f, 0) * 8.0f, new Vector3(1f, 2f, 0) * 8.0f, new Vector3(2f, 2f, 0) * 8.0f,
            new Vector3(1f, 0f, 0) * 8.0f, new Vector3(1f, -1f, 0) * 8.0f, new Vector3(0, -1f, 0) * 8.0f
        },

        Triangles = new int[] {
            0, 3, 1, 0, 2, 3, 4, 5, 6, 4, 6, 3, 7, 8, 9, 0, 7, 9
        },

        Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(1, 0), new IntPositions(1, 1), new IntPositions(0, -1) },

        Bounds = (0, -1, 1, 1)
    };

    public RotateableMeshShape CreateShape()
    {
        return new RotateableMeshShape()
        {
            Up = upShape,
            Right = rightShape,
            Down = upShape,
            Left = rightShape
        };
    }
}
