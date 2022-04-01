using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDebug : MonoBehaviour
{
    public TextMesh[] textElements;

    public void populateTextElements(int left = -1, int top = -1, int right = -1, int bottom = -1)
    {
        textElements[0].text = left.ToString();
        textElements[1].text = top.ToString();
        textElements[2].text = right.ToString();
        textElements[3].text = bottom.ToString();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            foreach (TextMesh element in textElements)
            {
                element.gameObject.SetActive(!element.gameObject.activeSelf);
            }
        }
    }
}
