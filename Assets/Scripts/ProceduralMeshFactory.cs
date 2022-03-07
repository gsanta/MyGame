using System;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMeshFactory : MonoBehaviour
{
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private ProceduralQuad quadProceduralPrefab;
    [SerializeField] private ProceduralLShape lShapePrefab;

    private GenericGrid<GridObject> grid;
    private DropManager dropManager;

    private RotateableMeshShape l1Shape;
    private RotateableMeshShape l2Shape;
    private RotateableMeshShape z1Shape;
    private RotateableMeshShape z2Shape;
    private RotateableMeshShape line1Shape;
    private RotateableMeshShape line2Shape;
    public RotateableMeshShape line3Shape;
    public RotateableMeshShape square2Shape;
    public RotateableMeshShape square3Shape;
    public RotateableMeshShape square4Shape;

    private Dictionary<ShapeType, RotateableMeshShape> shapes = new Dictionary<ShapeType, RotateableMeshShape>();

    public void Construct(GenericGrid<GridObject> grid, DropManager dropManager)
    {
        this.grid = grid;
        this.dropManager = dropManager;

        line3Shape = new LineShapeCreator(3).CreateShape();
        line2Shape = new LineShapeCreator(2).CreateShape();
        line1Shape = new LineShapeCreator(1).CreateShape();
        l1Shape = new L1ShapeCreator().CreateShape();
        l2Shape = new L2ShapeCreator().CreateShape();
        z1Shape = new Z1ShapeCreator().CreateShape();
        z2Shape = new Z2ShapeCreator().CreateShape();
        square2Shape = new SquareShapeCreator(2).CreateShape();
        square3Shape = new SquareShapeCreator(3).CreateShape();
        square4Shape = new SquareShapeCreator(4).CreateShape();

        shapes.Add(ShapeType.Line1, line1Shape);
        shapes.Add(ShapeType.Line2, line2Shape);
        shapes.Add(ShapeType.Line3, line3Shape);
        shapes.Add(ShapeType.L1, l1Shape);
        shapes.Add(ShapeType.L2, l2Shape);
        shapes.Add(ShapeType.Z1, z1Shape);
        shapes.Add(ShapeType.Z2, z2Shape);
        shapes.Add(ShapeType.Square2, square2Shape);
        shapes.Add(ShapeType.Square3, square3Shape);
        shapes.Add(ShapeType.Square4, square4Shape);
    }

    private void Awake()
    {
        quadProceduralPrefab.gameObject.SetActive(false);
    }

    public ProceduralLShape CreateShape(ShapeType type, ShapeDirection direction)
    {
        return CreateShape(() => shapes[type].GetMeshShape(direction));
    }

    public ProceduralLShape CreateL1Shape(ShapeDirection direction)
    {
        return CreateShape(() => l1Shape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateL2Shape(ShapeDirection direction)
    {
        return CreateShape(() => l2Shape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateZ1Shape(ShapeDirection direction)
    {
        return CreateShape(() => z1Shape.GetMeshShape(direction));
    }

    public ProceduralLShape CreateZ2Shape(ShapeDirection direction)
    {
        return CreateShape(() => z2Shape.GetMeshShape(direction));
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
