﻿
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class ProceduralQuad : MonoBehaviour, ProceduralShape {

	public void Construct(float scale) {
		var mesh = new Mesh
		{
			name = "Procedural Quad"
		};

		mesh.vertices = new Vector3[] {
			Vector3.zero * scale, Vector3.right * scale, Vector3.up * scale, new Vector3(1f, 1f, 0f) * scale
		};

		GetComponent<MeshFilter>().mesh = mesh;

		mesh.triangles = new int[] {
			0, 2, 1, 1, 2, 3
		};

		mesh.RecalculateBounds();

		GetComponent<MeshCollider>().sharedMesh = mesh;
	}

    public IntPositions[] GetPositions()
    {
		int startX, startY;
		GetComponent<DragDrop>().GetDropPosition(out startX, out startY);

		return new IntPositions[] { new IntPositions(startX, startY) };
    }
}