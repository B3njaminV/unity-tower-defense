using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    private AudioManager _audioManager;
    private AudioSource _audioSource;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        _audioManager = new AudioManager(_audioSource);
        PlaySong();
    }

    public void PlaySong()
    {
        if (_audioManager.GetAudioSource().isPlaying)
        {
            _audioManager.GetAudioSource().Stop();
        }

        _audioManager.PlaySong();
    }

    public void SwitchToMainSong()
    {
        _audioManager.SwitchState(new MainSong(_audioManager));
        PlaySong();
    }

    public void SwitchToMenuSong()
    {
        _audioManager.SwitchState(new MenuSong(_audioManager));
        PlaySong();
    }

    public void SwitchToGameOverSong()
    {
        _audioManager.SwitchState(new GameOverSong(_audioManager));
        PlaySong();
    }
}
