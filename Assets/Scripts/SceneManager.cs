using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _count = 20;
    [SerializeField] private float _stepBetweenEnemies = 4f;
    [SerializeField] private float _delayBeforeSpawn = 0.1f;
    [SerializeField] private float _recoloringDuration = 0.5f; 
    [SerializeField] private float _delayBeforeRecoloring = 0.2f;

    private Enemy[,] _spawnedEnemy;

    private void Start()
    {
        _spawnedEnemy = new Enemy[_count, _count];

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for (var x = 0; x < _count; x++)
        {
            for (var z = 0; z < _count; z++)
            {
                var enemy = Instantiate(_enemyPrefab);

                enemy.transform.position = new Vector3(x * _stepBetweenEnemies, 0, z * _stepBetweenEnemies);

                _spawnedEnemy[x, z] = enemy;

                yield return new WaitForSeconds(_delayBeforeSpawn);
            }
        }
    }

    public void ChangeColor()
    {
        StartCoroutine(ChangeEnemiesColor());
    }

    private IEnumerator ChangeEnemiesColor()
    {
        var nextColor = Random.ColorHSV();

        for (var i = 0; i < _count; i++)
        {
            for (var j = 0; j < _count; j++)
            {
                _spawnedEnemy[i, j].SetColor(nextColor, _recoloringDuration);

                yield return new WaitForSeconds(_delayBeforeRecoloring);
            }
        }
    }
}