//Copyright (c) 2019, Alejandro Silva and Diego Montoya in Collaboration with VFS

using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [Header("NEEDED")]
    [SerializeField] private EnemyRegister _EnemyList;
    [SerializeField] private SOTransform _Player;
    [SerializeField] private GameObject _StaticForward;

    [Header("ENEMIES DISTANCES")]
    [SerializeField] private float _DistanceInnerEnemies;
    [SerializeField] private float _DistanceToMoveBack;
    [SerializeField] private float _DistanceOutterEnemies;

    private float _Distance;
    private float _DegreesOfSeparationOutside;
    private float _DegreesOfSeparationInsside;
    private NavMeshAgent _NavMesh;
    // Start is called before the first frame update
    void Start()
    {
        _NavMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _Distance = Vector3.Distance(transform.position, _Player.value.position); //getting distance from player
        if (!_NavMesh.enabled) return;
        if (_EnemyList.EnemiesOutside.Count > 0) _DegreesOfSeparationOutside = _EnemyList.OutsideMaxAngleEnemies / _EnemyList.EnemiesOutside.Count;       //getting degrees of separation
        if (_EnemyList.EnemiesInside.Count > 0) _DegreesOfSeparationInsside = _EnemyList.InsideMaxAngleEnemies / _EnemyList.EnemiesInside.Count;

        if (_EnemyList.EnemiesInside.Count < _EnemyList.MaxiumEnemiesInside)
        {
            _EnemyList.RegisterEnemiesInside(gameObject);
        }
        else if (!_EnemyList.EnemiesOutside.Contains(gameObject) && !_EnemyList.EnemiesInside.Contains(gameObject))
        {
            _EnemyList.RegisterEnemiesOutside(gameObject);
        }

        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        print("made it to movetoplayer func");
        print("player transform " + _Player.value.position);
        if (_EnemyList.EnemiesInside.Contains(gameObject) && _Distance > _DistanceToMoveBack + .5)
        {
            int index = _EnemyList.EnemiesInside.IndexOf(gameObject);
            Quaternion rotation = Quaternion.AngleAxis(_DegreesOfSeparationInsside * index, Vector3.up);       //getting the distance to add with the correspondent degrees of separation
            Vector3 addDistanceToDirection = rotation * _StaticForward.transform.forward * _DistanceInnerEnemies;
            _NavMesh.SetDestination(_Player.value.position + addDistanceToDirection);

            if (_NavMesh.remainingDistance <= 1)        //if its close enough to the position of the navmesh 0
            {
                _NavMesh.isStopped = true;
            }
            else
            {
                _NavMesh.isStopped = false;
            }
        }

        //Outter enemies
        if (!_EnemyList.EnemiesInside.Contains(gameObject) && _EnemyList.EnemiesOutside.Contains(gameObject))
        {
            int index = _EnemyList.EnemiesOutside.IndexOf(gameObject);
            Quaternion rotation = Quaternion.AngleAxis(_DegreesOfSeparationOutside * index, Vector3.up);       //getting the distance to add with the correspondent degrees of separation
            Vector3 addDistanceToDirection = rotation * _StaticForward.transform.forward * _DistanceOutterEnemies;
            _NavMesh.SetDestination(_Player.value.position + addDistanceToDirection);

            if (_NavMesh.remainingDistance <= 1)        //if its close enough to the position of the navmesh 0
            {
                _NavMesh.isStopped = true;
            }
            else
            {
                _NavMesh.isStopped = false;
            }
        }
    }
}
