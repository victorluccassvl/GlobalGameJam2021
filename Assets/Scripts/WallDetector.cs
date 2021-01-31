using UnityEngine;

public class WallDetector : MonoBehaviour
{
    private bool _isTouchingLeftWall = false;
    private bool _isTouchingRightWall = false;

    public bool IsTouchingLeftWall
    {
        get => _isTouchingLeftWall;
    }
    public bool IsTouchingRightWall
    {
        get => _isTouchingRightWall;
    }
    public bool IsTouchingWall
    {
        get => IsTouchingLeftWall || IsTouchingRightWall;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.position.x > transform.position.x)
            _isTouchingRightWall = true;
        else
            _isTouchingLeftWall = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.position.x > transform.position.x)
            _isTouchingRightWall = false;
        else
            _isTouchingLeftWall = false;
    }
}
