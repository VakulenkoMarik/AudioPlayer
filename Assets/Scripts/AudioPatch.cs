using UnityEngine;

[CreateAssetMenu(fileName = "New audio patch", menuName = "Audio patches/Standart patch")]
public class AudioPatch : ScriptableObject
{
    public  string Title;
    public string Author;
    public AudioClip Clip;
    public Color BackgroundColor;
    public Sprite Logo;
}
