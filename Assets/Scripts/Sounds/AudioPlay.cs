using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public static void PlayAudioClip(AudioSource source_, AudioClip clip_)
    {
        source_.clip = clip_;
        source_.Play();
    }

}
