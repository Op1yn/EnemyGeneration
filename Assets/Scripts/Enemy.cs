using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _targetTransform;

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform transform)
    {
        _targetTransform = transform;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, _speed * Time.deltaTime);
        transform.LookAt(_targetTransform);
    }
}
