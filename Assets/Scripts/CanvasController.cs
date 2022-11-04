using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public bool IsGameActive { get; private set; }

    [SerializeField]
    private GameObject canvasGame;

    [SerializeField]
    private GameObject canvasLose;

    [SerializeField]
    private GameObject canvasWin;

    [SerializeField]
    private Button startGameButton;

    [SerializeField]
    private Button restartGameButton;

    [SerializeField]
    private Button nextGameButton;

    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private Button exitButtonFromGame;

    [SerializeField]
    private Text levelCounter;

    [SerializeField]
    private Text completedLevelCounter;

    private SceneController sceneController;

    private void Awake()
    {
        startGameButton.onClick.AddListener(StartGame);
        restartGameButton.onClick.AddListener(RestartGame);
        nextGameButton.onClick.AddListener(NextGame);
        exitButton.onClick.AddListener(() => Application.Quit());
        exitButtonFromGame.onClick.AddListener(() => Application.Quit());

        sceneController = FindObjectOfType(typeof(SceneController)) as SceneController;
        levelCounter.text = $"Level : {SceneManager.GetActiveScene().buildIndex + 1}";
        completedLevelCounter.text = $"Level {SceneManager.GetActiveScene().buildIndex + 1} Completed!";
        levelCounter.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void LoseGame()
    {
        Progress.SnakeLength = -1;
        IsGameActive = false;
        canvasLose.gameObject.SetActive(true);
        levelCounter.gameObject.SetActive(false);
    }

    public void WinGame()
    {
        IsGameActive = false;
        canvasWin.gameObject.SetActive(true);
        levelCounter.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        IsGameActive = true;
        canvasGame.gameObject.SetActive(false);
        levelCounter.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        exitButtonFromGame.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Progress.SnakeLength = -1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextGame()
    {
        sceneController.LoadNextScene();
    }
}
