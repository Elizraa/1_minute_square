using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public Vector3[] postitionToSpawn;
    public GameObject[] plateToSpawn;
    public Transform player;
    public GameObject[] reverse;

    private void Start()
    {
        spawnPlate();
    }
    private void LateUpdate()
    {
    }
    public void spawnPlate()
    {
        if (!StateManager.state.spawnFour)
        {
            int firstSpawn = Random.Range(0, 2);
            GameManager.gameManager.plateExits[0] = Instantiate(plateToSpawn[firstSpawn], postitionToSpawn[0], Quaternion.identity);
            GameManager.gameManager.plateExits[1] = Instantiate(plateToSpawn[(firstSpawn+1)%2], postitionToSpawn[1], Quaternion.identity);
        }
        else
        {
            if (!StateManager.state.spawnMoreVarians)
            {
                int[] firstSpawn = { 0, 0, 1, 1 };
                for (int t = 0; t < firstSpawn.Length; t++)
                {
                    int tmp = firstSpawn[t];
                    int r = Random.Range(t, firstSpawn.Length);
                    firstSpawn[t] = firstSpawn[r];
                    firstSpawn[r] = tmp;
                }
                for(int i = 0; i < firstSpawn.Length; i++)
                {
                    GameManager.gameManager.plateExits[i] = Instantiate(plateToSpawn[firstSpawn[i]], postitionToSpawn[i], Quaternion.identity);
                }
            }
            else
            {
                int[] firstSpawn = new int[4];
                if (!StateManager.state.nextInputAbleReverse)
                {
                    int[] temp = { Random.Range(2, 6), Random.Range(2, 6), Random.Range(6, 10), Random.Range(6, 10) };
                    firstSpawn = temp;
                    if (StateManager.state.score > 29) firstSpawn[1] = Random.Range(6, 10);
                }
                else
                {
                    int[] temp = { Random.Range(2, 6), Random.Range(2, 6), Random.Range(2, 6), Random.Range(6, 10) };
                    firstSpawn = temp;
                }
                for (int t = 0; t < firstSpawn.Length; t++)
                {
                    int tmp = firstSpawn[t];
                    int r = Random.Range(t, firstSpawn.Length);
                    firstSpawn[t] = firstSpawn[r];
                    firstSpawn[r] = tmp;
                }
                for (int i = 0; i < firstSpawn.Length; i++)
                {
                    GameManager.gameManager.plateExits[i] = Instantiate(plateToSpawn[firstSpawn[i]], postitionToSpawn[i], Quaternion.identity);
                    if(StateManager.state.spawnObstacle && firstSpawn[i] < 6 && !StateManager.state.reversedDeathCondition)
                    {
                        int itemToSpawn = randomItem();
                        GameObject item = Instantiate(reverse[itemToSpawn], GameManager.gameManager.plateExits[i].transform);
                        if (firstSpawn[i] > 3) item.transform.localPosition = new Vector2(0f, -3f);
                        else item.transform.localPosition = new Vector2(0f, 3f);
                        StateManager.state.spawnObstacle = false;
                    }
                    else if(StateManager.state.spawnObstacle && firstSpawn[i] > 5 && StateManager.state.reversedDeathCondition)
                    {
                        int itemToSpawn = randomItem();
                        GameObject item = Instantiate(reverse[itemToSpawn], GameManager.gameManager.plateExits[i].transform);
                        if (firstSpawn[i] < 8) item.transform.localPosition = new Vector2(0f, -3f);
                        else item.transform.localPosition = new Vector2(0f, 3f);
                        StateManager.state.spawnObstacle = false;
                    }
                }
            }
        }
    }

    int randomItem()
    {
        if (StateManager.state.reversedControl && StateManager.state.reversedDeathCondition)
            return Random.Range(0, 2);
        else if (StateManager.state.reversedControl)
            return 1;
        else if (StateManager.state.reversedDeathCondition)
            return 0;
        else
            return Random.Range(0, 2);
    }
}
