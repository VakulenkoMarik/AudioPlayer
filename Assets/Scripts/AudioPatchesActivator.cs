using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// ReSharper disable InconsistentNaming

public class AudioPatchesActivator : MonoBehaviour
{
    public static AudioPatchesActivator Instance;
    
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
    
    [field: SerializeField]
    public Animator CanvasAnimator { get; private set; }
    
    private void Awake()
    {
        Instance = this;
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
        CanvasAnimator.SetBool("NewAudio", true);
    }

    private void ActivateRandom()
    {
        AudioPatch patch = DeterminePatch();
        
        panel.SetPatch(patch);
        panel.Animator.SetTrigger("Start");
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
        => Instance.ActivateRandom();
}
