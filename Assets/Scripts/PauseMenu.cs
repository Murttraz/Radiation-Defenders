using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour{

    public GameObject pauseMenu;
    public Button menuButton;
    public Button quitButton;
    public bool isPaused;

    void Start() {
        pauseMenu.SetActive(false);
        menuButton.onClick.AddListener(SwapMenu);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update() {
    
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Escape key pressed!");
            if (isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SwapMenu() {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel() {
        if(SceneManager.GetActiveScene().name == "Level_1") {
            SceneManager.LoadScene("Level_2");
        } 
        else if (SceneManager.GetActiveScene().name == "Level_2")
        {
            SceneManager.LoadScene("Level_3");
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
