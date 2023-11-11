using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    WaveConfigSO waveConfig;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < waveConfig.GetEnemyCount(); i++)
        {
            Instantiate(waveConfig.GetEnemyPrefab(i),
            waveConfig.GetStartingWayPoint().position,
            Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    public WaveConfigSO GetWaveConfig()
    {
        return waveConfig;
    }
}
