using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TargetGroupDetacher : MonoBehaviour
{

    private CinemachineTargetGroup tG;
    private bool isDetached = false;

   void Start()
    {
        tG = GetComponent<CinemachineTargetGroup>();
    }

    void FixedUpdate()
    {
        if ((GameManager.instance.player1HP <= 0 || GameManager.instance.player2HP <= 0) && !isDetached)
        {
            tG.m_Targets[0].weight = 10;
            tG.m_Targets[0].radius = 1.5f;
            
            tG.m_Targets[1].weight = 10;
            tG.m_Targets[1].radius = 1.5f;
            
            Invoke("DetachMember", 0.1f);
            isDetached = true;
        }
    }

    void DetachMember()
    {
        tG.RemoveMember(tG.m_Targets[0].target);
        tG.RemoveMember(tG.m_Targets[0].target);
        tG.m_Targets[0].radius = 5.5f;
    }
}
