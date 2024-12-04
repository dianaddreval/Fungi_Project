using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    private void OnEnable()
    {
        NewLevel.OnDoorOpen += isDoorOpen;
    }

    private void OnDisable()
    {
        NewLevel.OnDoorOpen -= isDoorOpen;
    }

    private void isDoorOpen()
    {
        gameObject.SetActive(false);
    }
    
}
