using UnityEngine;

public class AudioManager
{
    private AudioSource _source;
    private IAudioState _currentAudio;

    public AudioManager(AudioSource source)
    {
        _source = source;
        SwitchState(new MenuSong(this));    // Par défaut à l'entrée du jeu, on switch sur l'état MenuSong
    }

    public void SwitchState(IAudioState newState)
    {
        _currentAudio = newState;
        _currentAudio.OnEnterState();
    }

    public void PlaySong()
    {
        _currentAudio.PlaySong();
    }

    public AudioSource GetAudioSource()
    {
        return _source;
    }
}

