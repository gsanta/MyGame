using UnityEngine;

public class SquareShapeCreator
{
    private MeshShape upShape;

    public SquareShapeCreator(int size)
    {
        var vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.right * size * 8.0f, Vector3.up * size * 8.0f, new Vector3(1f, 1f, 0f) * size * 8.0f
        };

        var triangles = new int[] {
            0, 2, 1, 1, 2, 3
        };

        var positions = new IntPositions[size * size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                positions[i * size + j] = new IntPositions(i, j);
            }
        }

        var bounds = (0, 0, size, size);

        upShape = new MeshShape()
        {
            Vertices = vertices,
            Triangles = triangles,
            Positions = positions,
            Bounds = bounds
        };
    }

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
