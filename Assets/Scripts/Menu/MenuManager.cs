using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefenseGame.Menu {
    public class MenuManager : MonoBehaviour {
        public void StartGame() {
            SceneManager.LoadScene("LevelSelect");
        }

        public void ToMainMenu() {
            SceneManager.LoadScene("MainMenu");
        }

        public void ExitGame() {
            Application.Quit();
        }
    }
}