using UnityEngine;

public class Player : MonoBehaviour
{
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
}
