using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float scale = 1.0f;

    public int xOffset = 0;
    public int yOffset = 0;

    private Renderer renderer;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        TextureGenerator.SetTexture(renderer.material, NoiseGenerator.GenerateNoiseMap(256, xOffset, yOffset, scale));
    }
}
