using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource_;

    public void PlayAudioClip(AudioClip clip_)
    {
        AudioSource_.clip = clip_;
        AudioSource_.Play();
    }

}
