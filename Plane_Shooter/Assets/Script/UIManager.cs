using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText;

    public GameObject gameOverPanel;

    public GameObject gamePausePanel;

    public void SetScoreText(string txt) {
        if (scoreText) {
            scoreText.text = txt;
        }
    }

    public void ShowGameOverPannel(bool isShow) {
        if (gameOverPanel) {
            gameOverPanel.SetActive(isShow);
        }
    }

    public void ShowGamePausePanel(bool state) {
        if (gamePausePanel) {
            gamePausePanel.SetActive(state);
        }
    }

    public bool IsGamePause() {
        return gamePausePanel.activeInHierarchy;
    }

    public void Pause() {
        gamePausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        gamePausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
