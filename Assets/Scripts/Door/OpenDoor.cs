using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private PickSoul _pickedSoul = null; // reference to soul

    [SerializeField]
    private bool _opened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
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

    private void Update()
    {
        
    }
}
