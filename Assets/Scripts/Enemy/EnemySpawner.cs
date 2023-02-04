using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    private int _spawnLevel = 1;
    private Bounds _spawnerBounds;

    // Start is called before the first frame update
    void Start()
    {
        _spawnerBounds = GetComponent<BoxCollider>().bounds;

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _spawnLevel = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _spawnLevel = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _spawnLevel = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _spawnLevel = 4;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int randomEnemy = Random.Range(0, 5);

            switch (_spawnLevel)
            {
                case 1:
                    Instantiate(_enemyPrefabs[0], new Vector3(Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x), Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y), Random.Range(_spawnerBounds.min.z, _spawnerBounds.max.z)), Quaternion.Euler(0, 0, 0));
                    break;

                case 2:
                    if (randomEnemy > 1)
                    {
                        randomEnemy = 1;
                    }

                    Instantiate(_enemyPrefabs[randomEnemy], new Vector3(Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x), Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y), Random.Range(_spawnerBounds.min.z, _spawnerBounds.max.z)), Quaternion.Euler(0, 0, 0));
                    break;

                case 3:
                    if (randomEnemy > 2)
                    {
                        randomEnemy = 2;
                    }

                    Instantiate(_enemyPrefabs[randomEnemy], new Vector3(Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x), Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y), Random.Range(_spawnerBounds.min.z, _spawnerBounds.max.z)), Quaternion.Euler(0, 0, 0));
                    break;

                case 4:
                    if (randomEnemy > 3)
                    {
                        randomEnemy = 3;
                    }

                    Instantiate(_enemyPrefabs[randomEnemy], new Vector3(Random.Range(_spawnerBounds.min.x, _spawnerBounds.max.x), Random.Range(_spawnerBounds.min.y, _spawnerBounds.max.y), Random.Range(_spawnerBounds.min.z, _spawnerBounds.max.z)), Quaternion.Euler(0, 0, 0));
                    break;
            }

            yield return new WaitForSeconds(5);
        }
    }
}
