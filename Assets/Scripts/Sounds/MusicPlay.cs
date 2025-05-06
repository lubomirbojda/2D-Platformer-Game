using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private AudioSource _audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource.loop = true;
        _audioSource.clip = _musicClip;
        _audioSource.Play();
    }
}
