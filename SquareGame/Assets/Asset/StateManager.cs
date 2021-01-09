using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager state;
    public bool spawnFour,spawnCoins,spawnObstacle,reversedControl,reversedDeathCondition, nextInputAbleReverse, spawnMoreVarians, startTimer;
    public bool enableInput = true;
    public int score = 0;
    public string swipeDirection;
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
