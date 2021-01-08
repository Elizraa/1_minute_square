using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public Vector3[] postitionToSpawn;
    public GameObject[] plateToSpawn;
    public Transform player;

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
                int[] firstSpawn = { Random.Range(2,6), Random.Range(2, 6), Random.Range(6, 10), Random.Range(6, 10) };
                if (StateManager.state.score > 30) firstSpawn[1] = Random.Range(6, 10);
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
                }
            }
        }
    }
}
