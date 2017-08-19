using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator {
    private float frequency;
    private float scale;
    private Vector2 offset;

    public NoiseGenerator(float pFrequency, float pScale, Vector2 pOffset)
    {
        frequency = pFrequency;
        scale = pScale;
        offset = pOffset;
    }

    public float GetValue(Vector2 coords, float frequency, float scale)
    {
        var xCoord = coords.x * frequency + offset.x;
        var yCoord = coords.y * frequency + offset.y;
        return Mathf.PerlinNoise(xCoord, yCoord) * scale;
    }



    public static float[,] GenerateNoiseMap(int size, int pXOffset, int pYOffset, float frequency, float verticalScale)
    {
        float[,] result = new float[size, size];
        float xOffset = pXOffset - size / 2.0f * frequency;
        float yOffset = pYOffset - size / 2.0f * frequency;
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                var xCoord = x * frequency + xOffset;
                var yCoord = y * frequency + yOffset;
                result[y,x] = Mathf.PerlinNoise(xCoord, yCoord) * verticalScale;
            }
        }
        return result; 
    }
}
