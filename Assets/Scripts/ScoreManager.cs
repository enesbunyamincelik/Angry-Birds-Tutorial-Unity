using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _highScoreText;
    [SerializeField] int _addedScore = 10;

    int _score = 0;
    int _highScore;
    void Awake()
    {
        ScoreManager[] scoreManager = FindObjectsOfType<ScoreManager>();    
        if (scoreManager.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        _score = 0;
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateTextScore();
    }
    void UpdateTextScore()
    {
        _scoreText.text = "Score: " + _score;
        _highScoreText.text = "HighScore: " + _highScore;
    }

    public void AddScore()
    {
        _score += _addedScore;
        UpdateTextScore();

        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
    }
}   