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

        Enemy enemy = enemyInstance.GetComponent<Enemy>();

        enemy.SetBehaviors(passiveBehavior, activeBehavior);
    }

    private IBehavior GetEnemyPassiveBehavior (GameObject enemyInstance)
    {
        switch (_passiveBehavior)
        {
            case PassiveBehaviors.idle:
                return new IdleBehavior();
            case PassiveBehaviors.patrol:
                return new PatrolBehavior(enemyInstance, _patrolRoute);
            case PassiveBehaviors.wander:
                return new WanderBehavior(enemyInstance);
            default:
                throw new Exception("Invalid behavior index");
        }
    }

    private IBehavior GetEnemyActiveBehavior (GameObject enemyInstance)
    {
        switch (_activeBehavior)
        {
            case ActiveBehaviors.flee:
                return new FleeBehavior(enemyInstance, _player.transform);
            case ActiveBehaviors.chase:
                return new ChaseBehavior(enemyInstance, _player.transform);
            case ActiveBehaviors.suicide:
                return new SuicideBehavior(enemyInstance);
            default:
                throw new Exception("Invalid behavior index");
        }
    }
}
