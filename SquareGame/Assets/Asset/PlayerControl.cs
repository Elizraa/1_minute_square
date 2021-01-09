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
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || HandleButton.rightClicked || StateManager.state.swipeDirection == "Right") moveRight();
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || HandleButton.leftClicked || StateManager.state.swipeDirection == "Left") moveLeft();
                else if (StateManager.state.spawnFour)
                {
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || HandleButton.upClicked || StateManager.state.swipeDirection == "Up") moveUp();
                    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || HandleButton.downClicked || StateManager.state.swipeDirection == "Down") moveDown();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || HandleButton.rightClicked || StateManager.state.swipeDirection == "Right") moveLeft();
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || HandleButton.leftClicked || StateManager.state.swipeDirection == "Left") moveRight();
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || HandleButton.upClicked || StateManager.state.swipeDirection == "Up") moveDown();
                else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || HandleButton.downClicked || StateManager.state.swipeDirection == "Down") moveUp();
            }
            if (StateManager.state.nextInputAbleReverse)
            {
                StateManager.state.reversedDeathCondition = true;
            }
            else StateManager.state.reversedDeathCondition = false;

        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            if (Input.GetKeyDown(KeyCode.Space)) GameManager.gameManager.retryGame();
        }
    }

    void moveRight()
    {
        StateManager.state.swipeDirection = "";
        particle.transform.localRotation = Quaternion.Euler(0, 0, -272.28f);
        particle.transform.localPosition = new Vector2(-0.44f, -0.41f);
        particleSystem.Play();
        transform.position = new Vector3(transform.position.x+2.2f, transform.position.y, transform.position.z);
        for(int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] += new Vector3(2.2f,0);
        }
        GameManager.gameManager.setCurrent(0);
    }
    void moveLeft()
    {
        StateManager.state.swipeDirection = "";
        particle.transform.localRotation = Quaternion.Euler(0, 0, 357.36f);
        particle.transform.localPosition = new Vector2(0.44f, -0.41f);
        particleSystem.Play();
        transform.position = new Vector3(transform.position.x-2.2f, transform.position.y, transform.position.z);
        for(int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] -= new Vector3(2.2f, 0);
        }
        GameManager.gameManager.setCurrent(1);
    }
    void moveUp()
    {
        StateManager.state.swipeDirection = "";
        particle.transform.localRotation = Quaternion.Euler(0, 92, -482.7f);
        particle.transform.localPosition = new Vector2(0f, -0.41f);
        particleSystem.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z);
        for (int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] += new Vector3(0, 1.5f);
        }
        GameManager.gameManager.setCurrent(2);
    }
    void moveDown()
    {
        StateManager.state.swipeDirection = "";
        particle.transform.localRotation = Quaternion.Euler(0, 92, -482.7f);
        particle.transform.localPosition = new Vector2(0f, -0.41f);
        particleSystem.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y-1.5f, transform.position.z);
        for(int i = 0; i < 4; i++)
        {
            GameManager.gameManager.plateSpawner.postitionToSpawn[i] -= new Vector3(0, 1.5f);
        }
        GameManager.gameManager.setCurrent(3);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.name == "ReverseControl(Clone)") StateManager.state.reversedControl = !StateManager.state.reversedControl;
        else if (col.transform.name == "ReverseDeath(Clone)") StateManager.state.nextInputAbleReverse = !StateManager.state.nextInputAbleReverse;
        particle.transform.localRotation = Quaternion.Euler(0f, 90.67f, -632.9f);
        particle.transform.localPosition = Vector2.zero;
        particleSystem.Play();
        Destroy(col.gameObject);
    }
}
