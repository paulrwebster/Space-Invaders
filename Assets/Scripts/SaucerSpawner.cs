using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class SaucerSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    public float minWait = 12;
    public float maxWait = 30;
    private bool isSpawning;

    int startingWave = 0;

    private void Awake()
    {
        isSpawning = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private void Update()
    {
        if (!isSpawning)
        {
            //float timer = Random.Range(minWait, maxWait);
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        while (true)
        {
            Instantiate(
                waveConfig.GetSaucerPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            // yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        }
    }


}
