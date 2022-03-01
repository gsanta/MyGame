using UnityEngine;

class Line3ShapeCreator
{
    private MeshShape rightShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.right * 8.0f * 3, Vector3.up * 8.0f, new Vector3(3f, 1f, 0f) * 8.0f
        },

        Triangles = new int[] {
            0, 2, 1, 1, 2, 3, 1
        },

        Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(1, 0), new IntPositions(2, 0) }
    };

    private MeshShape upShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.up * 8.0f * 3, Vector3.right * 8.0f, new Vector3(1f, 3f, 0f) * 8.0f
        },

        Triangles = new int[] {
            0, 2, 1, 1, 2, 3, 1
        },

        Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(0, 1), new IntPositions(0, 2) }
    };

    public RotateableMeshShape CreateShape()
    {
        return new RotateableMeshShape()
        {
            Right = rightShape,
            Left = rightShape,
            Up = upShape,
            Down = upShape
        };
    }
}
