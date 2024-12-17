using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText, bulletsText, healthText, staminaText;

    public GameObject gameOverPanel;

    public GameObject gamePausePanel;

    public GameObject gameSettingPanel;

    bool isGamePaused = false;

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

    public void ShowSettingPanel(bool state) {
        if (gameSettingPanel) {
            gameSettingPanel.SetActive(state);
        }
    }

    public bool IsGamePause() {
        return gamePausePanel.activeInHierarchy;
    }

    public bool IsSettingPanelActive() {
        return gameSettingPanel.activeInHierarchy;
    }

    public void Pause() {
        isGamePaused = true;
        gamePausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        isGamePaused = false;
        gamePausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenSettingFromPause() {
        gamePausePanel.SetActive(false);
        ShowSettingPanel(true);
        isGamePaused = true;
    }

    public void CloseSettingPanel() {
        ShowSettingPanel(false);
        ShowGamePausePanel(true);
    }

    public bool IsGamePaused() {
        return isGamePaused;
    }

    public void setBulletsText(string txt) {
        if (bulletsText) {
            bulletsText.text = txt;
        }
    }

    public void SetHealthText(string txt) {
        if (healthText)
            healthText.text = txt;
    }
}
