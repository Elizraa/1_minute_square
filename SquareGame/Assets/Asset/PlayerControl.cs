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
        if (Input.GetKeyDown(KeyCode.D)) moveLeft();
        else if(Input.GetKeyDown(KeyCode.A)) moveRight();
    }

    void moveLeft()
    {
        transform.position = new Vector3(transform.position.x+2.35f, transform.position.y, transform.position.z);
    }
    void moveRight()
    {
        transform.position = new Vector3(transform.position.x-2.35f, transform.position.y, transform.position.z);
    }
}
