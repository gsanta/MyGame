
using System;
using System.Collections.Generic;
using UnityEngine;

public class PreviewController : MonoBehaviour
{
    private PuzzleGridSetup gridFactory;
    private GenericGrid<PuzzleBlock> grid;
    
    private ShapeComponent shape;
    private List<PuzzleTileComponent> tiles = new List<PuzzleTileComponent>();
    private IntPositions bottomLeftPos;

    public void Construct(GenericGrid<PuzzleBlock> grid, PuzzleGridSetup gridFactory)
    {
        this.grid = grid;
        this.gridFactory = gridFactory;
    }

    public void SetShape(ShapeComponent shape)
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
            var tile = gridFactory.CreateHighlightTile(grid, position.x, position.y);
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
