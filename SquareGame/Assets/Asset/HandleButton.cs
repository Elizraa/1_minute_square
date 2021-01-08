using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleButton : MonoBehaviour
{
    public static bool rightClicked, leftClicked, upClicked, downClicked = false;

    void LateUpdate()
    {
        rightClicked = leftClicked = upClicked = downClicked = false;
    }

    public void RightClicked()
    {
        rightClicked = true;
    }
    public void LeftClicked()
    {
        leftClicked = true;
    }
    public void UpClicked()
    {
        upClicked = true;
    }
    public void DownClicked()
    {
        downClicked = true;
    }
}
