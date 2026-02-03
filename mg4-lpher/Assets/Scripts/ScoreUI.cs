using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Start()
    {
        if (ScoreController.Instance != null)
        {
            ScoreController.Instance.OnScoreChanged += UpdateScore;
        }
    }
    private void OnDestroy()
    {
        if (ScoreController.Instance != null)
        {
            ScoreController.Instance.OnScoreChanged -= UpdateScore;
        }
    }
    private void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
