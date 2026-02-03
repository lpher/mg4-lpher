using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreAudio : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    [SerializeField] private AudioClip scoreSound;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        ScoreController.Instance.OnScoreChanged += PlayScoreSound;
    }
    private void OnDisable()
    {
        ScoreController.Instance.OnScoreChanged -= PlayScoreSound;
    }
    private void PlayScoreSound(int newScore)
    {
        audioSource.PlayOneShot(scoreSound);
    }
}
