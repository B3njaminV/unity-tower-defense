using UnityEngine;

public class ZombieAttackSong : IAudioState
{
    private AudioManager _audioManager;

    public ZombieAttackSong(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void OnEnterState()
    {
        _audioManager.GetAudioSource().loop = false;
    }

    public void PlaySong()
    {
        Debug.Log("Lancement musique : zattack_soundtrack");
        AudioClip songClip = Resources.Load<AudioClip>("zattack_soundtrack");

        if (songClip != null)
        {
            _audioManager.GetAudioSource().clip = songClip;
            _audioManager.GetAudioSource().Play();
        }
        else
        {
            Debug.LogError("Musique non trouvé : zattack_soundtrack");
        }
    }
}


