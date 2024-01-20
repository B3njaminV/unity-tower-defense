using UnityEngine;

public class MenuSong : IAudioState
{
    private AudioManager _audioManager;

    public MenuSong(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void OnEnterState()
    {
        _audioManager.GetAudioSource().loop = true;
    }

    public void PlaySong()
    {
        Debug.Log("Lancement musique : menu_soundtrack");
        AudioClip songClip = Resources.Load<AudioClip>("menu_soundtrack");

        if (songClip != null)
        {
            _audioManager.GetAudioSource().clip = songClip;
            _audioManager.GetAudioSource().Play();
        }
        else
        {
            Debug.LogError("Musique non trouvé : menu_soundtrack");
        }
    }
}


