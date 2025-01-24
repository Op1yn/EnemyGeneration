using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms;
    [SerializeField] private float _speed;

    private int _currentPoint = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        CheckPoint();

        transform.position = Vector3.MoveTowards(transform.position, _transforms[_currentPoint].position, _speed * Time.deltaTime);
        transform.LookAt(_transforms[_currentPoint].position);
    }

    private void CheckPoint()
    {
        if (transform.position == _transforms[_currentPoint].position)
        {
            _currentPoint = (_currentPoint + 1) % _transforms.Length;
        }
    }
}
