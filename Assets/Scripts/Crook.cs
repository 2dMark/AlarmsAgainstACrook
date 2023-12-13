using UnityEngine;

public class Crook : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;

    private Transform[] _wayPoints;
    private int _wayPointIndex;

    private void Awake()
    {
        _wayPoints = new Transform[_path.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_wayPointIndex].position, _speed * Time.deltaTime);
        transform.LookAt(_wayPoints[_wayPointIndex].position);

        if (transform.position == _wayPoints[_wayPointIndex].position)
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint() => _wayPointIndex = ++_wayPointIndex % _wayPoints.Length;
}