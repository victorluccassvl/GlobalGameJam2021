using UnityEngine;

public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector = null;
    private Animator _animator = null;

    [SerializeField]
    private Rigidbody _rigidbody = null;

    public Rigidbody Rigidbody
    {
        get
        {
            Debug.Assert(_rigidbody != null, "Rigidbody nulo no player");
            return _rigidbody;
        }
    }

    public bool IsPlayerOnTheGround
    {
         get => _groundDetector.IsTouchingGround;
    }

    private void Awake()
    {
        _groundDetector = GetComponentInChildren<GroundDetector>();
        Debug.Assert(_groundDetector != null, "The player could not find it's ground detector");

        _animator = GetComponent<Animator>();
        Debug.Assert(_animator != null, "The player could not find it's animator");
    }

    public void RunAnimation(string animationName)
    {
        //TODO
    }
}
