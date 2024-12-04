using UnityEngine;

public class SwitchLeft : MonoBehaviour
{
    private void OnEnable()
    {
        NewLevel.OnDoorOpen += isSwitched;
    }

    private void OnDisable()
    {
        NewLevel.OnDoorOpen -= isSwitched;
    }

    private void isSwitched()
    {
        gameObject.SetActive(true);
        Debug.Log("Switched");
    }
    
}
