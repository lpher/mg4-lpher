using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreZone : MonoBehaviour
{
    // Start is called before the first frame update
    private bool scored = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (scored)
            return;

        if (other.CompareTag("Player"))
        {
            scored = true;
            ScoreController.Instance.AddPoint();
        }
    }
}
