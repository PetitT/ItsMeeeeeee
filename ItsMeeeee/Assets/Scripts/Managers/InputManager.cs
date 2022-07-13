using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputManager : IUpdatable
{
    Camera cam;
    bool canEnterInput;

    public InputManager()
    {
        cam = Camera.main;
        canEnterInput = true;
        OnRoundEndEvent.RegisterListener(OnRoundEnd);
        OnRoundBeginEvent.RegisterListener(OnRoundBegin);
    }

    private void OnRoundBegin(OnRoundBeginEvent info)
    {
        canEnterInput = true;
    }

    private void OnRoundEnd(OnRoundEndEvent info)
    {
        canEnterInput = false;
    }

    public void Update()
    {
        if (canEnterInput)
        {
            GetInput();
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnClickedEvent onClickedEvent = new OnClickedEvent();

            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (!hit)
            {
                onClickedEvent.target = TargetType.Nothing;
            }
            else if (hit.collider.TryGetComponent(out TargetSpawn target))
            {
                onClickedEvent.target = TargetType.Target;
            }
            else
            {
                onClickedEvent.target = TargetType.Decoy;
            }

            onClickedEvent.FireEvent();
            canEnterInput = false;
        }
    }
}
