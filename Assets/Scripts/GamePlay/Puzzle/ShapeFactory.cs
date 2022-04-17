using Puzzle;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ShapeFactory : MonoBehaviour
{
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private ShapeComponent lShapePrefab;
    [SerializeField] private GameObject groundPuzzlePrefab;
    [SerializeField] private GameObject treePuzzlePrefab;

    private float scale = 8.0f;

    private GenericGrid<PuzzleBlock> grid;
    private DropController dropController;
    private PreviewController previewController;
    private Puzzle.GroundFactory groundFactory;

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

    public void Construct(GenericGrid<PuzzleBlock> grid, DropController dropController, PreviewController previewController, Puzzle.GroundFactory groundFactory)
    {
        this.grid = grid;
        this.dropController = dropController;
        this.previewController = previewController;
        this.groundFactory = groundFactory;

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

    public ShapeComponent CreateShape(ShapeType type, ShapeDirection direction)
    {
        return CreateShape(() => shapes[type].GetMeshShape(direction), type, direction);
    }

    public MeshShape CreateMeshShape(ShapeType type, ShapeDirection direction)
    {
        return shapes[type].GetMeshShape(direction);
    }

    private ShapeComponent CreateShape(Func<MeshShape> getMeshShape, ShapeType type, ShapeDirection direction)
    {
        var meshShape = getMeshShape();
        var shape = Instantiate(lShapePrefab, originPosition, Quaternion.identity, transform);
        shape.Construct(grid, meshShape, type, direction);
        shape.gameObject.SetActive(true);
        shape.GetComponent<DragDropComponent>().Construct(grid, dropController, previewController);
        Array.ForEach(meshShape.Positions, pos => {
            var groundType = groundFactory.GetRandomGroundType();
            var position = new Vector3(originPosition.x + pos.x * scale + scale / 2.0f, originPosition.y + pos.y * scale + scale / 2.0f, originPosition.z);

            groundFactory.Create(groundType, position, shape.gameObject);
        });
        return shape;
    }
}
