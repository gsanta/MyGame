using System;
using UnityEngine;

public class ProceduralMeshFactory : MonoBehaviour
{
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private ProceduralQuad quadProceduralPrefab;
    [SerializeField] private ProceduralLShape lShapePrefab;

    private GenericGrid<GridObject> grid;
    private DropManager dropManager;

    private MeshShape lShape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.right * 8.0f * 3, Vector3.up * 8.0f, new Vector3(3f, 1f, 0f) * 8.0f,
            new Vector3(2f, 0, 0) * 8.0f, new Vector3(2f, -1f, 0) * 8.0f, new Vector3(3f, -1f, 0) * 8.0f
        },

        Triangles = new int[] {
            0, 2, 1, 1, 2, 3, 1, 6, 5, 1, 5, 4
        },

        Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(1, 0), new IntPositions(2, 0), new IntPositions(2, -1) }
    };

    private MeshShape line1Shape = new MeshShape()
    {
        Vertices = new Vector3[] {
            Vector3.zero * 8.0f, Vector3.right * 8.0f, Vector3.up * 8.0f, new Vector3(1f, 1f, 0f) * 8.0f
        },

        Triangles = new int[] {
            0, 2, 1, 1, 2, 3
        },

        Positions = new IntPositions[] { new IntPositions(0, 0) }
    };

    //private MeshShape line3Shape = new MeshShape()
    //{
    //    Vertices = new Vector3[] {
    //        Vector3.zero * 8.0f, Vector3.right * 8.0f * 3, Vector3.up * 8.0f, new Vector3(3f, 1f, 0f) * 8.0f
    //    },

    //    Triangles = new int[] {
    //        0, 2, 1, 1, 2, 3, 1
    //    },

    //    Positions = new IntPositions[] { new IntPositions(0, 0), new IntPositions(1, 0), new IntPositions(2, 0) }
    //};

    public RotateableMeshShape line3Shape;

    public void Construct(GenericGrid<GridObject> grid, DropManager dropManager)
    {
        this.grid = grid;
        this.dropManager = dropManager;

        line3Shape = new Line3ShapeCreator().CreateShape();
    }

    private void Awake()
    {
        quadProceduralPrefab.gameObject.SetActive(false);
    }

    public ProceduralLShape CreateLShape()
    {
        return CreateShape(() => lShape);

    }

    public ProceduralLShape CreateLine3Shape(ShapeDirection direction)
    {
        return CreateShape(() => line3Shape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateQuad()
    {
        return CreateShape(() => line1Shape);

    }

    private ProceduralLShape CreateShape(Func<MeshShape> getMeshShape)
    {
        var shape = Instantiate(lShapePrefab, originPosition, Quaternion.identity, transform);
        shape.gameObject.SetActive(true);
        shape.Construct(getMeshShape());
        shape.GetComponent<DragDrop>().Construct(grid, dropManager);
        return shape;
    }
}
