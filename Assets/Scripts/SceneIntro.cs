using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class IntroVideoHandler : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioMixer mixer; // Ajoute une référence à ton AudioMixer

    void Start()
    {
        MuteBackgroundMusic(); // Coupe la musique
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void MuteBackgroundMusic()
    {
        mixer.SetFloat("MusicVolume", -80f); // Coupe la musique
    }

    void RestoreBackgroundMusic()
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(GameHandler.volumeLevel) * 20); // Rétablit le volume
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        RestoreBackgroundMusic();
        SceneManager.LoadScene("SceneGrenier");
    }
}
