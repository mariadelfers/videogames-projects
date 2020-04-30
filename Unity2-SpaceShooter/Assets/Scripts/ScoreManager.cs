using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private int _currentScore = 0;
    public int currentScore
    {
        get
        {
            return _currentScore;
        }
        private set
        {
            _currentScore = value;
            UpdateScoreText();
        }
    }

    public Text scoreLabel;
    public Text bestScoreLabel;
    private int bestScore;
    private string bestScoreKey = "BEST_SCORE_SAVE";

    // Use this for initialization
    void Start () {
        UpdateScoreText();
        bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);
        bestScoreLabel.text = "Best Score: " + bestScore;
	}

    void OnDestroy()
    {
        if (bestScore < currentScore){
            PlayerPrefs.SetInt(bestScoreKey, currentScore);
        }
    }
	
	// Update is called once per frame
	void UpdateScoreText () {
       scoreLabel.text = "Score: " + currentScore;
	}

    public void AddScore(int scoreAmount)
    {
        currentScore += scoreAmount;
    }
}
