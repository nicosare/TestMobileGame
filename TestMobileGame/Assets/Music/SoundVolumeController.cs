using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeController : MonoBehaviour
{
    [SerializeField] GameObject audio;
    AudioSource audioSource;
    [SerializeField] Slider slider;
    [SerializeField] Text volumeText;
    float volume;
    GameObject sound;

    private void Awake()
    {
        sound = GameObject.FindGameObjectWithTag("Sound");
        if (sound == null)
        {
            audio = Instantiate(audio);
            audio.name = "BackgroundMusic";
            DontDestroyOnLoad(audio);
        }
        else
            audio = GameObject.Find("BackgroundMusic");
        if (!PlayerPrefs.HasKey("Volume"))
        {
            volume = .3f;
            slider.value = .3f;
            volumeText.text = "ÇÂÓÊ: 30%";
        }
        else
        {
            volume = PlayerPrefs.GetFloat("Volume");
            slider.value = PlayerPrefs.GetFloat("Volume");
            volumeText.text = "ÇÂÓÊ: " + PlayerPrefs.GetFloat("Volume") + "%";
        }
    }

    private void Start()
    {
        audioSource = audio.GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSource.volume = volume;
        volumeText.text = "ÇÂÓÊ: " + Mathf.RoundToInt(volume * 100) + "%";
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        PlayerPrefs.SetFloat("Volume", newVolume);
    }
}
