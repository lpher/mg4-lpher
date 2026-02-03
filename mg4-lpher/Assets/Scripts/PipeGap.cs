using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float minY = -1.5f;
    [SerializeField] private float maxY = 1.5f;
    void Start()
    {
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector3(transform.position.x, randomY, 0f);
    }
}
