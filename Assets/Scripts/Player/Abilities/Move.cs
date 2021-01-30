using UnityEngine;

[RequireComponent(typeof(Player))]
public class Move : MonoBehaviour
{
    private Player _player = null;

    [SerializeField]
    private float _speed = 0.1f;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        float movementDirection = Input.GetAxis("Move");

        if (movementDirection != 0f)
            PerformMovement(movementDirection);
    }

    private void PerformMovement(float movementDirection)
    {
        _player.Rigidbody.MovePosition(_player.Rigidbody.transform.position + Vector3.right * _speed * movementDirection);
    }
}
