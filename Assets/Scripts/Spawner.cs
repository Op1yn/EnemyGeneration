using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
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
        Vector3 spawnPointPosition;

        while (enabled)
        {
            spawnPointPosition = spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position;
            Instantiate(_enemyPrefab, spawnPointPosition, GetDirection());

            yield return waitingBeforeSpawn;
        }
    }

    private Quaternion GetDirection()
    {
        float minAngle = 0;
        float maxAngle = 360;

        Quaternion direction = Quaternion.Euler(new Vector3(0, Random.Range(minAngle, maxAngle), 0));

        return direction;
    }
}
