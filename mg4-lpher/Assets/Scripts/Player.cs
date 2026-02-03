using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip hitSound;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    private bool isAlive = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioSource.PlayOneShot(jumpSound);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            if (!isAlive)
                return;

            Die();
        }
    }
    private void Die()
    {
        isAlive = false;
        rb.velocity = Vector2.zero;

        audioSource.PlayOneShot(hitSound);

        GameController.Instance.GameOver();

        foreach (Pipe pipe in FindObjectsOfType<Pipe>())
        {
            Destroy(pipe.gameObject);
        }
    }
}
