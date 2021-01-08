using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.state.enableInput)
        {
            if (!StateManager.state.reversedControl) {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || HandleButton.rightClicked) moveRight();
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || HandleButton.leftClicked) moveLeft();
                else if (StateManager.state.spawnFour)
                {
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || HandleButton.upClicked) moveUp();
                    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || HandleButton.downClicked) moveDown();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || HandleButton.rightClicked) moveRight();
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || HandleButton.leftClicked) moveLeft();
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || HandleButton.upClicked) moveUp();
                else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || HandleButton.downClicked) moveDown();
            }
        }
    }

    void moveRight()
    {
        transform.position = new Vector3(transform.position.x+2.35f, transform.position.y, transform.position.z);
        for(int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] += new Vector3(2.35f,0);
        }
        GameManager.gameManager.setCurrent(0);
    }
    void moveLeft()
    {
        transform.position = new Vector3(transform.position.x-2.35f, transform.position.y, transform.position.z);
        for(int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] -= new Vector3(2.35f, 0);
        }
        GameManager.gameManager.setCurrent(1);
    }
    void moveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+1.78f, transform.position.z);
        for (int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] += new Vector3(0, 1.78f);
        }
        GameManager.gameManager.setCurrent(2);
    }
    void moveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y-1.78f, transform.position.z);
        for(int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] -= new Vector3(0, 1.78f);
        }
        GameManager.gameManager.setCurrent(3);
    }
}
