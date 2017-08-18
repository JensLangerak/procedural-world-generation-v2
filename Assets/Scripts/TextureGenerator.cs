using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGenerator {

    static public void SetTexture(Material material, float[,] map)
    {
        var texture = new Texture2D(map.GetLength(0), map.GetLength(1));
        material.mainTexture = texture;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = new Color(map[y,x], map[y, x], map[y, x]);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
    }

}
