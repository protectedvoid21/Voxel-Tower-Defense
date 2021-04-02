using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public string playSceneName;

    public void StartGame() {
        SceneManager.LoadScene(playSceneName);
    }
    public void ExitGame() {
        Application.Quit();
    }
}