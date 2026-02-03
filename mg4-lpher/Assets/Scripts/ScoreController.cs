using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreController Instance;
    public int Score { get; private set; }
    public event Action<int> OnScoreChanged;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void AddPoint()
    {
        Score++;
        OnScoreChanged?.Invoke(Score);
    }
}
