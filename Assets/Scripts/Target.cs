using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private int _currentPoint = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (HasPointReached())
        {
            SwitchRoutePoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, _speed * Time.deltaTime);
        transform.forward += _points[_currentPoint].position - transform.position;
    }

    private bool HasPointReached()
    {
        Vector3 offset = _points[_currentPoint].position - transform.position;

        return offset.sqrMagnitude == 0;
    }

    private void SwitchRoutePoint()
    {
        _currentPoint = (_currentPoint + 1) % _points.Length;
    }
}
