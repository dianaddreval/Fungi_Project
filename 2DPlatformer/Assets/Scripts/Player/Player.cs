using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 5f;
    private bool _isGround;
    
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb2D;
    [SerializeField] private LayerMask _mask;
    Ray _ray;
    [SerializeField] private float _groundCheckRadius = 0.5f;
    
    public static Player Instance;

    private void Awake() => Instance = this;
    
    void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>(); 
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DrawLine();
    }

    internal void Move(float horizontalInput)
    {
        _rb2D.linearVelocity = new Vector2(horizontalInput * _speed, _rb2D.linearVelocity.y);
        
        if (_rb2D.linearVelocity.x < 0)
        {
            _sprite.flipX = true;
        }
        else if(_rb2D.linearVelocity.x > 0)
        {
            _sprite.flipX = false;
        }
    }

    internal void Jump()
    {
        _isGround = CheckGround();

        if (_isGround)
        {
            _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
        }
    }
    
    public bool CheckGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRadius, _mask);
        return hit.collider != null;
    }

    private void DrawLine()
    {
        Debug.DrawRay(transform.position, Vector2.down * _groundCheckRadius, Color.red);
    }
}
