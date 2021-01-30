using UnityEngine;

[RequireComponent(typeof(Player))]
public class Crouch : MonoBehaviour
{
    private Player _player = null;

    private void Update()
    {
        if (_player.IsPlayerOnTheGround && Input.GetButton("Crouch"))
            PerformCrouch();
        else
            CancelCrouch();
    }

    private void PerformCrouch()
    {
        _player.RunAnimation("Crouch");
    } 

    private void CancelCrouch()
    {
        //Reset player animation
        //Switch colliders
    }
}
