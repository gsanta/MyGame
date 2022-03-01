
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class ProceduralLShape : MonoBehaviour, ProceduralShape {
	private MeshShape meshShape;

	public void Construct(MeshShape meshShape) {
		this.meshShape = meshShape;

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

	public IntPositions[] GetPositions()
	{
		int startX, startY;
		GetComponent<DragDrop>().GetDropPosition(out startX, out startY);

		IntPositions[] positions = new IntPositions[meshShape.Positions.Length];

		for(int i = 0; i < meshShape.Positions.Length; i++)
        {
			positions[i] = meshShape.Positions[i].Add(startX, startY);
        }


		return positions;
	}
}