using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [Header("---------- Audio Source ----------")]
    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    [Header("---------- Music Tracks ----------")]
    public List<AudioClip> musicTracks;

    [Header("---------- Audio Clips ----------")]
    public AudioClip shootingSound;
    public AudioClip deathSound;
    public AudioClip loseSound;

    int currentMusicTrackIndex = -1;

    public static AudioManager instance;

    private void Start() {
        if (musicTracks.Count > 0) {
            PlayMusic(currentMusicTrackIndex);
        }
    }

    private void Update() {
        if (!musicAudioSource.isPlaying && musicTracks.Count > 0) {
            PlayRandomMusic();
        }
    }

    // private void Awake() {
    //     if (instance != null && instance != this) {
    //         Destroy(gameObject);
    //     }
    //     else {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    public void PlayMusic(int trackIndex) {
        if (trackIndex >= 0 && trackIndex < musicTracks.Count) {
            musicAudioSource.clip = musicTracks[trackIndex];
            musicAudioSource.Play();
            currentMusicTrackIndex = trackIndex;
        }
        else {
            // Debug.LogWarning("Track index out of range!");
        }
    }

    public void PlayRandomMusic() {
        if (musicTracks.Count > 1) {
            int randomIndex;
            do {
                randomIndex = Random.Range(0, musicTracks.Count);
            } while (randomIndex == currentMusicTrackIndex);

            currentMusicTrackIndex = randomIndex;
            PlayMusic(randomIndex);
        }
        else if (musicTracks.Count == 1) {
            PlayMusic(0);
        }
    }

    public void PlayNextMusic() {
        currentMusicTrackIndex = (currentMusicTrackIndex + 1) % musicTracks.Count;
        PlayMusic(currentMusicTrackIndex);
    }

    public void PlayPreviousMusic() {
        currentMusicTrackIndex = (currentMusicTrackIndex - 1 + musicTracks.Count) % musicTracks.Count;
        PlayMusic(currentMusicTrackIndex);
    }

    public void playSFX(AudioClip sfx) {
        sfxAudioSource.clip = sfx;
        sfxAudioSource.PlayOneShot(sfx);
    }
}
