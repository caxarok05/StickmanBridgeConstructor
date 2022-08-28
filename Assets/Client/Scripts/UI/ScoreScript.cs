using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class ScoreScript : MonoBehaviour
    {
        private int _highScore = 0;

        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _highScoreText;

        public int _score { get; private set; }

        #region MONO

        private void Awake()
        {
            _highScore = PlayerPrefs.GetInt("HighScoreKey");
        }
        private void OnEnable()
        {
            Environment.AddScoreZoneScript.AddScore += AddScore;
        }
        private void OnDisable()
        {
            Environment.AddScoreZoneScript.AddScore -= AddScore;
        
        }
        #endregion

        private void Update()
        {
            _scoreText.text = string.Empty + _score;
            _highScoreText.text = "Highscore: " + _highScore;
        }

        private void AddScore()
        {
            _score++;
            if (_highScore <= _score)
            {
                _highScore = _score;
                PlayerPrefs.SetInt("HighScoreKey", _highScore);
            }
        }

    }
}

