using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenuManager : MonoBehaviour {
    [Header("---------- Audio Source ----------")]
    public AudioSource musicAudioSource;

    [Header("---------- Music Tracks ----------")]
    public List<AudioClip> musicTracks;

    int currentMusicTrackIndex = 0;

    public static AudioManager instance;

    private void Start() {
        if (musicTracks.Count > 0) {
            PlayMusic(currentMusicTrackIndex);
        }
    }

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
}
