using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Generator : MonoBehaviour
{
    // Size of grid on the x axis
    public int xSize;
    // Size of grid on the y axis
    public int ySize;
    // Set of tiles to choose from
    public Tile[] tileSet;
    // Template tile that is instantiated into the scene
    // and filled with data from tileSet
    public GameObject templateTile;

    private void Start()
    {
        // Creates empty tiles in tile set to be filled with data from each of the template tiles
        for (int i = 0; i < tileSet.Length; i++) { tileSet[i] = new Tile(); }

        // Initializes tiles in tile set array
        FillTileInfo();
    }

    public void GenerateTiles()
    {
        // Sets size of grid
        int[,] grid = new int[xSize, ySize];
        Tile[,] tiles = new Tile[xSize, ySize];

        // This initializes the 2D array with a set of empty tiles, which allows empty spaces to be distinguishable
        // from non-empty spaces
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                var initTile = tiles[x, y] = new Tile();
                initTile.topColor = 0;
                initTile.bottomColor = 0;
                initTile.rightColor = 0;
                initTile.leftColor = 0;
            }
        }

        // 2D array for generating grid of tiles
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                // Sort through array of tiles until a suitable tile is found
                // Generating a tile with two neighbors (both edges need to be checked)
                if (x > 0 && y > 0)
                {

                }
                // Generate bottom tile of a new column (only needs to check left edge)
                else if (x > 0)
                {

                }
                // Generate tile in first column (after initial random tile)
                else if (y > 0)
                {

                }
                // Randomly chooses the first tile
                else
                {
                    var choice = tileSet[Random.Range(0, tileSet.GetLength(0))];

                    tiles[x, y] = choice;

                    var newTile = Instantiate(templateTile, new Vector3(x, y, 0), Quaternion.identity, null);

                    newTile.GetComponent<SpriteRenderer>().sprite = choice.sprite;
                }
            }
        }
    }

    // This function initializes all tiles in the tile set array
    public void FillTileInfo()
    {
        // Tile 0
        var tile0 = new Tile_0();
        tileSet[0].topColor = tile0.GetTopColor();
        tileSet[0].bottomColor = tile0.GetBottomColor();
        tileSet[0].rightColor = tile0.GetRightColor();
        tileSet[0].leftColor = tile0.GetLeftColor();
        tileSet[0].sprite = tile0.sprite;

        // Tile 1
        var tile1 = new Tile_1();
        tileSet[1].topColor = tile1.GetTopColor();
        tileSet[1].bottomColor = tile1.GetBottomColor();
        tileSet[1].rightColor = tile1.GetRightColor();
        tileSet[1].leftColor = tile1.GetLeftColor();
        tileSet[1].sprite = tile1.sprite;

        // Tile 2
        var tile2 = new Tile_2();
        tileSet[2].topColor = tile2.GetTopColor();
        tileSet[2].bottomColor = tile2.GetBottomColor();
        tileSet[2].rightColor = tile2.GetRightColor();
        tileSet[2].leftColor = tile2.GetLeftColor();
        tileSet[2].sprite = tile2.sprite;

        // Tile 3
        var tile3 = new Tile_3();
        tileSet[3].topColor = tile3.GetTopColor();
        tileSet[3].bottomColor = tile3.GetBottomColor();
        tileSet[3].rightColor = tile3.GetRightColor();
        tileSet[3].leftColor = tile3.GetLeftColor();
        tileSet[3].sprite = tile3.sprite;

        // Tile 4
        var tile4 = new Tile_4();
        tileSet[4].topColor = tile4.GetTopColor();
        tileSet[4].bottomColor = tile4.GetBottomColor();
        tileSet[4].rightColor = tile4.GetRightColor();
        tileSet[4].leftColor = tile4.GetLeftColor();
        tileSet[4].sprite = tile4.sprite;

        // Tile 5
        var tile5 = new Tile_5();
        tileSet[5].topColor = tile5.GetTopColor();
        tileSet[5].bottomColor = tile5.GetBottomColor();
        tileSet[5].rightColor = tile5.GetRightColor();
        tileSet[5].leftColor = tile5.GetLeftColor();
        tileSet[5].sprite = tile5.sprite;

        // Tile 6
        var tile6 = new Tile_6();
        tileSet[6].topColor = tile6.GetTopColor();
        tileSet[6].bottomColor = tile6.GetBottomColor();
        tileSet[6].rightColor = tile6.GetRightColor();
        tileSet[6].leftColor = tile6.GetLeftColor();
        tileSet[6].sprite = tile6.sprite;

        // Tile 7
        var tile7 = new Tile_7();
        tileSet[7].topColor = tile7.GetTopColor();
        tileSet[7].bottomColor = tile7.GetBottomColor();
        tileSet[7].rightColor = tile7.GetRightColor();
        tileSet[7].leftColor = tile7.GetLeftColor();
        tileSet[7].sprite = tile7.sprite;

        // Tile 8
        var tile8 = new Tile_8();
        tileSet[8].topColor = tile8.GetTopColor();
        tileSet[8].bottomColor = tile8.GetBottomColor();
        tileSet[8].rightColor = tile8.GetRightColor();
        tileSet[8].leftColor = tile8.GetLeftColor();
        tileSet[8].sprite = tile8.sprite;
    }
}
