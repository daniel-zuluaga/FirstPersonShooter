using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    [Header("HUD")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;
    public GameObject pauseButton;

    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    // instance
    public static GameUI instance;

    private void Awake()
    {
        // set the instance to this script
        instance = this;

    }

    public void UpdateHealthBar (int curHp, int maxHp)
    {
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;
    }

    public void UpdateScoreText (int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateAmmoText (int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }

    public void TogglePauseMenu (bool paused)
    {
        pauseMenu.SetActive(paused);
    }

    public void SetEndGameScreen (bool won, int score)
    {
        endGameScreen.SetActive(true);
        endGameHeaderText.text = won == true ? " You win :D !!" : " You lose :( !!";
        endGameHeaderText.color = won == true ? Color.green : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score;
    }

    public void OnContinueButton()
    {
        GameManager.instance.TogglePauseGame();
        pauseButton.SetActive(true);
    }

    public void OnPauseButton()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        GameManager.instance.TogglePauseGame();
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
