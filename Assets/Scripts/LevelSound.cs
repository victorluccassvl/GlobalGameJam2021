using UnityEngine;
using System.Collections;

public class LevelSound : MonoBehaviour
{
    private AudioSource _source = null;

    void Start()
    {
        _source = GetComponents<AudioSource>()[1];
        Debug.Assert(_source != null, "The sound player could not find it's audio source");
        StartCoroutine(PlaySource(_source));
    }
    private void Awake()
    {
    }

    private IEnumerator PlaySource(AudioSource _source){
        yield return new WaitForSeconds(10.3f);
        _source.Play();
    }
}
