using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace DefenseGame.Menu {
    public class GameOverMenu : MonoBehaviour {
        [SerializeField] private GameObject canvas;
        [SerializeField] private TextMeshProUGUI waveSurvivedText;
        [SerializeField] private TextMeshProUGUI waveMaxText;
        
        public void Display() {
            canvas.SetActive(true);
            WaveSpawner waveSpawner = FindObjectOfType<WaveSpawner>();
            waveSurvivedText.text = (waveSpawner.waveIndex - 1).ToString();
            waveMaxText.text = waveSpawner.maxWaves.ToString();
            Time.timeScale = 0;
        }

        public void RestartGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GoToLevelSelect() {
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
