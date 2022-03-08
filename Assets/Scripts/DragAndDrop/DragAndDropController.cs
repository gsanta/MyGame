
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    private PreviewManager previewManager;
    private RandomShapeChooser randomShapeChooser;
    private ProceduralMeshFactory meshFactory;
    private ProceduralShape currentShape;

    public void Construct(DropManager dropManager, PreviewManager previewManager, ProceduralMeshFactory meshFactory)
    {
        this.previewManager = previewManager;
        this.meshFactory = meshFactory;
        this.randomShapeChooser = new RandomShapeChooser(meshFactory);

        dropManager.ShapeDropped += ShapeDropped; 
    }

    public void Init()
    {
        currentShape = randomShapeChooser.ChooseShape();
    }

    void ShapeDropped(object sender, ShapeDroppedEventArgs args)
    {
        previewManager.Reset();
        Destroy(currentShape.gameObject);
        if (args.IsSuccess)
        {
            currentShape = randomShapeChooser.ChooseShape();
        } else
        {
            currentShape = meshFactory.CreateShape(currentShape.shapeType, currentShape.shapeDirection);
        }
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
