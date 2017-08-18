using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator {

    public static float[,] GenerateNoiseMap(int size, int pXOffset, int pYOffset, float scale)
    {
        float[,] result = new float[size, size];
        float xOffset = pXOffset - size / 2.0f * scale;
        float yOffset = pYOffset - size / 2.0f * scale;
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                var xCoord = x * scale + xOffset;
                var yCoord = y * scale + yOffset;
                result[y,x] = Mathf.PerlinNoise(xCoord, yCoord);
            }
        }
        return result; 
    }
}
