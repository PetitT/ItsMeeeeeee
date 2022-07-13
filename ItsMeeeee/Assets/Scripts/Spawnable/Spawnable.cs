using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawnable : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localScale = Vector2.zero;
        Sequence s = DOTween.Sequence();

        s.Append(transform.DOScale(1.25f, 0.25f));
        s.Append(transform.DOScale(0.9f, 0.1f));
        s.Append(transform.DOScale(1f, 0.1f));
        s.Play();
    }
}
