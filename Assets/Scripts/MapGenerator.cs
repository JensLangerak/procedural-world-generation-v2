using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var renderer = GetComponent<Renderer>();
        TextureGenerator.SetTexture(renderer.material);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
