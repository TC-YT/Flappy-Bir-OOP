using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float heightRange = 3f;

    void Start()
    {
        StartCoroutine(SpawnPipesRoutine());
    }

    IEnumerator SpawnPipesRoutine()
    {
        while (true)
        {
            SpawnPipe();
            yield return new WaitForSeconds(spawnRate);
        }

        while (!GameManager.Instance.IsGameStarted())
    {
        yield return null;
    }

    while (true)
    {
        if (GameManager.Instance.IsGameStarted() &&
            !GameManager.Instance.IsGameOver())
        {
            SpawnPipe();
        }

        yield return new WaitForSeconds(spawnRate);
    }
    }

    void SpawnPipe()
    {
        if (pipePrefab == null)
        {
            Debug.LogError("Pipe Prefab not assigned in SpawnManager!");
            return;
        }

        float randomY = Random.Range(-heightRange, heightRange);

        Vector3 spawnPosition = new Vector3(10f, randomY, 0f);

        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
