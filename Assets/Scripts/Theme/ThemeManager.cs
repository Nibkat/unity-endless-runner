using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager instance;

    public enum Themes { BrightGrass, Cave, Cloud, Dirt, Grass, Swamp };
    public Themes theme;

    [SerializeField]
    private bool randomizeTheme = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (randomizeTheme)
        {
            theme = (Themes)Random.Range(0, System.Enum.GetNames(typeof(Themes)).Length);
        }
    }
}
