using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelSwap : MonoBehaviour {

    public Button tutorialButton;
    public Button map1Button;
    public Button map2Button;
    public Button map3Button;
    public Button menuButton;

    void Start() {
        
        menuButton.onClick.AddListener(SwapTutorialLevel);
        map1Button.onClick.AddListener(SwapLevel1);
        map2Button.onClick.AddListener(SwapLevel2);
        map3Button.onClick.AddListener(SwapLevel3);
        menuButton.onClick.AddListener(SwapMenu);
    }

    public void SwapTutorialLevel() {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void SwapLevel1() {
        SceneManager.LoadScene("Map1");
    }

    public void SwapLevel2() {
        SceneManager.LoadScene("Map2");
    }

    public void SwapLevel3() {
        SceneManager.LoadScene("Map3");
    }

    public void SwapMenu() {
        SceneManager.LoadScene("MainMenu");
    }

}
