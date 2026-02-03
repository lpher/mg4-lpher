using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnRate = 4f;

    private float timer;

    public static GameController Instance;

    public bool isGameOver { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void GameOver()
    {
        isGameOver = true;
    }
    void Update()
    {
        if (GameController.Instance.isGameOver)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }
    private void SpawnPipe()
    {
        Instantiate(pipePrefab, transform.position, Quaternion.identity);
    }
}
