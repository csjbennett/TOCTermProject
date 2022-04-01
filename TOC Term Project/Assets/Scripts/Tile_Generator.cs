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
        GenerateTiles();
    }

    public void GenerateTiles()
    {
        int[,] grid = new int[xSize, ySize];
        Tile[,] tiles = new Tile[xSize, ySize];

        // 2D array for generating grid of tiles
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                // Sort through array of tiles until a suitable tile is found
                if (x > 0 && y > 0)
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
}
