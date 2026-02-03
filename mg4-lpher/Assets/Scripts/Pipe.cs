using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float despawnX = -3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.isGameOver)
            return;
        Move();
        CheckDespawn();
    }
    private void Move()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    private void CheckDespawn()
    {
        if (transform.position.x < despawnX)
        {
            Destroy(gameObject);
        }
    }
}
