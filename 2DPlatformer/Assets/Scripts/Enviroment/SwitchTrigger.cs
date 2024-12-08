using System;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    
    public static Action OnDoorOpen;
    
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnDoorOpen?.Invoke();
            gameObject.SetActive(false);
        }
    }

}
