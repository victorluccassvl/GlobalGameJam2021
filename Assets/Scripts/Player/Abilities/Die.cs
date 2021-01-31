using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Player))]
public class Die : MonoBehaviour
{
    // private Player _player = null;

    // [SerializeField]
    // private Transform _spawn = null;

    public void ToDie()
    {
        // _player = GetComponent<Player>(); // old telepor plpayer when dies
        // _player.PlayPlayerSound(PlaySound.Audios.Die);
        // _player.transform.position = _spawn.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



