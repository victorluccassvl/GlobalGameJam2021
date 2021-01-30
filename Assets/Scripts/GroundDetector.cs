using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private bool _isTouchingGround = true;
    public bool IsTouchingGround
    {
        get => _isTouchingGround;
    }

    private void OnTriggerStay(Collider other)
    {
        _isTouchingGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isTouchingGround = false;
    }
}
