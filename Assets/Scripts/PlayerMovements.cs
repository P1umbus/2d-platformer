using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovements : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [Header("GroundCheck")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _whatIsGround;
    [Header("Other")]
    [SerializeField] private float _sensitivityAnimationFall = 1;

    private Animator _animator;
    private Rigidbody2D _rb;

    private float _moveInput;

    private bool _isGrounded;
    private bool _facingRight;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

            _rb.velocity = new Vector2(_moveInput * _speed, _rb.velocity.y);

        if (_rb.velocity == Vector2.zero)
        {
            _animator.Play("Idle");
        }
        else if (_moveInput != 0 && _isGrounded)
        {
            _animator.Play("Walk");
        }
        if (_rb.velocity.y > _sensitivityAnimationFall || _rb.velocity.y < -_sensitivityAnimationFall && _isGrounded)
        {
            _animator.Play("Jump");
        }
    }

    private void FixedUpdate()
    {
        if (_facingRight == false && _moveInput < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            _facingRight = true;
        }
        else if (_facingRight == true && _moveInput > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            _facingRight = false;
        }

        CheckGround();
    }

    private void Jump()
    {
        if (_isGrounded)
            _rb.AddForce(Vector3.up * _jumpForce);
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);
    }
}
