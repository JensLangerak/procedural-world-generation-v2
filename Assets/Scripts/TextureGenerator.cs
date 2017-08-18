using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGenerator {

    static public void SetTexture(Material material)
    {
        var texture = new Texture2D(256, 256);
        material.mainTexture = texture;
        var topLeft = Color.red;
        var topRight = Color.green;
        var bottomLeft = Color.yellow;
        var bottomRight = Color.blue;


        for (int y = 0; y < texture.height; y++)
        {
            float top = y / (256.0f);
            Color left = Color.Lerp(bottomLeft, topLeft, top);
            Color right = Color.Lerp(bottomRight, topRight, top);

            for (int x = 0; x < texture.width; x++)
            {
                float grad = x / (256.0f);

                Color color = Color.Lerp(left, right, grad);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
    }

}
