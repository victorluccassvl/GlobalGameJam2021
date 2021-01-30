using UnityEngine;

public class Spike : MonoBehaviour
{
    private Die _die = null; // reference to die component

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _die = other.GetComponent<Die>();
            Debug.Assert(_die != null, "The player does not have a die component");
            print("SPIKE!");
            _die.ToDie();
        }
    }
}
