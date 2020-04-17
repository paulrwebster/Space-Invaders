﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;


    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        Instantiate(
            waveConfig.GetSaucerPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
    }


}
