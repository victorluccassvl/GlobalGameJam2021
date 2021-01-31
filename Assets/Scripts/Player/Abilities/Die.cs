using UnityEngine;


[RequireComponent(typeof(Player))]
public class Die : MonoBehaviour
{
    private Player _player = null;

    [SerializeField]
    private Transform _spawn = null;

    public void ToDie()
    {
        _player = GetComponent<Player>();
        _player.PlayPlayerSound(PlaySound.Audios.Die);
        _player.transform.position = _spawn.position;
    }
}



