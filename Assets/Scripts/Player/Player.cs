using UnityEngine;

public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector = null;
    private WallDetector _wallDetector = null;
    private Animator _animator = null;
    private PlaySound _soundPlayer = null;

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

    public bool IsPlayerTouchingWall
    {
        get => _wallDetector.IsTouchingWall;
    }

    public bool IsPlayerTouchingRightWall
    {
        get => _wallDetector.IsTouchingRightWall;
    }

    public bool IsPlayerTouchingLeftWall
    {
        get => _wallDetector.IsTouchingLeftWall;
    }

    private void Awake()
    {
        _groundDetector = GetComponentInChildren<GroundDetector>();
        Debug.Assert(_groundDetector != null, "The player could not find it's ground detector");

        _wallDetector = GetComponentInChildren<WallDetector>();
        Debug.Assert(_wallDetector != null, "The player could not find it's wall detector");

        _animator = GetComponent<Animator>();
        Debug.Assert(_animator != null, "The player could not find it's animator");

        _soundPlayer = GetComponent<PlaySound>();
        Debug.Assert(_soundPlayer != null, "The player could not find it's sound player");
    }

    private void Update()
    {
        _animator.SetFloat("SidewaysSpeed", _rigidbody.velocity.x);
        _animator.SetBool("IsTouchingGround", IsPlayerOnTheGround);
    }

    public void PlayPlayerSound(PlaySound.Audios audio)
    {
        _soundPlayer.PlaySpecificSound(audio);
    }
}
