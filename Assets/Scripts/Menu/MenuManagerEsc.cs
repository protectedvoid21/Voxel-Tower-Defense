using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerEsc : MonoBehaviour {
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject pauseCanvas;

    private bool inMenu;
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            inMenu = !inMenu;
            canvas.SetActive(!canvas.activeSelf);
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            if(!inMenu) {
                canvas.SetActive(!canvas.activeSelf);
                Time.timeScale = Time.timeScale == 1 ? 0 : 1; 
            }
        }
    }
    
    public void Resume() {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }

    public void Options() {
        Debug.LogWarning("Options to be added soon");
    }

    public void ExitToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}