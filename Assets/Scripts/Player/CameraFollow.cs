using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera _camera = null;

    [SerializeField]
    private Transform _objectToFollow = null;
    [SerializeField]
    private float _heightOffset = 3f;

    private void Awake()
    {
        Debug.Assert(_objectToFollow != null, "Game camera has no object to follow");
        _camera = Camera.main;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 temp;
        temp.x = _objectToFollow.position.x;
        temp.y = _objectToFollow.position.y + _heightOffset;
        temp.z = _camera.transform.position.z;

        _camera.transform.position = temp;
    }
}
