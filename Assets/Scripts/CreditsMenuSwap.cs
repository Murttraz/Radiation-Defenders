using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenuSwap : MonoBehaviour {

    public Button menuButton;

    void Start() {
        
        menuButton.onClick.AddListener(SwapMenu);
    }

    public void SwapMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
