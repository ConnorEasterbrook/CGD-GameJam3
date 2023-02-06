using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    private int _spawnLevel = 0;
    private Bounds _spawnerBounds;
    private int _difficultyTick = 10;

    // Start is called before the first frame update
    void Start()
    {
        _spawnerBounds = GetComponent<BoxCollider>().bounds;

        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        if (_difficultyTick >= 20)
        {
            _spawnLevel++;
            _difficultyTick = 0;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            _difficultyTick++;
            int randomEnemy = Random.Range(0, 10);

            switch (_spawnLevel)
            {
                case 1:
                    Instantiate(_enemyPrefabs[0], new Vector3(Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x), Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y), Random.Range(_spawnerBounds.min.z, _spawnerBounds.max.z)), Quaternion.Euler(0, 0, 0));
                    break;

                case 2:
                    if (randomEnemy > 5)
                    {
                        randomEnemy = 1;
                    }
                    else
                    {
                        randomEnemy = 0;
                    }

                    Instantiate(_enemyPrefabs[randomEnemy], new Vector3(Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x), Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y), Random.Range(_spawnerBounds.min.z, _spawnerBounds.max.z)), Quaternion.Euler(0, 0, 0));
                    break;

                case 3:
                    if (randomEnemy > 7)
                    {
                        randomEnemy = 2;
                    }
                    else if (randomEnemy > 4)
                    {
                        randomEnemy = 1;
                    }
                    else
                    {
                        randomEnemy = 0;
                    }

                    Instantiate(_enemyPrefabs[randomEnemy], new Vector3(Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x), Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y), Random.Range(_spawnerBounds.min.z, _spawnerBounds.max.z)), Quaternion.Euler(0, 0, 0));
                    break;

                case 4:
                    if (randomEnemy > 9)
                    {
                        randomEnemy = 3;
                    }
                    else if (randomEnemy > 7)
                    {
                        randomEnemy = 2;
                    }
                    else if (randomEnemy > 4)
                    {
                        randomEnemy = 1;
                    }
                    else
                    {
                        randomEnemy = 0;
                    }

                    Instantiate(_enemyPrefabs[randomEnemy], new Vector3(Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x), Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y), Random.Range(_spawnerBounds.min.z, _spawnerBounds.max.z)), Quaternion.Euler(0, 0, 0));
                    break;
            }

            yield return new WaitForSeconds(5);
        }
    }
}
