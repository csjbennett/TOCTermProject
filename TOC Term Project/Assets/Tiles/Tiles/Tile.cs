using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "ScriptableObjects/Tile")]
public class Tile : ScriptableObject
{
    public int topColor;
    public int bottomColor;
    public int rightColor;
    public int leftColor;

    public Sprite sprite;
}
