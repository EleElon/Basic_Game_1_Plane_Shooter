using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingController : MonoBehaviour {

    public SceneController scene;

    public void Back() {
        // scene.BackToPreviousScene();

        // if (AudioManager.instance != null) {
        //     AudioManager.instance.PlayRandomMusic();
        // }

        SceneManager.LoadScene("GamePlay");

        // AudioManager.instance.PlayRandomMusic();
    }
}
