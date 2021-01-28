using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float _force = 7f;
    [SerializeField]
    private LayerMask _layersToVerify = 0;


    private const float JUMP_DELAY = 0.1f;

    private Rigidbody _entityRigidbody = null;
    private bool _isTouchingGround = true;
    private float _jumpElapsedDelay = 0f;

    private void Awake()
    {
        if (TryGetComponent<Rigidbody>(out _entityRigidbody))
            this.enabled = true;
        else
            this.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        _isTouchingGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isTouchingGround = false;
    }

    private void Update()
    {
        _jumpElapsedDelay += Time.deltaTime;

        if (_jumpElapsedDelay > JUMP_DELAY && _isTouchingGround && Input.GetButtonDown("Jump")) PerformJump();
    }

    private void PerformJump()
    {
        _entityRigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
        _jumpElapsedDelay = 0f;
    }
}
