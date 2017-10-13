using UnityEngine;

public class ThemeChanger : MonoBehaviour
{
    private SpriteRenderer spr;

    [SerializeField]
    private Sprite grasslandSprite;
    [SerializeField]
    private Sprite caveSprite;
    [SerializeField]
    private Sprite cloudSprite;
    [SerializeField]
    private Sprite brightGrasslandSprite;
    [SerializeField]
    private Sprite dirtSprite;
    [SerializeField]
    private Sprite swampSprite;

    private ThemeManager.Themes initialTheme;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        UpdateSprite();
        initialTheme = ThemeManager.instance.theme;
    }

    private void Update()
    {
        if (ThemeManager.instance.theme != initialTheme)
        {
            UpdateSprite();
            initialTheme = ThemeManager.instance.theme;
        }
    }

    private void UpdateSprite()
    {
        switch (ThemeManager.instance.theme)
        {
            case ThemeManager.Themes.BrightGrass:

                spr.sprite = brightGrasslandSprite;

                break;
            case ThemeManager.Themes.Cave:

                spr.sprite = caveSprite;

                break;
            case ThemeManager.Themes.Cloud:

                spr.sprite = cloudSprite;

                break;
            case ThemeManager.Themes.Dirt:

                spr.sprite = dirtSprite;

                break;
            case ThemeManager.Themes.Grass:

                spr.sprite = grasslandSprite;

                break;
            case ThemeManager.Themes.Swamp:

                spr.sprite = swampSprite;

                break;
        }
    }
}
