using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Skor deðiþtiðinde tetiklenecek event
    public delegate void OnScoreChanged(int newScore);
    public event OnScoreChanged onScoreChanged;

    private int _scoreVal;
    public int scoreVal
    {
        get { return _scoreVal; }
        set
        {
            _scoreVal = value;
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

        onScoreChanged += UpdateScoreText;
        scoreVal = 0; 
    }

    void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score : " + newScore;
    }
}


