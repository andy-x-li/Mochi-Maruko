using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
    private AudioSource AudioSource;

    public GameObject ObjectMusic;

    public Slider volumeSlider;

    public string tag;

    private float MusicVolume = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        ObjectMusic = GameObject.FindWithTag(tag);
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    }

    // Update is called once per frame
    private void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void updateVolume(float volume)
    {
        MusicVolume = volume;
    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 1;
        volumeSlider.value = 1;
    }
}
