using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float scale = 1.0f;

    public float verticalScale = 1.0f;
    public int xOffset = 0;
    public int yOffset = 0;
    private bool drawn = true;
    public Renderer renderer;
    public MeshFilter meshFilter;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        meshFilter = GetComponent<MeshFilter>();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMap();
    }

    public void UpdateMap()
    {
        if (drawn)
        {
            
            var mash = MeshGenerator.GenerateMesh(NoiseGenerator.GenerateNoiseMap(128, xOffset, yOffset, scale, verticalScale));
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
