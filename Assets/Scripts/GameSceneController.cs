using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public TextMeshProUGUI gameText;
    public PlayerController player;

    public GameObject enemyPrefab;
    public GameObject enemySpawnPoint;
    private float enemyTimer;
    public float enemySpawnDuration;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        enemyTimer -= Time.deltaTime;
        if (enemyTimer <= 0)
        {
            enemyTimer = enemySpawnDuration;
            GameObject enemyObject = Instantiate(enemyPrefab);
            enemyObject.transform.SetParent(this.transform);
            enemyObject.transform.position = enemySpawnPoint.transform.position;
        }

        if (player == null)
        {
            gameText.text = "GAME OVER!";
        }

        if (Time.timeScale == 0)
        {
            gameText.text = "YOU WIN!";
        }


        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
