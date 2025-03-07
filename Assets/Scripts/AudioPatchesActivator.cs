using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// ReSharper disable InconsistentNaming

public class AudioPatchesActivator : MonoBehaviour
{
    private static AudioPatchesActivator instance;
    
    [SerializeField]
    private List<AudioPatch> patches;

    [SerializeField]
    private AudioPanel panel;
    
    [SerializeField]
    private Image background;

    private void Awake()
    {
        instance = this;
    }

    private void ActivateRandom()
    {
        int randomIndex = Random.Range(0, patches.Count);
        AudioPatch patch = patches[randomIndex];

        SetDataFromPatch(patch);
        
        panel.animator.SetTrigger("Start");
        AudioPlayer.Play(patch.Clip);
    }

    private void SetDataFromPatch(AudioPatch patch)
    {
        background.color = patch.BackgroundColor;
        panel.logo.sprite = patch.Logo;

        panel.title.text = patch.Title;
        panel.author.text = patch.Author;
    }

    public void ActivateRandomPatch()
        => instance.ActivateRandom();
}
