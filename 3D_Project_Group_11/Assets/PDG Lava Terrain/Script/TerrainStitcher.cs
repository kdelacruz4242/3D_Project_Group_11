
using UnityEngine;
using System.Collections;

public class TerrainStitcher : MonoBehaviour
{
    public Terrain terrainLeft;
    public Terrain terrainTop;
    public Terrain terrainRight;
    public Terrain terrainBottom;

    void Start()
    {
        Terrain thisTerrain = GetComponent<Terrain>();
        thisTerrain.SetNeighbors(terrainLeft, terrainTop, terrainRight, terrainBottom);
    }
}