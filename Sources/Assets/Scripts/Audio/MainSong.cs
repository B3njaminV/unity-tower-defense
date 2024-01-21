using UnityEngine;

public class MainSong : IAudioState
{
    private AudioManager _audioManager;

    public MainSong(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void OnEnterState()
    {
        _audioManager.GetAudioSource().loop = true;
    }

    public void PlaySong()
    {
        AudioClip songClip = Resources.Load<AudioClip>("main_soundtrack");

        if (songClip != null)
        {
            _audioManager.GetAudioSource().clip = songClip;
            _audioManager.GetAudioSource().Play();
        }
        else
        {
            Debug.LogError("Musique non trouvé : main_soundtrack");
        }
    }
}

