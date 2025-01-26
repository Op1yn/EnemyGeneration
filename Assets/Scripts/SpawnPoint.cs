using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Target _target;

    public void CreateEemy()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity).SetTarget(_target.transform);
    }
}
