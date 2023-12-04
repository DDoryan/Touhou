using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public GameObject gameOver;
    public GameObject pause;
    public TextMeshProUGUI score;
    public GameObject player;

    private void Start()
    {
        Instance = this;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string menu)
    {
        SceneManager.LoadScene(menu);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        score.text = "" + (int)((Time.time - player.GetComponent<Player>().startTime)*100)*100;
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void EndPause()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
}