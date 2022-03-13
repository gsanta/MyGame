using UnityEngine;

public class RandomShapeChooser : ShapeChooser
{
    private ShapeFactory meshFactory;

    public RandomShapeChooser(ShapeFactory meshFactory)
    {
        this.meshFactory = meshFactory;
    }

    public ProceduralShape ChooseShape()
    {
        var shapeNum = System.Enum.GetNames(typeof(ShapeType)).Length;
        var index = Random.Range(0, shapeNum);
        var shape = (ShapeType)index;
        return meshFactory.CreateShape(shape, ShapeDirection.Left);
    }
}
