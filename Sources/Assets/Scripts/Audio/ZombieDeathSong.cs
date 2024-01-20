using UnityEngine;

public class ZombieDeathSong : IAudioState
{
    private AudioManager _audioManager;

    public ZombieDeathSong(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void OnEnterState()
    {
        _audioManager.GetAudioSource().loop = false;
    }

    public void PlaySong()
    {
        Debug.Log("Lancement musique : zdeath_soundtrack");
        AudioClip songClip = Resources.Load<AudioClip>("zdeath_soundtrack");

        if (songClip != null)
        {
            _audioManager.GetAudioSource().clip = songClip;
            _audioManager.GetAudioSource().Play();
        }
        else
        {
            Debug.LogError("Musique non trouvé : zdeath_soundtrack");
        }
    }
}


