using System;
using UnityEngine;

public class Star : MonoBehaviour
{
    public static Action<bool> OnStarDoubleJump;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnStarDoubleJump?.Invoke(true);
            gameObject.SetActive(false);
        }
    }
    
}
