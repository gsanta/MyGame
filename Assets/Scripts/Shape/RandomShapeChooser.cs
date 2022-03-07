using UnityEngine;

public class RandomShapeChooser : ShapeChooser
{
    private ProceduralMeshFactory meshFactory;

    public RandomShapeChooser(ProceduralMeshFactory meshFactory)
    {
        this.meshFactory = meshFactory;
    }

    public ProceduralLShape ChooseShape()
    {
        var shapeNum = System.Enum.GetNames(typeof(ShapeType)).Length;
        var index = Random.Range(0, shapeNum);
        var shape = (ShapeType)index;
        return meshFactory.CreateShape(shape, ShapeDirection.Left);
    }
}
