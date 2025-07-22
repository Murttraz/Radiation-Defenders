using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    
    // ensure we only have one MusicManager across all scenes.
    private static MusicManager instance;
    // create audioSource variable that plays music
    private AudioSource audioSource;

    void Awake() {

        // on Awake check if an instance already exists.
        if (instance == null) {

            // set it to not destroy between scenes.
            instance = this;
            DontDestroyOnLoad(gameObject);
            // Grab the attached AudioSource from the GameObject
            audioSource = GetComponent<AudioSource>();
            // Listen / detect when scenes are changed.
            SceneManager.sceneLoaded += OnSceneLoaded;

        } else {
            
            // if by chance an instance already exists, destroy the duplicate
            Destroy(gameObject);

        }

        // if a new scene is selected this method is triggered.
        void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

            // if any of the below three scenes are selected automatically stop the music.
            if (scene.name == "Tutorial" || scene.name == "Level_1" || scene.name == "Level_2" || scene.name ==  "Level_3") {
                audioSource.Stop();

            // otherwise if we arent on one of these maps and the music isn't playing, resume playing it.
            } else if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        }
    }
}
