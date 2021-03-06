using UnityEngine;

class L1ShapeCreator
{
    private MeshShape upShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero, Vector3.up * 8.0f * 3, Vector3.right * 8.0f, new Vector3(1f, 3f, 0f) * 8.0f,
            new Vector3(1f, 2f, 0) * 8.0f, new Vector3(2f, 2f, 0) * 8.0f, new Vector3(2f, 3f, 0) * 8.0f
        },

        Triangles = new int[] {
            0, 1, 3, 0, 3, 2, 3, 6, 4, 4, 6, 5
        },

        Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(0, 1), new IntPositions(0, 2), new IntPositions(1, 2) },

        Bounds = (0, 0, 1, 2)
    };

    private MeshShape rightShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.right * 8.0f * 3, Vector3.up * 8.0f, new Vector3(3f, 1f, 0f) * 8.0f,
            new Vector3(2f, 0, 0) * 8.0f, new Vector3(2f, -1f, 0) * 8.0f, new Vector3(3f, -1f, 0) * 8.0f
        },

        Triangles = new int[] {
            0, 2, 1, 1, 2, 3, 1, 6, 5, 1, 5, 4
        },

        Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(1, 0), new IntPositions(2, 0), new IntPositions(2, -1) },

        Bounds = (0, -1, 2, 0)
    };

    private MeshShape downShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero, Vector3.up * 8.0f * 3, Vector3.right * 8.0f, new Vector3(1f, 3f, 0f) * 8.0f,
            new Vector3(0, 1f, 0) * 8.0f, new Vector3(-1f, 0, 0) * 8.0f, new Vector3(-1f, 1f, 0) * 8.0f
        },

        Triangles = new int[] {
            0, 1, 3, 0, 3, 2, 2, 6, 4, 2, 5, 6
        },

        Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(0, 1), new IntPositions(0, 2), new IntPositions(-1, 0) },

        Bounds = (-1, 0, 0, 2)
    };

    private MeshShape leftShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.right * 8.0f * 3, Vector3.up * 8.0f, new Vector3(3f, 1f, 0f) * 8.0f,
            new Vector3(1f, 1f, 0) * 8.0f, new Vector3(1f, 2f, 0) * 8.0f, new Vector3(0, 2f, 0) * 8.0f
        },

        Triangles = new int[] {
            0, 2, 1, 1, 2, 3, 0, 6, 5, 0, 5, 4
        },

        Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(1, 0), new IntPositions(2, 0), new IntPositions(0, 1) },

        Bounds = (0, 0, 2, 1)
    };

    public RotateableMeshShape CreateShape()
    {
        return new RotateableMeshShape()
        {
            Up = upShape,
            Right = rightShape,
            Down = downShape,
            Left = leftShape
        };
    }
}
