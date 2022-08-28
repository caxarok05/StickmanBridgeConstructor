using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Scripts.UI
{
    public class DeathPanelScript : MonoBehaviour
    {

        [SerializeField] private GameObject _deathPanel;
        [SerializeField] private Text _scoreText;
        [SerializeField] private ScoreScript _scoreScript;

        #region MONO

        private void OnEnable()
        {
            Environment.DeathZoneScript.PlayerDies += ShowPanel;
            
        }

        private void OnDisable()
        {
            Environment.DeathZoneScript.PlayerDies -= ShowPanel;
        }
        #endregion

        public void PlayAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Update()
        {
            ShowScore();
        }
        private void ShowPanel()
        {
            _deathPanel.SetActive(true);
        }

        private void ShowScore()
        {
            _scoreText.text = "Your Score: " + _scoreScript._score;
        }

    }

}
