using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GridRenderer : MonoBehaviour
{
    private GenericGrid<GridObject> grid;
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();
    
    public void Construct(GenericGrid<GridObject> grid)
    {
        this.grid = grid;
    }

    private void Start()
    {
        CreateGridLines();
    }

    private void CreateGridLines()
    {
        for (int y = 0; y <= grid.height; y++)
        {
            var start = grid.GetWorldPosition(0, y);
            var end = grid.GetWorldPosition(grid.width, y);
            CreateLine(start, end, "Row line " + y);
        }

        for (int x = 0; x <= grid.width; x++)
        {
            var start = grid.GetWorldPosition(x, 0);
            var end = grid.GetWorldPosition(x, grid.height);
            CreateLine(start, end, "Column line " + x);
        }
    }

    private void CreateLine(Vector3 start, Vector3 end, string label)
    {
        GameObject newLine = new GameObject(label);
        var lineRenderer = newLine.AddComponent<LineRenderer>();

        newLine.transform.parent = transform;

        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.positionCount = 2;
        lineRenderer.material.color = Color.blue;
        lineRenderer.SetPositions(new Vector3[] { start, end });
        lineRenderers.Add(lineRenderer);
    }
}
