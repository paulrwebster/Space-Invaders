using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject saucerPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfSaucers = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetSaucerPrefab() { return saucerPrefab; }
    //public GameObject GetPathPrefab() { return pathPrefab; }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumberOfSaucers() { return numberOfSaucers; }
    public float GetMoveSpeed() { return moveSpeed; }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }
}
