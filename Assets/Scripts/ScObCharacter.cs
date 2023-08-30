using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class ScObCharacter : ScriptableObject
{
    public string CharacterName;
    
    public int Love = 50;

    public Sprite Idle;
    public Sprite Sad;
    public Sprite Happy;
    public Sprite Angry;
    public Sprite Fear;
}
