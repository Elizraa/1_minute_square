using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject particle;
    ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = particle.GetComponent<ParticleSystem>();
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
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || HandleButton.rightClicked) moveLeft();
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || HandleButton.leftClicked) moveRight();
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || HandleButton.upClicked) moveDown();
                else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || HandleButton.downClicked) moveUp();
            }
            if (StateManager.state.nextInputAbleReverse)
            {
                StateManager.state.nextInputAbleReverse = false;
                Debug.Log(GameManager.gameManager.currentPlate.tag);
                StateManager.state.reversedDeathCondition = true;
            }

        }
    }

    void moveRight()
    {
        particle.transform.localRotation = Quaternion.Euler(0, 0, -272.28f);
        particle.transform.localPosition = new Vector2(-0.44f, -0.41f);
        particleSystem.Play();
        transform.position = new Vector3(transform.position.x+2.35f, transform.position.y, transform.position.z);
        for(int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] += new Vector3(2.35f,0);
        }
        GameManager.gameManager.setCurrent(0);
    }
    void moveLeft()
    {
        particle.transform.localRotation = Quaternion.Euler(0, 0, 357.36f);
        particle.transform.localPosition = new Vector2(0.44f, -0.41f);
        particleSystem.Play();
        transform.position = new Vector3(transform.position.x-2.35f, transform.position.y, transform.position.z);
        for(int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] -= new Vector3(2.35f, 0);
        }
        GameManager.gameManager.setCurrent(1);
    }
    void moveUp()
    {
        particle.transform.localRotation = Quaternion.Euler(0, 92, -482.7f);
        particle.transform.localPosition = new Vector2(0f, -0.41f);
        particleSystem.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y+1.78f, transform.position.z);
        for (int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] += new Vector3(0, 1.78f);
        }
        GameManager.gameManager.setCurrent(2);
    }
    void moveDown()
    {
        particle.transform.localRotation = Quaternion.Euler(0, 92, -482.7f);
        particle.transform.localPosition = new Vector2(0f, -0.41f);
        particleSystem.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y-1.78f, transform.position.z);
        for(int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] -= new Vector3(0, 1.78f);
        }
        GameManager.gameManager.setCurrent(3);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.name == "ReverseControl(Clone)") StateManager.state.reversedControl = true;
        else if (col.transform.name == "ReverseDeath(Clone)") StateManager.state.nextInputAbleReverse = true;
        Destroy(col.gameObject);
    }
}
