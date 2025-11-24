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
    [SerializeField] private Player           _player;

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
        IBehavior   passiveBehavior = GetEnemyPassiveBehavior(enemyInstance);
        IBehavior   activeBehavior = GetEnemyActiveBehavior(enemyInstance);

        // switch (_passiveBehavior)
        // {
        //     case PassiveBehaviors.idle:
        //         passiveBehavior = enemyInstance.AddComponent<IdleBehavior>();
        //         break;
        //     case PassiveBehaviors.patrol:
        //         PatrolBehavior behavior = enemyInstance.AddComponent<PatrolBehavior>();
        //         behavior.SetRoute(_patrolRoute);
        //         passiveBehavior = behavior;
        //         break;
        //     case PassiveBehaviors.wander:
        //         passiveBehavior = enemyInstance.AddComponent<WanderBehavior>();
        //         break;
        //     default:
        //         throw new Exception("Invalid behavior index");
        // }
        //
        // switch (_activeBehavior)
        // {
        //     case ActiveBehaviors.flee:
        //         activeBehavior = enemyInstance.AddComponent<FleeBehavior>();
        //         break;
        //     case ActiveBehaviors.chase:
        //         activeBehavior = enemyInstance.AddComponent<ChaseBehavior>();
        //         break;
        //     case ActiveBehaviors.suicide:
        //         activeBehavior = enemyInstance.AddComponent<SuicideBehavior>();
        //         break;
        //     default:
        //         throw new Exception("Invalid behavior index");
        // }

        Enemy enemy = enemyInstance.GetComponent<Enemy>();

        enemy.SetBehaviors(passiveBehavior, activeBehavior);
    }

    private IBehavior GetEnemyPassiveBehavior (GameObject enemyInstance)
    {
        switch (_passiveBehavior)
        {
            case PassiveBehaviors.idle:
                return enemyInstance.AddComponent<IdleBehavior>();
            case PassiveBehaviors.patrol:
                PatrolBehavior patrolBehavior = enemyInstance.AddComponent<PatrolBehavior>();
                patrolBehavior.SetRoute(_patrolRoute);
                return patrolBehavior;
            case PassiveBehaviors.wander:
                return enemyInstance.AddComponent<WanderBehavior>();
            default:
                throw new Exception("Invalid behavior index");
        }
    }

    private IBehavior GetEnemyActiveBehavior (GameObject enemyInstance)
    {
        switch (_activeBehavior)
        {
            case ActiveBehaviors.flee:
                FleeBehavior fleeBehavior = enemyInstance.AddComponent<FleeBehavior>();
                fleeBehavior.SetTarget(_player.transform);
                return fleeBehavior;
            case ActiveBehaviors.chase:
                ChaseBehavior chaseBehavior = enemyInstance.AddComponent<ChaseBehavior>();
                chaseBehavior.SetTarget(_player.transform);
                return chaseBehavior;
            case ActiveBehaviors.suicide:
                return enemyInstance.AddComponent<SuicideBehavior>();
            default:
                throw new Exception("Invalid behavior index");
        }
    }
}
