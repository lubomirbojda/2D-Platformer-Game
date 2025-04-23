using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider VolumeSlider_;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            LoadVolumeFromPlayerPrefs();
        }
        else
        {
            LoadVolumeFromPlayerPrefs();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider_.value;
        SaveVolumeToPlayerPrefs();
    }

    private void LoadVolumeFromPlayerPrefs()
    {
        VolumeSlider_.value = PlayerPrefs.GetFloat("Volume");
    }

    private void SaveVolumeToPlayerPrefs()
    {
        PlayerPrefs.SetFloat("Volume", VolumeSlider_.value);
    }

}
