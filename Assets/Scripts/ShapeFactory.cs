using System;
using System.Collections.Generic;
using UnityEngine;

public class ShapeFactory : MonoBehaviour
{
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private ProceduralShape lShapePrefab;

    private GenericGrid<Block2D> grid;
    private DropManager dropManager;
    private PreviewManager previewManager;

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

    public void Construct(GenericGrid<Block2D> grid, DropManager dropManager, PreviewManager previewManager)
    {
        this.grid = grid;
        this.dropManager = dropManager;
        this.previewManager = previewManager;

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

    public ProceduralShape CreateShape(ShapeType type, ShapeDirection direction)
    {
        return CreateShape(() => shapes[type].GetMeshShape(direction), type, direction);
    }

    public MeshShape CreateMeshShape(ShapeType type, ShapeDirection direction)
    {
        return shapes[type].GetMeshShape(direction);
    }

    private ProceduralShape CreateShape(Func<MeshShape> getMeshShape, ShapeType type, ShapeDirection direction)
    {
        var shape = Instantiate(lShapePrefab, originPosition, Quaternion.identity, transform);
        shape.Construct(grid, getMeshShape(), type, direction);
        shape.gameObject.SetActive(true);
        shape.GetComponent<DragDrop>().Construct(grid, dropManager, previewManager);
        return shape;
    }
}
