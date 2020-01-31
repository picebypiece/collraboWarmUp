using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ۼ����� : 2019-12-22-PM-7-58
// �ۼ���   : �輼��
// ���ܼ��� :
public class BrickObjectControl : TileObject
{
    // Variable
    #region Variable
    [SerializeField]
    Animator m_RenderAnimator;
    public struct AnimID
    {
        public int
            Hit;
    }
    public AnimID m_AnimID;
    public struct AnimClipName
    {
        public int
            Hit;

        public WaitForSeconds
            Hitlength;
    }
    AnimClipName m_AnimClipName;
    #endregion

    // Property
    #region Property
    public Animator RenderAnimator
    {
        get => m_RenderAnimator;
        set => m_RenderAnimator = value;
    }

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    public override void Awake()
    {
        base.Awake();
        AnimIDInit();
    }
    #endregion

    // Private Method
    #region Private Method
    void AnimIDInit()
    {
        m_AnimID.Hit = Animator.StringToHash("Hit");

        m_AnimClipName.Hit = 0;
        m_AnimClipName.Hitlength = new WaitForSeconds(m_Animations[m_AnimClipName.Hit].length);
    }
    #endregion

    // Public Method
    #region Public Method
    public override void ActionCall()
    {
        StartCoroutine(ItemArriveCondition());
    }
    public void ReSetTriggerHit()
    {
        RenderAnimator.ResetTrigger(m_AnimID.Hit);
    }

    IEnumerator ItemArriveCondition()
    {
        //�ָӴ� ť�� ������� �ʴٸ�,
        if (m_PoketQueue.Count != 0)
        {
            //Hit Trigger ����
            m_RenderAnimator.SetTrigger(m_AnimID.Hit);
            //ť�� Out �� �з�
            switch (m_PoketQueue.Peek())
            {
                case SpawnerType.ItemType.Coin:
                    break;
                case SpawnerType.ItemType.GrowthMushroom:
                    yield return m_AnimClipName.Hitlength;
                    break;
                case SpawnerType.ItemType.PopCoin:
                    break;
                default:
                    break;
            }
            //ItemPool���� Pooling ȣ��
            ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position /*+ new Vector3(0, 0.16f, 0)*/);
        }
        //�ָӴ� ť�� ����ִٸ�
        else if (m_PoketQueue.Count == 0)
        {
            if (Common.CurrentPlayer == MarioSize.Child)
            {
                m_RenderAnimator.SetTrigger(m_AnimID.Hit);
            }
            else if (Common.CurrentPlayer == MarioSize.Adult)
            {
                ItemSpawner.Instance.Pooling(1, SpawnerType.ItemType.BrickPopEffect, this.transform.localPosition);
                this.gameObject.SetActive(false);
            }
        
        }
    }

    #endregion


}
