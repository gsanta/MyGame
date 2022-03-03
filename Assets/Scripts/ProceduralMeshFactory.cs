using System;
using UnityEngine;

public class ProceduralMeshFactory : MonoBehaviour
{
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private ProceduralQuad quadProceduralPrefab;
    [SerializeField] private ProceduralLShape lShapePrefab;

    private GenericGrid<GridObject> grid;
    private DropManager dropManager;

    private RotateableMeshShape lShape;
    private RotateableMeshShape line1Shape;
    private RotateableMeshShape line2Shape;
    public RotateableMeshShape line3Shape;
    public RotateableMeshShape square2Shape;
    public RotateableMeshShape square3Shape;
    public RotateableMeshShape square4Shape;

    public void Construct(GenericGrid<GridObject> grid, DropManager dropManager)
    {
        this.grid = grid;
        this.dropManager = dropManager;

        line3Shape = new LineShapeCreator(3).CreateShape();
        line2Shape = new LineShapeCreator(2).CreateShape();
        line1Shape = new LineShapeCreator(1).CreateShape();
        lShape = new LShapeCreator().CreateShape();
        square2Shape = new SquareShapeCreator(2).CreateShape();
        square3Shape = new SquareShapeCreator(3).CreateShape();
        square4Shape = new SquareShapeCreator(4).CreateShape();
    }

    private void Awake()
    {
        quadProceduralPrefab.gameObject.SetActive(false);
    }

    public ProceduralLShape CreateLShape(ShapeDirection direction)
    {
        return CreateShape(() => lShape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateLine1Shape(ShapeDirection direction)
    {
        return CreateShape(() => line1Shape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateLine2Shape(ShapeDirection direction)
    {
        return CreateShape(() => line2Shape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateLine3Shape(ShapeDirection direction)
    {
        return CreateShape(() => line3Shape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateSquare2Shape(ShapeDirection direction)
    {
        return CreateShape(() => square2Shape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateSquare3Shape(ShapeDirection direction)
    {
        return CreateShape(() => square3Shape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateSquare4Shape(ShapeDirection direction)
    {
        return CreateShape(() => square4Shape.GetMeshShape(direction));
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
