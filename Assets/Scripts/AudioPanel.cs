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
    
    public Animator animator;
    
    private AudioPatch targetPatch;
    
    public void SetPatch(AudioPatch patch)
        => targetPatch = patch;

    public void ShowData()
    {
        AudioPatchesActivator.ActivatePatchObjects(targetPatch);
        
        logo.sprite = targetPatch.Logo;

        title.text = targetPatch.Title;
        author.text = targetPatch.Author;
        
        AudioPlayer.Play(targetPatch.Clip);
    }
    
    public void ExitPanelAnimation()
    {
        animator.SetInteger("ExitVersion", Random.Range(0, 3));
        animator.SetTrigger("ExitTrigger");
    }
}
