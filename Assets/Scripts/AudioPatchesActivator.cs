using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// ReSharper disable InconsistentNaming

public class AudioPatchesActivator : MonoBehaviour
{
    private static AudioPatchesActivator instance;
    
    [SerializeField]
    private List<AudioPatch> patches;
    private List<AudioPatch> activePatches = new();

    [SerializeField]
    private AudioPanel panel;
    
    [SerializeField]
    private Image background;

    [SerializeField]
    private Animator characterAnimator;
    
    [SerializeField]
    private Animator lightAnimator;
    
    private void Awake()
    {
        instance = this;
    }

    public void Pause()
    {
        characterAnimator.SetBool("isDance", false);
        lightAnimator.SetBool("isDance", false);
        AudioPlayer.Stop();
    }

    public void ActivatePatch(AudioPatch targetPatch)
    {
        background.color = targetPatch.BackgroundColor;
        characterAnimator.SetBool("isDance", true);
        lightAnimator.SetBool("isDance", true);
    }

    public static void ActivatePatchObjects(AudioPatch patch)
        => instance.ActivatePatch(patch);

    private void ActivateRandom()
    {
        AudioPatch patch = DeterminePatch();
        
        panel.SetPatch(patch);
        panel.animator.SetTrigger("Start");
    }

    private AudioPatch DeterminePatch()
    {
        if (activePatches.Count <= 0)
            activePatches = patches.ToList();
        
        int randomIndex = Random.Range(0, activePatches.Count);
        AudioPatch patch = activePatches[randomIndex];

        activePatches.RemoveSwapBack(patch);

        return patch;
    }

    public void ActivateRandomPatch()
        => instance.ActivateRandom();
}
