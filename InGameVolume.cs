using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class InGameVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider m_slider;

    private void Start()
    {
        if (m_slider != null) // چک کن که Slider وصل باشه
        {
            m_slider.value = PlayerPrefs.GetFloat("GameVolume", 0f);
        }
    }

    public void SetVolume(float volume)
    {
        if (audioMixer != null) // فقط اگه audioMixer مقدار داشته باشه اجرا می‌شه
        {
            audioMixer.SetFloat("Volume", volume);
        }
        if (m_slider != null) // چک کن که Slider نال نباشه
        {
            PlayerPrefs.SetFloat("GameVolume", m_slider.value);
        }
    }
}