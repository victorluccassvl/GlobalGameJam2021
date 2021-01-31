using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


[RequireComponent(typeof(Player))]
public class Die : MonoBehaviour
{
    private Player _player = null;

    public static bool isDead = false;

    private void Awake(){
        isDead = false;
    }

    public void ToDie()
    {
        _player = GetComponent<Player>();
        
        if(!isDead){
            _player.PlayPlayerSound(PlaySound.Audios.Die);
            _player.setIsDead(true);
            _player.Animator.SetBool("Died", true);
        }
        isDead = true;
        
        
        StartCoroutine(PlaySource());
    }

    private IEnumerator PlaySource(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



