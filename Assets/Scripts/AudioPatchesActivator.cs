using System.Collections.Generic;
using TMPro;
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
    private Image background;
    
    [SerializeField]
    private Image logo;
    
    [SerializeField]
    private TextMeshProUGUI title;
    
    [SerializeField]
    private TextMeshProUGUI author;

    private void Awake()
    {
        instance = this;
    }

    private void ActivateRandom()
    {
        int randomIndex = Random.Range(0, patches.Count - 1);
        AudioPatch patch = patches[randomIndex];

        background.color = patch.BackgroundColor;
        logo.sprite = patch.Logo;

        title.text = patch.Title;
        author.text = patch.Author;
        
        AudioPlayer.Play(patch.Clip);
    }

    public static void ActivateRandomPatch()
        => instance.ActivateRandom();
}
