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
        
        tutorialButton.onClick.AddListener(SwapTutorialLevel);
        map1Button.onClick.AddListener(SwapLevel1);
        map2Button.onClick.AddListener(SwapLevel2);
        map3Button.onClick.AddListener(SwapLevel3);
        menuButton.onClick.AddListener(SwapMenu);
    }

    public void SwapTutorialLevel() {
        SceneManager.LoadScene("TutorialNarrative");
        Debug.Log("Tutorial Button Pressed");
    }

    public void SwapLevel1() {
        SceneManager.LoadScene("Level_1Narrative");
        Debug.Log("Level1 Button Pressed");
    }

    public void SwapLevel2() {
        SceneManager.LoadScene("Level_2Narrative");
    }

    public void SwapLevel3() {
        SceneManager.LoadScene("Level_3Narrative");
    }

    public void SwapMenu() {
        SceneManager.LoadScene("MainMenuNarrative");
    }

}
