using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Skor de�i�ti�inde tetiklenecek event
    public delegate void OnScoreChanged(int newScore);
    public event OnScoreChanged onScoreChanged;

    private int _scoreVal;
    public int scoreVal
    {
        get { return _scoreVal; }
        set
        {
            _scoreVal = value;
            // Her skor de�i�iminde event tetiklenir
            if (onScoreChanged != null)
            {
                onScoreChanged(_scoreVal);
            }
        }
    }

    public Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Skor de�i�ti�inde bu fonksiyon tetiklenir
        onScoreChanged += UpdateScoreText;
        scoreVal = 0; // Ba�lang�� de�eri
    }

    // Skor metnini g�nceller
    void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score : " + newScore;
    }
}
