using UnityEngine;

[RequireComponent(typeof(Player))]
public class Jump : MonoBehaviour
{
    private Player _player = null;

    private const float JUMP_DELAY = 0.1f;

    private float _jumpElapsedDelay = 0f;

    [SerializeField]
    private float _force = 7f;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _jumpElapsedDelay += Time.deltaTime;

        if (_jumpElapsedDelay > JUMP_DELAY && _player.IsPlayerOnTheGround && Input.GetButtonDown("Jump"))
            PerformJump();
    }

    private void PerformJump()
    {
        _player.Rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
        _jumpElapsedDelay = 0f;
    }
}
