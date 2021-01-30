using UnityEngine;

[RequireComponent(typeof(Player))]
public class WallJump : MonoBehaviour
{
    private Player _player = null;

    private const float WALL_JUMP_DELAY = 0.1f;

    private float _wallJumpElapsedDelay = 0f;

    [SerializeField]
    private float _speed = 9f;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _wallJumpElapsedDelay += Time.deltaTime;

        if (_wallJumpElapsedDelay > WALL_JUMP_DELAY && _player.IsPlayerTouchingWall && !_player.IsPlayerOnTheGround)
        {
            if (Input.GetButton("Jump"))
            {
                if (Input.GetAxis("Move") > 0f && _player.IsPlayerTouchingLeftWall || Input.GetAxis("Move") < 0f && _player.IsPlayerTouchingRightWall)
                    PerformWallJump();
            }
        }
    }

    private void PerformWallJump()
    {
        Vector3 direction = Vector3.up;

        if (_player.IsPlayerTouchingRightWall)
            direction += Vector3.left;
        else
            direction += Vector3.right;
        
        direction.Normalize();

        _player.Rigidbody.AddForce(direction * _speed, ForceMode.VelocityChange);
        _wallJumpElapsedDelay = 0f;
    }
}
