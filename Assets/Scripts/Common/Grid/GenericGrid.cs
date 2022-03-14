using System;
using UnityEngine;

public class GenericGrid<TGridObject>
{
    public readonly int width;
    public readonly int height;
    private float cellSize;
    private TGridObject[,] gridArray;
    private Vector3 originPosition;
    private Vector3 worldSize;

    public GenericGrid(int width, int height, float cellSize, Vector3 originPosition, Func<int, int, TGridObject> createGridObject)
    {
        this.originPosition = originPosition;
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        worldSize = new Vector3(width * cellSize, height * cellSize, 0);

        gridArray = new TGridObject[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = createGridObject(x, y);
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        var position = new Vector3(x, y) * cellSize + originPosition - worldSize / 2;
        position.z = originPosition.z;
        return position;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition + worldSize / 2).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition + worldSize / 2).y / cellSize);
    }

    public bool IsWithinGrid(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public void SetValue(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
        }
    }

    public void SetValue(Vector3 worldPosition, TGridObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }

    public TGridObject[] GetColumnObjects(int x)
    {
        TGridObject[] row = new TGridObject[width];

        for (int i = 0; i < width; i++)
        {
            row[i] = gridArray[x, i];
        }

        return row;
    }

    public TGridObject[] GetRowObjects(int y)
    {
        TGridObject[] columns = new TGridObject[height];

        for (int i = 0; i < height; i++)
        {
            columns[i] = gridArray[i, y];
        }

        return columns;
    }

    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(TGridObject);
        }
    }
}
