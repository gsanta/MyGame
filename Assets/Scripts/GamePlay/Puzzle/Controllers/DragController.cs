
using UnityEngine;

public class DragController : MonoBehaviour
{
    private PreviewController previewController;
    private RandomShapeChooser randomShapeChooser;
    private ShapeFactory meshFactory;
    private GenericGrid<PuzzleBlock> grid;
    private ShapeComponent currentShape;
    private CanvasController canvasController;

    public void Construct(DropController dropController, PreviewController previewController, ShapeFactory meshFactory, GenericGrid<PuzzleBlock> grid, CanvasController canvasController)
    {
        this.previewController = previewController;
        this.meshFactory = meshFactory;
        this.grid = grid;
        this.canvasController = canvasController;
        randomShapeChooser = new RandomShapeChooser(meshFactory);

        dropController.ShapeDropped += ShapeDropped; 
    }

    public void Init()
    {
        currentShape = randomShapeChooser.ChooseShape();
    }

    public void DisableController()
    {
        if (currentShape)
        {
            Destroy(currentShape.gameObject);
            currentShape = null;
        }
    }

    void ShapeDropped(object sender, ShapeDroppedEventArgs args)
    {
        previewController.Reset();
        Destroy(currentShape.gameObject);
        if (args.IsSuccess)
        {
            currentShape = randomShapeChooser.ChooseShape();
            if (!CheckIfHasValidPosition())
            {
                canvasController.EndSetupLevel();
            }
        } else
        {
            currentShape = meshFactory.CreateShape(currentShape.shapeType, currentShape.shapeDirection);
        }
    }

    bool CheckIfHasValidPosition()
    {
        for (int i = 0; i < 4; i++)
        {
            var direction = (ShapeDirection)i;
            var type = currentShape.shapeType;
            var meshShape = meshFactory.CreateMeshShape(type, direction);
            var (left, bottom, right, top) = meshShape.Bounds;
            var (gridLeft, gridBottom, gridRight, gridTop) = (-left, -bottom, grid.width - right, grid.height - top);
            
            for (int j = gridLeft; j < gridRight; j++)
            {
                for (int k = gridBottom; k < gridTop; k++)
                {
                    IntPositions[] positions = new IntPositions[meshShape.Positions.Length];

                    for (int l = 0; l < meshShape.Positions.Length; l++)
                    {
                        positions[l] = meshShape.Positions[l].Add(j, k);
                    }

                    if (!GridUtils.IsOccupied(positions, grid))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void Rotate()
    {
        int nextShapeIndex = (int)currentShape.shapeDirection + 1;
        if (nextShapeIndex > 3)
        {
            nextShapeIndex = 0;
        }

        Destroy(currentShape.gameObject);
        currentShape = meshFactory.CreateShape(currentShape.shapeType, (ShapeDirection)nextShapeIndex);
    }
}
