
using System;
using System.Collections.Generic;
using UnityEngine;

public class PreviewManager : MonoBehaviour
{
    private LevelGridSetup gridFactory;
    private GenericGrid<Block2D> grid;
    
    private ProceduralShape shape;
    private List<Tile2D> tiles = new List<Tile2D>();
    private IntPositions bottomLeftPos;

    public void Construct(GenericGrid<Block2D> grid, LevelGridSetup gridFactory)
    {
        this.grid = grid;
        this.gridFactory = gridFactory;
    }

    public void SetShape(ProceduralShape shape)
    {
        this.shape = shape;
    }

    public void Reset()
    {
        ClearTiles();
    }

    public void UpdatePreview()
    {
        var positions = shape.GetPositions();
        
        if (bottomLeftPos.x != positions[0].x || bottomLeftPos.y != positions[0].y)
        {
            ClearTiles();
            CreateTiles();
        }
    }

    private void CreateTiles()
    {
        var positions = shape.GetPositions();
        bool isWithinBoundaries = Array.TrueForAll(positions, pos => grid.IsWithinGrid(pos.x, pos.y));

        if (!GridUtils.IsWithinBoundaries(positions, grid) || GridUtils.IsOccupied(positions, grid))
        {
            return;
        }

        foreach (var position in positions)
        {
            var tile = gridFactory.CreateTile(grid, position.x, position.y);
            tiles.Add(tile);
        }

        bottomLeftPos = positions[0];
    }

    private void ClearTiles()
    {
        tiles.ForEach(tile => Destroy(tile.gameObject));
        tiles.Clear();
    }
}
