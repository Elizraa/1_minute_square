using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager state;
    public bool spawnFour,spawnCoins,spawnObstacle,reversedControl,reversedDeathCondition, spawnMoreVarians;
    public bool enableInput = true;
    public int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (state == null) state = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
