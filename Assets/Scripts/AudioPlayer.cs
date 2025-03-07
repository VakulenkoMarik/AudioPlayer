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
        instance.source.clip = clip;
        instance.source.Play();
    }

    public static void Stop()
        => instance.source.Stop();
}
