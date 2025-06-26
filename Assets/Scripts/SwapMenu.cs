using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwapMenu : MonoBehaviour {

    public Button playButton;
    public Button creditsButton;
    public Button quitButton;

    void Start() {
        
        playButton.onClick.AddListener(PlayGame);
        creditsButton.onClick.AddListener(CreditScene);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void PlayGame() {
        SceneManager.LoadScene("SelectMapMenu");
    }

    public void CreditScene() {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
