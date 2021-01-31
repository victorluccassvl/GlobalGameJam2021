using UnityEngine;

[RequireComponent(typeof(Player))]
public class Move : MonoBehaviour
{
    private Player _player = null;

    [SerializeField]
    private float _speed = 3f;
    private bool _isMovingToRight = true;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        float movementDirection = Input.GetAxis("Move");

        if (_player.IsPlayerTouchingWall && !_player.IsPlayerOnTheGround)
            movementDirection = 0f;

        if (movementDirection > 0f && !_isMovingToRight)
        {
            _isMovingToRight = true;
            _player.transform.Rotate(Vector3.up, 180f);
        }
        else if (movementDirection < 0f && _isMovingToRight)
        {
            _isMovingToRight = false;
            _player.transform.Rotate(Vector3.up, 180f);
        }

        PerformMovement(movementDirection);
    }

    private void FixedUpdate()
    {
        DampSpeed();
    }

    private void PerformMovement(float movementDirection)
    {
        _player.Rigidbody.AddForce(Vector3.right * movementDirection * _speed, ForceMode.VelocityChange);
    }

    private void DampSpeed()
    {
        float signal = (_player.Rigidbody.velocity.x > 0f)? 1f : -1f;

        if (Mathf.Abs(_player.Rigidbody.velocity.x) > _speed)
            _player.Rigidbody.velocity = new Vector3(_speed * signal, _player.Rigidbody.velocity.y, 0f);
    }
}
