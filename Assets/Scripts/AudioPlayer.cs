using UnityEngine;
// ReSharper disable InconsistentNaming

public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer instance;
    private AudioSource source;

    void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public static void Play(AudioClip clip)
    {
        Stop();
        instance.source.PlayOneShot(clip);
    }

    public static void Stop()
        => instance.source.Stop();
}
