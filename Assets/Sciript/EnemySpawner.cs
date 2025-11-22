using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float            _spawnCooldown;
    [SerializeField] private GameObject       _enemyPrefab;
    [SerializeField] private PassiveBehaviors _passiveBehavior;
    [SerializeField] private ActiveBehaviors  _activeBehavior;
    [SerializeField] private WaypointRoute    _patrolRoute;

    private float _remainingCooldown;

    private void Awake ()
    {
        _remainingCooldown = _spawnCooldown;
    }

    private void Update ()
    {
        _remainingCooldown -= Time.deltaTime;

        if (_remainingCooldown <= 0)
        {
            SpawnEnemy();
            _remainingCooldown = _spawnCooldown;
        }
    }

    private void SpawnEnemy ()
    {
        GameObject enemyInstance = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        Behavior   passiveBehavior;
        Behavior   activeBehavior;

        switch (_passiveBehavior)
        {
            case PassiveBehaviors.idle:
                passiveBehavior = enemyInstance.AddComponent<IdleBehavior>();
                break;
            case PassiveBehaviors.patrol:
                PatrolBehavior behavior = enemyInstance.AddComponent<PatrolBehavior>();
                behavior.SetRoute(_patrolRoute);
                passiveBehavior = behavior;
                break;
            case PassiveBehaviors.wander:
                passiveBehavior = enemyInstance.AddComponent<WanderBehavior>();
                break;
            default:
                throw new Exception("Invalid behavior index");
        }

        switch (_activeBehavior)
        {
            case ActiveBehaviors.flee:
                activeBehavior = enemyInstance.AddComponent<FleeBehavior>();
                break;
            case ActiveBehaviors.chase:
                activeBehavior = enemyInstance.AddComponent<ChaseBehavior>();
                break;
            case ActiveBehaviors.suicide:
                activeBehavior = enemyInstance.AddComponent<SuicideBehavior>();
                break;
            default:
                throw new Exception("Invalid behavior index");
        }

        Enemy enemy = enemyInstance.GetComponent<Enemy>();

        enemy.SetBehaviors(passiveBehavior, activeBehavior);
    }
}
