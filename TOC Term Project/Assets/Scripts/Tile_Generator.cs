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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GenerateTiles();
    }

    public void GenerateTiles()
    {
        // Sets size of grid
        int[,] grid = new int[xSize, ySize];
        Tile[,] tiles = new Tile[xSize, ySize];

        // Destroys existing tiles if there are any on screen
        var existingTiles = GameObject.FindGameObjectsWithTag("Tile");
        if (existingTiles.Length != 0) { for (int i = 0; i < existingTiles.Length; i++) { Destroy(existingTiles[i]); } }

        // This initializes the 2D array with a set of empty tiles, which allows empty spaces to be distinguishable
        // from non-empty spaces
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                var initTile = tiles[x, y] = Tile.CreateInstance<Tile>();
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
                // Ensures no infinite loops occur
                int count = 0;

                // Sort through array of tiles until a suitable tile is found
                // Generating a tile with two neighbors (both edges need to be checked)
                if (x > 0 && y > 0)
                {
                    // The next tile's bottom and left colors must match the top and right edges of the previous tiles
                    int right = tiles[x - 1, y].rightColor;
                    int top = tiles[x, y - 1].topColor;


                    while (count < 10000)
                    {
                        int i = Random.Range(0, tileSet.GetLength(0));

                        if (tileSet[i].leftColor == right && tileSet[i].bottomColor == top)
                        {
                            // Assigns values from chosen tile to slot in 2D array and instantiates a tile
                            var choice = tileSet[i];
                            tiles[x, y] = choice;
                            var newTile = Instantiate(templateTile, new Vector3(x, y, 0), Quaternion.identity, null);
                            newTile.GetComponent<SpriteRenderer>().sprite = choice.sprite;
                            // Sets a name for the tile for debugging
                            newTile.name = "Tile " + x.ToString() + ", " + y.ToString();

                            // Jumps back to main nested for loop once tile is found
                            goto Found;
                        }
                        else
                            count++;
                    }
                }
                // Generate bottom tile of a new column (only needs to check left edge)
                else if (x > 0)
                {
                    // The next tile's left color must match the right edge of the previous tile
                    int right = tiles[x - 1, 0].rightColor;

                    while (count < 10000)
                    {
                        int i = Random.Range(0, tileSet.GetLength(0));

                        if (tileSet[i].leftColor == right)
                        {
                            // Assigns values from chosen tile to slot in 2D array and instantiates a tile
                            var choice = tileSet[i];
                            tiles[x, y] = choice;
                            var newTile = Instantiate(templateTile, new Vector3(x, y, 0), Quaternion.identity, null);
                            newTile.GetComponent<SpriteRenderer>().sprite = choice.sprite;
                            // Sets a name for the tile for debugging
                            newTile.name = "Tile " + x.ToString() + ", " + y.ToString();

                            // Jumps back to main nested for loop once tile is found
                            goto Found;
                        }
                        else
                            count++;
                    }
                }
                // Generate tile in first column (after initial random tile)
                else if (y > 0)
                {
                    // The next tile's bottom color must match the top edge of the previous tile
                    int top = tiles[0, y - 1].topColor;

                    while (count < 10000)
                    {
                        int i = Random.Range(0, tileSet.GetLength(0));

                        if (tileSet[i].bottomColor == top)
                        {
                            // Assigns values from chosen tile to slot in 2D array and instantiates a tile
                            var choice = tileSet[i];
                            tiles[x, y] = choice;
                            var newTile = Instantiate(templateTile, new Vector3(x, y, 0), Quaternion.identity, null);
                            newTile.GetComponent<SpriteRenderer>().sprite = choice.sprite;
                            // Sets a name for the tile for debugging
                            newTile.name = "Tile " + x.ToString() + ", " + y.ToString();

                            // Jumps back to main nested for loop once tile is found
                            goto Found;
                        }
                        else
                            count++;
                    }
                }
                // Randomly chooses the first tile
                else
                {
                    // Assigns values from chosen tile to slot in 2D array and instantiates a tile
                    var choice = tileSet[Random.Range(0, tileSet.GetLength(0))];
                    tiles[x, y] = choice;
                    var newTile = Instantiate(templateTile, new Vector3(x, y, 0), Quaternion.identity, null);
                    newTile.GetComponent<SpriteRenderer>().sprite = choice.sprite;
                    // Sets a name for the tile for debugging
                    newTile.name = "Tile " + x.ToString() + ", " + y.ToString();
                }

            // Code will jump here once a suitable tile is found
            Found:
                continue;
            }
        }
    }
}
