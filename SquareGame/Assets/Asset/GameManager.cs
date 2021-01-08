using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public PlateSpawner plateSpawner;
    [HideInInspector]
    public GameObject[] plateExits = new GameObject[4];
    public GameObject currentPlate;
    public Text scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameManager == null) gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
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
            StateManager.state.enableInput = false;
            return;
        }
        else if (StateManager.state.reversedDeathCondition && GameManager.gameManager.plateExits[current].CompareTag("WhiteUp"))
        {
            StateManager.state.enableInput = false;
            return;
        }
        
        scoreText.text = (++StateManager.state.score).ToString();
        if (StateManager.state.score == 9) StateManager.state.spawnFour = true;
        else if (StateManager.state.score == 19) StateManager.state.spawnMoreVarians = true;
    }
}
