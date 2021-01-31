using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public enum Audios
    {
        OpenDoor = 0,
        Walking,
        Die,
        Jump,
        WallJump,
        PickSoul
    }

    [SerializeField]
    private AudioClip[] _audios;

    private AudioSource _source = null;

    private void Awake()
    {
        Debug.Assert(_audios.Length == System.Enum.GetNames(typeof(Audios)).Length, "Audios missing");
        _source = GetComponent<AudioSource>();
        Debug.Assert(_source != null, "The sound player could not find it's audio source");
    }

    public void PlaySpecificSound(Audios audio)
    {
        switch (audio)
        {
            case Audios.OpenDoor:
            case Audios.Die:
            case Audios.PickSoul:
            case Audios.Jump:
            case Audios.WallJump:
                if (_source.isPlaying) _source.Stop();
                _source.loop = false;
                _source.clip = _audios[(int) audio];
                _source.Play();
                break;
            case Audios.Walking:
                if (_source.isPlaying && _source.clip != _audios[(int) audio])
                {
                    _source.loop = true;
                    _source.clip = _audios[(int) audio];
                    _source.Play();
                }
                break;
        }
    }
}
