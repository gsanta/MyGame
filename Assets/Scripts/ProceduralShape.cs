
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class ProceduralShape : MonoBehaviour {
	private MeshShape meshShape;
	private GenericGrid<GridObject> grid;
	public float mZCoord;
	public Vector3 mOffset;
	public ShapeType shapeType;
	public ShapeDirection shapeDirection;

	public void Construct(GenericGrid<GridObject> grid, MeshShape meshShape, ShapeType shapeType, ShapeDirection shapeDirection) {
		this.grid = grid;
		this.meshShape = meshShape;
		this.shapeType = shapeType;
		this.shapeDirection = shapeDirection;

		var mesh = new Mesh
		{
			name = "Procedural Quad"
		};

		mesh.vertices = meshShape.Vertices;
		mesh.triangles = meshShape.Triangles;

		GetComponent<MeshFilter>().mesh = mesh;

		mesh.RecalculateBounds();

		GetComponent<MeshCollider>().sharedMesh = mesh;
	}

	private Vector3 GetMouseWorldPos()
	{
		Vector3 mousePoint = Input.mousePosition;
		mousePoint.z = mZCoord;

		var worldPoint = Camera.main.ScreenToWorldPoint(mousePoint);
		worldPoint.z = gameObject.transform.position.z;
		return worldPoint;
	}

	public IntPositions[] GetPositions()
	{
		int startX, startY;
		grid.GetXY(GetMouseWorldPos() + mOffset, out startX, out startY);

		IntPositions[] positions = new IntPositions[meshShape.Positions.Length];

		for(int i = 0; i < meshShape.Positions.Length; i++)
        {
			positions[i] = meshShape.Positions[i].Add(startX, startY);
        }


		return positions;
	}
}