using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _timeBetweenSpawns;

    private Coroutine _spawnTimerCoroutine;

    private void Start()
    {
        _spawnTimerCoroutine = StartCoroutine(CreateEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawnTimerCoroutine);
    }

    private IEnumerator CreateEnemy()
    {
        WaitForSeconds waitingBeforeSpawn = new WaitForSeconds(_timeBetweenSpawns);

        while (enabled)
        {
            _spawnPoints[Random.Range(0, _spawnPoints.Count)].CreateEemy();

            yield return waitingBeforeSpawn;
        }
    }
}
