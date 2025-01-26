using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        WaitForSeconds waitingBeforeSpawn = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            _spawnPoints[Random.Range(0, _spawnPoints.Count)].CreateEemy();

            yield return waitingBeforeSpawn;
        }
    }
}
