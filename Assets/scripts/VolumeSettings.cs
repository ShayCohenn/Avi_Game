using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    void Start()
    {
        // Optional: Set slider value to current mixer volume on start
        if (myMixer.GetFloat("MusicVolume", out float volume))
        {
            // Convert from decibels back to a 0-1 slider value
            musicSlider.value = Mathf.Pow(10, volume / 20);
        }

        // Listen for slider changes
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetMusicVolume(float value)
    {
        // Convert the 0.0001 to 1 slider value into decibels (-80dB to 0dB)
        float dbVolume = Mathf.Log10(value) * 20;
        myMixer.SetFloat("MusicVolume", dbVolume);
    }
}