using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamePaused = false;
    bool gameOver = false;
    [SerializeField] Spaceship player;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] int numEnemies;
    [SerializeField] float TiempoCongelado;

    int cargasDeRalentizador = 0;
    float congelar = 0;
    bool CambiarTiempo = true;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOver == false)
            PauseGame();

        if (CambiarTiempo)
            Ralentizar();
         
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Startlevel2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Startlevel3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void Startlevelmenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    void PauseGame()
    {
        gamePaused = gamePaused ? false : true;

        player.gamePaused = gamePaused;
        
        pauseUI.SetActive(gamePaused);

        Time.timeScale = gamePaused ? 0 : 1;
    }

    public void ReducirNumEnemigos()
    {
        numEnemies = numEnemies - 1;
        if(numEnemies < 1)
        {
            Ganar();
        }
    }

    void Ganar()
    {
        gameOver = true;
        Time.timeScale = 0;
        player.gamePaused = true;
        gameOverUI.SetActive(true);
    }

    void Ralentizar()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= congelar && cargasDeRalentizador < 3)
        {
            Time.timeScale = 0.5f;

            congelar = Time.time + (TiempoCongelado/2);

            cargasDeRalentizador++;
        }

        if(Time.time >= congelar)
        {
            Time.timeScale = 1;
        }
    }
}
