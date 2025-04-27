using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;

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
        AudioListener.volume = _volumeSlider.value;
        SaveVolumeToPlayerPrefs();
    }

    private void LoadVolumeFromPlayerPrefs()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    private void SaveVolumeToPlayerPrefs()
    {
        PlayerPrefs.SetFloat("Volume", _volumeSlider.value);
    }

}
