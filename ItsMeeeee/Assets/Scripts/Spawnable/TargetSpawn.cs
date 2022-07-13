using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    private void OnEnable()
    {
        OnTargetAppearedEvent onTargetAppearedEvent = new OnTargetAppearedEvent();
        onTargetAppearedEvent.FireEvent();
    }
}
