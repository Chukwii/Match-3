using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPiece : MonoBehaviour
{
    public enum ColorType
    {
        RED,
        YELLOW,
        BLUE,
        PURPLE,
        ORAGNE,
        GREEN,
        PINK,
        ANY,
        COUNT
    };

    [System.Serializable]
    public struct ColorSprite
    {
        public ColorType color;
        public Sprite sprite;
    };

    public ColorSprite[] colorSprite;

    private ColorType color;

    public ColorType Color
    {
        get { return color; }
        set { SetColor (value); }
    }

    public int NumColors
    {
        get { return colorSprite.Length;}
    }

    private SpriteRenderer sprite;
    private Dictionary<ColorType, Sprite> colorSpriteDict;

    private void Awake()
    {
        sprite = transform.Find("piece").GetComponent<SpriteRenderer>();

        colorSpriteDict = new Dictionary<ColorType, Sprite>();

        for(int i = 0; i < colorSprite.Length; i++)
        {
            if (!colorSpriteDict.ContainsKey(colorSprite[i].color))
            {
                colorSpriteDict.Add(colorSprite[i].color, colorSprite[i].sprite);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(ColorType newColor)
    {
        color = newColor;

        if (colorSpriteDict.ContainsKey(newColor))
        {
            sprite.sprite = colorSpriteDict[newColor];
        }
    }
}
