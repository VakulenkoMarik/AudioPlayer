using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioPanel : MonoBehaviour
{
    [SerializeField]
    private Image logo;
        
    [SerializeField]
    private TextMeshProUGUI title;
    
    [SerializeField]
    private TextMeshProUGUI author;
    
    [field: SerializeField]
    public Animator Animator { get; private set; }
    
    private AudioPatch targetPatch;
    
    public void SetPatch(AudioPatch patch)
        => targetPatch = patch;

    public void ShowData()
    {
        AudioPatchesActivator.Instance.ActivatePatch(targetPatch);
        
        logo.sprite = targetPatch.Logo;

        title.text = targetPatch.Title;
        author.text = targetPatch.Author;
        
        AudioPlayer.Play(targetPatch.Clip);
    }
    
    public void ExitPanelAnimation()
    {
        Animator.SetInteger("ExitVersion", Random.Range(0, 3));
        Animator.SetTrigger("ExitTrigger");
        
        AudioPatchesActivator.Instance.CanvasAnimator.SetBool("NewAudio", false);
    }
}
