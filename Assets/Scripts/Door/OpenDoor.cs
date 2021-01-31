using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private PickSoul _pickedSoul = null; // reference to soul
    private Player _player = null;

    [SerializeField]
    private bool _opened = false;

    [SerializeField]
    private float _xTeleport = -21f;
    [SerializeField]
    private float _yTeleport = 1f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            _pickedSoul = other.GetComponent<PickSoul>();
            Debug.Assert(_pickedSoul != null, "The player does not have a soul picker");
            if (_pickedSoul.HasSoul)
            {
                _opened = true;
                _pickedSoul.DeliverSoul();
                print("A porta abriu");
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            _player = null;
        }
    }

    private void Awake(){
    }

    private void Update()
    {
        float enterDoor = Input.GetAxis("EnterDoor");

        if(enterDoor > 0f && _opened && _player != null){
            _player.transform.position = new Vector3(_xTeleport,_yTeleport,0f);
        }
    }
}
