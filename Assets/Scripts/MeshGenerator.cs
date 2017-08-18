using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator {

    public static Mesh GenerateMesh(float[,] map)
    {

        Mesh mesh = new Mesh();
        int sizeX = map.GetLength(0);
        int sizeZ = map.GetLength(1);
        float centerX = (sizeX - 1) / 2;
        float centerZ = (sizeZ - 1) / 2;

        Vector3[] vertices = new Vector3[sizeZ * sizeX];
        Vector2[] uv = new Vector2[sizeZ * sizeX];
        int[] triangles = new int[(sizeZ - 1) * (sizeX - 1) * 2 * 3];
        int verticeIndex = 0;
        int triangleIndex = 0;
        for (int z = 0; z < sizeZ; z++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                vertices[verticeIndex] = new Vector3(x - centerX,  map[z, x], z - centerZ);
                uv[verticeIndex] = new Vector2(((float) x) / sizeX, ((float) z) / sizeZ);
                if (z != 0)
                {
                    if (x != sizeX - 1)
                    {
                        triangles[triangleIndex] = verticeIndex - sizeZ + 1;
                        triangles[triangleIndex + 1] = verticeIndex - sizeZ;
                        triangles[triangleIndex + 2] = verticeIndex;
                        triangleIndex += 3;
                    }
                    if (x!=0)
                    {
                        triangles[triangleIndex] = verticeIndex - sizeZ;
                        triangles[triangleIndex + 1] = verticeIndex - 1;
                        triangles[triangleIndex + 2] = verticeIndex;
                        triangleIndex += 3;
                    }
                }

                verticeIndex++;
            }
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        
        mesh.RecalculateBounds();
        
        return mesh;
    }
}
