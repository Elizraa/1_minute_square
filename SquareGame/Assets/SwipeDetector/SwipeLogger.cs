using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        StateManager.state.swipeDirection = data.Direction.ToString();
        Debug.Log(StateManager.state.swipeDirection + "1");
    }
}