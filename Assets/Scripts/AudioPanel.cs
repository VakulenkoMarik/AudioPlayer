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

    [SerializeField]
    private Image background;

    [SerializeField]
    private Animator characterAnimator;
    
    public Animator animator;
    
    private AudioPatch targetPatch;
    
    public void SetPatch(AudioPatch patch)
        => targetPatch = patch;

    public void ShowData()
    {
        background.color = targetPatch.BackgroundColor;
        characterAnimator.SetBool("isDance", true);
        
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
