using LowTeeGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChar : MonoBehaviour
{
    public List<Sprite> sprites;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.sprite = sprites.GetRandom();
    }
}
