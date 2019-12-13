using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-12-PM-6-16
// 작성자   : 배형영
// 간단설명 : StateMachine 인자값 전달용 클래스

public class OnStateInfo
{
    public Animator Animator { get; private set; }
    public AnimatorStateInfo StateInfo { get; private set; }
    public int LayerIndex { get; private set; }

    public OnStateInfo(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Animator = animator;
        StateInfo = stateInfo;
        LayerIndex = layerIndex;
    }
}
