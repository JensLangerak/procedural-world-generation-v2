using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float scale = 1.0f;

    public float verticalScale = 1.0f;

    [Range(0.0f, 0.10f)]
    public float freq1 = .05f;
    [Range(0.0f, 100.0f)]
    public float verticalScale1 = 20.0f;

    [Range(0.0f, 0.10f)]
    public float freq2 = .10f;
    [Range(0.0f, 20.0f)]
    public float verticalScale2 = 9.0f;

    [Range(0.0f, 0.5f)]
    public float freq3 = .30f;
    [Range(0.0f, 10.0f)]
    public float verticalScale3 = 3.0f;

    [Range(0.0f, 1.0f)]
    public float freq4 = .9f;
    [Range(0.0f, 4.0f)]
    public float verticalScale4 = 1.0f;

    [Range(0.0f, 0.10f)]
    public float freqe = .03f;
    [Range(0.0f, 2.0f)]
    public float verticalScalee = 1.0f;

    public float power = .25f;
    public int xOffset = 0;
    public int yOffset = 0;
    public int seed = 0;
    private bool drawn = true;
    public Renderer renderer;
    public MeshFilter meshFilter;

    private NoiseGenerator octave1;
    private NoiseGenerator octave2;
    private NoiseGenerator octave3;
    private NoiseGenerator octave4;
    private NoiseGenerator octavee;
    // Use this for initialization
    void Start () {
        System.Random random = new System.Random((int)seed);
        renderer = GetComponent<Renderer>();
        meshFilter = GetComponent<MeshFilter>();
        octave1 = new NoiseGenerator(0.03f, 30, new Vector2(random.Next(-100000, 100000), random.Next(-100000, 100000)));
        octave2 = new NoiseGenerator(0.07f, 8, new Vector2(random.Next(-100000, 100000), random.Next(-100000, 100000)));
        octave3 = new NoiseGenerator(0.1f, 3, new Vector2(random.Next(-100000, 100000), random.Next(-100000, 100000)));
        octave4 = new NoiseGenerator(0.7f, 0.5f, new Vector2(random.Next(-100000, 100000), random.Next(-100000, 100000)));

       octavee = new NoiseGenerator(0.02f, 0.5f, new Vector2(random.Next(-100000, 100000), random.Next(-100000, 100000)));
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMap();
    }

    public float[,] GenerateMap(int size, int pXOffset, int pYOffset)
    {
        float[,] result = new float[size, size];
        float xOffset = pXOffset - size / 2.0f;
        float yOffset = pYOffset - size / 2.0f;
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                var xCoord = x + xOffset;
                var yCoord = y + yOffset;
                result[y, x] = Mathf.Pow(
                    octave1.GetValue(new Vector2(xCoord, yCoord), freq1, verticalScale1) +
                    octave2.GetValue(new Vector2(xCoord, yCoord), freq2, verticalScale2) +
                    octave3.GetValue(new Vector2(xCoord, yCoord), freq3, verticalScale3) +
                    octave4.GetValue(new Vector2(xCoord, yCoord), freq4, verticalScale4) +
                   
                0, octavee.GetValue(new Vector2(xCoord, yCoord), freqe, verticalScalee) + power);
            }
        }
        return result;
    }


    public void UpdateMap()
    {
        if (drawn)
        {
            
            var mash = MeshGenerator.GenerateMesh(this.GenerateMap(128, xOffset, yOffset));
            meshFilter.mesh = mash;
            float[,] texture = new float[128, 128];
            for (int i = 0; i < 128; i++)
                for (int j = 0; j < 128;j++)
                    texture[i, j] = 0.5f;

                    TextureGenerator.SetTexture(renderer.sharedMaterial, texture);
            //   drawn = false;
        }
    }
}
