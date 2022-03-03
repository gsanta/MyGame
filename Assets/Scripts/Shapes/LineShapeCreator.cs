using UnityEngine;

class LineShapeCreator
{
    private MeshShape upShape;
    private MeshShape rightShape;
    public LineShapeCreator(int size)
    {
        CreateUpShape(size);
        CreateRightShape(size);
    }

    private void CreateUpShape(int size)
    {
        var vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.up * 8.0f * size, Vector3.right * 8.0f, new Vector3(1f, size, 0f) * 8.0f
        };

        var triangles = new int[] {
            0, 1, 2, 1, 3, 2
        };

        var positions = new IntPositions[size];

        for (int i = 0; i < size; i++)
        {
            positions[i] = new IntPositions(0, i);
        }

        upShape = new MeshShape()
        {
            Vertices = vertices,
            Triangles = triangles,
            Positions = positions
        };
    }

    private void CreateRightShape(int size)
    {
        var vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.right * 8.0f * size, Vector3.up * 8.0f, new Vector3(size, 1f, 0f) * 8.0f
        };

        var triangles = new int[] {
            0, 2, 1, 1, 2, 3
        };

        var positions = new IntPositions[size];

        for (int i = 0; i < size; i++)
        {
            positions[i] = new IntPositions(i, 0);
        }

        rightShape = new MeshShape()
        {
            Vertices = vertices,
            Triangles = triangles,
            Positions = positions
        };
    }

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
