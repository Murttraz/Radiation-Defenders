using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NarrativeSwap : MonoBehaviour {

    public Button continueButton;

    void Start() {

        continueButton.onClick.AddListener(ContinueToLevel); 
    }


    void ContinueToLevel() {
        if (SceneManager.GetActiveScene().name == "TutorialNarrative") {
                SceneManager.LoadScene("Tutorial");

        } else if (SceneManager.GetActiveScene().name == "Level_1Narrative") {
                SceneManager.LoadScene("Level_1");

        } else if (SceneManager.GetActiveScene().name == "Level_2Narrative") {
                SceneManager.LoadScene("Level_2");

        } else if (SceneManager.GetActiveScene().name == "Level_3Narrative") {
                SceneManager.LoadScene("Level_3");
        }
    }
}
