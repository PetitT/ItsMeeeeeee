using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SolarFlare : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localScale = Vector2.zero;
        Sequence s = DOTween.Sequence();

        StartCoroutine(DelayedDeactivate());
        s.Append(transform.DOScale(1.25f, 0.25f));
        s.Append(transform.DOScale(0.9f, 0.1f));
        s.Append(transform.DOScale(1f, 0.1f));
        s.AppendInterval(0.75f);
        s.Append(transform.DOScale(0f, 0.25f));
        s.Play();
    }

    private IEnumerator DelayedDeactivate()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
