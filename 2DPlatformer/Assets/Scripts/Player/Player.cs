using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 5f;
    private bool _isGround;
    private int _jumpCount;
    private bool _isFalling = false;
    
    private Ray _ray;
    [SerializeField] private float _groundCheckRadius = 0.5f;
    
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb2D;
    [SerializeField] private LayerMask _mask;
    
    public static Player Instance;

    private void Awake() => Instance = this;
    
    void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>(); 
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        DrawLine();
        VerticalSpeed();
        CheckGround();
    }

    internal void Move(float value)
    {
        _rb2D.linearVelocity = new Vector2(value * _speed, _rb2D.linearVelocity.y);
        _animator.SetBool("IsRun", Mathf.Abs(_rb2D.linearVelocity.x) > 0.01f);
        _sprite.flipX = value < 0 ? true : false;
        
    }

    internal void Jump()
    {
        _isGround = CheckGround();

        if (_isGround)
        {
            _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
        }
        
        _animator.SetTrigger("Jump");
    }

    private void VerticalSpeed()
    {
        _animator.SetBool("IsFall", _isFalling);
        if (_rb2D.linearVelocity.y < 0)
        {
            _isFalling = true;
        }
    }
    
    public bool CheckGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRadius, _mask);
        
        if (hit.collider != null)
        {
            _isFalling = false;
            return true;
        }
        return false;
    }

    private void DrawLine()
    {
        Debug.DrawRay(transform.position, Vector2.down * _groundCheckRadius, Color.red);
    }
}
