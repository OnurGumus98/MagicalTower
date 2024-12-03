using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
    public static gameControl instance;
    [SerializeField] GameObject gameOver;
    public static bool is_game_over;

    private void Awake()
    {
        is_game_over = false;

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void game_over()
    {
        is_game_over = true;
        gameOver.SetActive(!gameOver.activeInHierarchy);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
