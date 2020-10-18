using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public Sprite Chatphoto;
    public Sprite myphoto;
    public string LevelName;
    public string namegirlorman;
    public string Activenow;
    public string [] MyAnswers;
    public string[] HerAnswers;
    public string winpaneltext;
    public string losepaneltext;
}