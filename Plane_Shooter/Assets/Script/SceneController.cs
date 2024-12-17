using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static string previousScene;



    public void GoToSetting() {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Setting");
    }

    public void BackToPreviousScene() {
        if (!string.IsNullOrEmpty(previousScene)) {
            SceneManager.LoadScene(previousScene);

            if (AudioManager.instance != null) {
                AudioManager.instance.PlayRandomMusic();
            }
        }
    }
}
