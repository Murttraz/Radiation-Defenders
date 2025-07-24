using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenuSwap : MonoBehaviour {

    public Button menuButton;
    public GameObject panel; 

    void Start() {
        
        menuButton.onClick.AddListener(SwapMenu);
    }

    public void SwapMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowAttribs()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
