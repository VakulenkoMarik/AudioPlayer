using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioPanel : MonoBehaviour
{
    public Image logo;
    
    public TextMeshProUGUI title;
    public TextMeshProUGUI author;
    
    public Animator animator;

    private AudioPatch targetPatch;

    public void SetPatch(AudioPatch patch)
        => targetPatch = patch;

    public void ShowData()
    {
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
