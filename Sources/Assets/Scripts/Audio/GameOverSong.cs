using UnityEngine;

public class GameOverSong : IAudioState
{
    private AudioManager _audioManager;

    public GameOverSong(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void OnEnterState()
    {
        _audioManager.GetAudioSource().loop = true;
    }

    public void PlaySong()
    {
        Debug.Log("Lancement musique : gameover_soundtrack");
        AudioClip songClip = Resources.Load<AudioClip>("gameover_soundtrack");

        if (songClip != null)
        {
            _audioManager.GetAudioSource().clip = songClip;
            _audioManager.GetAudioSource().Play();
        }
        else
        {
            Debug.LogError("Musique non trouvé : gameover_soundtrack");
        }
    }
}


