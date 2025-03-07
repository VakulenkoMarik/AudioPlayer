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

    [SerializeField]
    private Animator characterAnimator;

    private void Awake()
    {
        instance = this;
    }

    private void ActivateRandom()
    {
        int randomIndex = Random.Range(0, patches.Count);
        AudioPatch patch = patches[randomIndex];
        
        background.color = patch.BackgroundColor;
        characterAnimator.SetBool("isDance", true);
        
        panel.SetPatch(patch);
        panel.animator.SetTrigger("Start");
    }

    public void ActivateRandomPatch()
        => instance.ActivateRandom();
}
