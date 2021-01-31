using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private PickSoul _pickedSoul = null; // reference to soul
    private Player _player = null;

    private const float DOOR_COOLDOWN = 2f;

    private static float _doorElapsedCooldown = 0f;

    [SerializeField]
    private bool _opened = false;
    [SerializeField]
    private Transform _portFront = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            _pickedSoul = other.GetComponent<PickSoul>();
            Debug.Assert(_pickedSoul != null, "The player does not have a soul picker");
            if (_pickedSoul.HasSoul && !_opened)
            {
                _opened = true;
                _pickedSoul.DeliverSoul();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = null;
        }
    }


    private void Update()
    {
        float enterDoor = Input.GetAxis("EnterDoor");

        _doorElapsedCooldown += Time.deltaTime;

        if(enterDoor > 0f && _opened && _player != null && _doorElapsedCooldown > DOOR_COOLDOWN)
        {
            _doorElapsedCooldown = 0f;
            _player.transform.position = _portFront.position;
        }
    }
}
