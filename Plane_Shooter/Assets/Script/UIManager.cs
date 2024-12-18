using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [Header("---------- Element ----------")]

    public Text scoreText;

    public Text bulletsText;

    public Text healthText;

    [Header("---------- Title ----------")]

    public Text scoreTitle;

    public Text bulletTitle;

    public Text healthTitle;

    public Text staminaTitle;

    [Header("---------- Panel ----------")]

    public GameObject gameOverPanel;

    public GameObject gamePausePanel;

    public GameObject gameSettingPanel;

    Stamina m_stm;

    bool isGamePaused = false;

    private void Start() {
        m_stm = FindAnyObjectByType<Stamina>();
    }

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

    public void SetUIDisable() {
        if (scoreText && scoreTitle) {
            scoreText.gameObject.SetActive(false);
            scoreTitle.gameObject.SetActive(false);
        }
        if (bulletsText && bulletTitle) {
            bulletsText.gameObject.SetActive(false);
            bulletTitle.gameObject.SetActive(false);
        }
        if (healthText && healthTitle) {
            healthText.gameObject.SetActive(false);
            healthTitle.gameObject.SetActive(false);
        }
        if (m_stm.staminaSlider && staminaTitle && m_stm.easeStaminaSlider) {
            m_stm.staminaSlider.gameObject.SetActive(false);
            m_stm.easeStaminaSlider.gameObject.SetActive(false);
            staminaTitle.gameObject.SetActive(false);
        }
    }

    public void SetUIEnable() {
        if (scoreText && scoreTitle) {
            scoreText.gameObject.SetActive(true);
            scoreTitle.gameObject.SetActive(true);
        }
        if (bulletsText && bulletTitle) {
            bulletsText.gameObject.SetActive(true);
            bulletTitle.gameObject.SetActive(true);
        }
        if (healthText && healthTitle) {
            healthText.gameObject.SetActive(true);
            healthTitle.gameObject.SetActive(true);
        }
        if (m_stm.staminaSlider && staminaTitle && m_stm.easeStaminaSlider) {
            m_stm.staminaSlider.gameObject.SetActive(true);
            m_stm.easeStaminaSlider.gameObject.SetActive(true);
            staminaTitle.gameObject.SetActive(true);
        }
    }

    public bool IsGamePausePanelActive() {
        return gamePausePanel.activeInHierarchy;
    }

    public bool IsSettingPanelActive() {
        return gameSettingPanel.activeInHierarchy;
    }

    public bool IsGameOverPanelActive() {
        return gameOverPanel.activeInHierarchy;
    }

    public void Pause() {
        SetUIDisable();
        isGamePaused = true;
        gamePausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        SetUIEnable();
        isGamePaused = false;
        gamePausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void StartGame() {
        gameOverPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        gameSettingPanel.SetActive(false);
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
