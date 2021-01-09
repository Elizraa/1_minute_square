using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public PlateSpawner plateSpawner;
    [HideInInspector]
    public GameObject[] plateExits = new GameObject[4];
    public GameObject currentPlate, infoCanvas, retryCanvas, liveText, loseText;
    public Text scoreText, finalScore, highScore;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameManager == null) gameManager = this;
        retryCanvas.SetActive(false);
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey("highScore"))
            PlayerPrefs.SetInt("highScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(StateManager.state.score == 1)
        {
            Destroy(liveText);
            Destroy(loseText);
            Destroy(infoCanvas);
        }

        if (!StateManager.state.enableInput)
        {
            if (StateManager.state.score > PlayerPrefs.GetInt("highScore")){
                PlayerPrefs.SetInt("highScore", StateManager.state.score);
            }
            finalScore.text = "Final Score: "+ StateManager.state.score.ToString();
            highScore.text = "Your Highscore: " + PlayerPrefs.GetInt("highScore").ToString();
        }
    }

    public void setCurrent(int current)
    {
        cekDeath(current);
        if (!StateManager.state.enableInput) return;
        Destroy(currentPlate);
        currentPlate = plateExits[current];
        currentPlate.name = "currentPlate";
        for(int i = 0; i < 4; i++)
        {
            if (!(plateExits[i] == currentPlate))
            {
                Destroy(plateExits[i]);
            }
        }
        plateSpawner.spawnPlate();
    }
    public void cekDeath(int current)
    {
        if (!StateManager.state.reversedDeathCondition && GameManager.gameManager.plateExits[current].CompareTag("BlackUp"))
        {
            loseGame();
            return;
        }
        else if (StateManager.state.reversedDeathCondition && GameManager.gameManager.plateExits[current].CompareTag("WhiteUp"))
        {
            loseGame();
            return;
        }
        scoreText.text = (++StateManager.state.score).ToString();
        if (StateManager.state.score == 10) StateManager.state.spawnFour = true;
        else if (StateManager.state.score == 20) StateManager.state.spawnMoreVarians = true;
        else if (StateManager.state.score == 30 || StateManager.state.score == 40|| StateManager.state.score == 50|| StateManager.state.score == 60) 
            StateManager.state.spawnObstacle = true;
    }
    public void loseGame()
    {
        StateManager.state.startTimer = false;
        StateManager.state.enableInput = false;
        retryCanvas.SetActive(true);
    }
    public void retryGame()
    {
        SceneManager.LoadScene(0);
    }
}
