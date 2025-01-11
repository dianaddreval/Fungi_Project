using UnityEngine;

public class BoltMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _rigidbody.linearVelocity = transform.up * _speed;
    }
}
