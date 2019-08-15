using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerater : MonoBehaviour {
    private Vector3[] vertices;
    private int[] triangles;
    private Mesh mesh;
    private int xSize;
    private int zSize;
    private float height;

    private void Start() {
        height = 4f;
        xSize = 40;
        zSize = 400;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        StartCoroutine(CreateMesh());

        
    }

    private void Update() {
        UpdateMesh();
    }

    private IEnumerator CreateMesh() {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int z = 0; z < zSize + 1; z++) {
            for (int x = 0; x < xSize + 1; x++) {
                float y = Mathf.PerlinNoise(x*.2f, z*.2f)*height;
                vertices[(xSize + 1) * z + x] = new Vector3(x, y, z);
            }
                
        }
        

        triangles = new int[xSize * zSize * 6];
        int tris = 0;
        int verts = 0;
        for (int z = 0; z < zSize; z++) {
            for (var x = 0; x < xSize; x++) {
                triangles[tris + 0] = verts + 0;
                triangles[tris + 1] = verts + xSize + 1;
                triangles[tris + 2] = verts + 1;
                triangles[tris + 3] = verts + 1;
                triangles[tris + 4] = verts + xSize + 1;
                triangles[tris + 5] = verts + xSize + 2;
                verts++;
                tris += 6;
                
            }
            yield return new WaitForSeconds(.1f);

            verts++;
        }
        
    }

    private void UpdateMesh() {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }


}