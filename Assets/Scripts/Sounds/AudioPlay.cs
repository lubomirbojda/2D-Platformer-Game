using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    //Switch clip in given audio source and play it
    public static void PlayAudioClip(AudioSource source_, AudioClip clip_)
    {
        source_.clip = clip_;
        source_.Play();
    }

}
