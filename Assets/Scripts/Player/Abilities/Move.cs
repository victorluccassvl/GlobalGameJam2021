using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.1f;

    private Rigidbody _entityRigidbody = null;

    private void Awake()
    {
        this.enabled = TryGetComponent<Rigidbody>(out _entityRigidbody);
    }

    private void FixedUpdate()
    {
        float movementDirection = Input.GetAxis("Move");
        if (movementDirection != 0f) PerformMovement(movementDirection);
    }

    private void PerformMovement(float movementDirection)
    {
        _entityRigidbody.MovePosition(_entityRigidbody.transform.position + Vector3.right * _speed * movementDirection);
    }
}
