using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 3.0f;
    private Vector3 _playerMovementState;
    
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb2D;
    
    void Start()
    {
       _sprite = GetComponentInChildren<SpriteRenderer>(); 
       _rb2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Move();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        _playerMovementState = Vector3.right * Input.GetAxisRaw("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, _playerMovementState + transform.position,
            _speed * Time.deltaTime);
        
        if (_playerMovementState.x < 0)
        {
            _sprite.flipX = true;
        }
        else if(_playerMovementState.x > 0)
        {
            _sprite.flipX = false;
        }
    }

    private void Jump()
    {
            _rb2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse); 
    }
}
