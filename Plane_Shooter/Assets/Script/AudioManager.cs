using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    public List<AudioClip> musicTracks; 
    public AudioClip shootingSound;
    public AudioClip deathSound;
    public AudioClip loseSound;

    int currentMusicTrackIndex = -1;

    private void Start() {
        if (musicTracks.Count > 0) {
            PlayMusic(currentMusicTrackIndex); // Phát bài nhạc đầu tiên
        }
    }

    private void Update() {
        // Tự động chuyển bài nhạc khi bài hiện tại kết thúc
        if (!musicAudioSource.isPlaying && musicTracks.Count > 0) {
            PlayRandomMusic();
        }
    }

    public void PlayMusic(int trackIndex) {
        if (trackIndex >= 0 && trackIndex < musicTracks.Count) {
            musicAudioSource.clip = musicTracks[trackIndex];
            musicAudioSource.Play();
            currentMusicTrackIndex = trackIndex;
        } else {
            Debug.LogWarning("Track index out of range!");
        }
    }
    
    public void PlayRandomMusic() {
        if (musicTracks.Count > 1) {
            int randomIndex;
            do {
                randomIndex = Random.Range(0, musicTracks.Count);
            } while (randomIndex == currentMusicTrackIndex); // Đảm bảo không phát lại bài vừa phát

            currentMusicTrackIndex = randomIndex;
            PlayMusic(randomIndex);
        } else if (musicTracks.Count == 1) {
            PlayMusic(0); // Nếu chỉ có một bài nhạc, phát bài đó
        }
    }

    public void PlayNextMusic() {
        currentMusicTrackIndex = (currentMusicTrackIndex + 1) % musicTracks.Count; // Chuyển bài kế tiếp, vòng lặp khi hết danh sách
        PlayMusic(currentMusicTrackIndex);
    }

    public void PlayPreviousMusic() {
        currentMusicTrackIndex = (currentMusicTrackIndex - 1 + musicTracks.Count) % musicTracks.Count; // Chuyển bài trước đó
        PlayMusic(currentMusicTrackIndex);
    }

    public void playSFX(AudioClip sfx) {
        sfxAudioSource.clip = sfx;
        sfxAudioSource.PlayOneShot(sfx);
    }
}
