using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    private void OnEnable()
    {
        SwitchTrigger.OnDoorOpen += isDoorOpen;
    }

    private void OnDisable()
    {
        SwitchTrigger.OnDoorOpen -= isDoorOpen;
    }

    private void isDoorOpen()
    {
        gameObject.SetActive(false);
    }
    
}
