using System;
using UnityEngine;

public class NewLevel : MonoBehaviour
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
