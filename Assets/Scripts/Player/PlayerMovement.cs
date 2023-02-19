using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// speed of the character
    /// </summary>
    [SerializeField] private float speed;
    private readonly int _isDead = Animator.StringToHash("IsDead");

    public bool isMoving => _directionMovement.magnitude > 0f;

    private Rigidbody2D _rigidbody2D;

    /// <summary>
    /// A vector with the direction of the movement
    /// </summary>
    private Vector2 _directionMovement;

    /// <summary>
    /// A vector with the keyboard input
    /// </summary>
    private Vector2 _input;

    //Getter of _directionMovement
    public Vector2 DirectionMovement => _directionMovement;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {

        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    
        // X
        if ( _input.x > 0f)
        {
            _directionMovement.x = 1f;
        }
        else if ( _input.x < 0f)
        {
            _directionMovement.x = -1f;
        }
        else
        {
            _directionMovement.x = 0;
        }
    
        // Y
        if ( _input.y > 0f)
        {
            _directionMovement.y = 1f;
        }
        else if ( _input.y < 0f)
        {
            _directionMovement.y = -1f;
        }
        else
        {
            _directionMovement.y = 0;
        }

    }

    private void FixedUpdate()
    {
        if (!((_directionMovement.x != 0) && (_directionMovement.y != 0)))
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position +
                                      _directionMovement * (speed * Time.fixedDeltaTime));
        }
        else         
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position +
                                      _directionMovement * (speed * Time.fixedDeltaTime * math.SQRT2 / 2));
        }
    }
}

