using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    [SerializeField] private GameObject _switchObject;
    
    private void OnEnable()
    {
        SwitchTrigger.OnDoorOpen += isSwitched;
    }

    private void OnDisable()
    {
        SwitchTrigger.OnDoorOpen -= isSwitched;
    }

    private void isSwitched()
    {
        _switchObject.SetActive(true);
    }
    
}
