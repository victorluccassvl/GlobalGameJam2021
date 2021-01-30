using UnityEngine;


[RequireComponent(typeof(Player))]
public class Die : MonoBehaviour
{
    private Player _player = null;

    public const float X_spawn = -21f, Y_spawn = 1f, Z_spawn = 0f;

    public void ToDie(){
        _player = GetComponent<Player>();
        _player.transform.position = new Vector3(X_spawn,Y_spawn,Z_spawn);
    }
}



