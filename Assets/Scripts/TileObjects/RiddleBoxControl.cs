using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ۼ����� : 2019-12-22-PM-7-58
// �ۼ���   : �輼��
// ���ܼ��� : ����ǥ ���ڸ� ����� ���µ� �ʿ��� Ŭ����
public class RiddleBoxControl : TileObject
{
    // Variable
    #region Variable
    [SerializeField]
    Animator RenderAnimator;
    /// <summary>
    /// RiddleBox Animation ID Struct
    /// </summary>
    public struct AnimID
    {
        public int
            Pop, Empty;
    }
    AnimID m_AnimID;

    /// <summary>
    /// RiddleBox Animation Clip Struct
    /// </summary>
    public struct AnimClipName
    {
        public int
            popUp;
        public WaitForSeconds
            popUplength;
    }
    AnimClipName m_AnimClipName;

    //IEnumerator MoveUpDown;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    public override void Awake()
    {
        base.Awake();
        AnimInit();
    }
    #endregion

    // Private Method
    #region Private Method
    /// <summary>
    /// �ִϸ��̼� ���� �غ�, Ŭ���� ���̵� �ʱ�ȭ
    /// </summary>
    void AnimInit()
    {
        m_AnimID.Pop = Animator.StringToHash("PopTrigger");
        m_AnimID.Empty = Animator.StringToHash("EmptyTrigger");

        m_AnimClipName.popUp = 0;
        m_AnimClipName.popUplength = new WaitForSeconds(m_Animations[m_AnimClipName.popUp].length);
    }
    #endregion

    // Public Method
    #region Public Method
    public override void ActionCall()
    {
        StartCoroutine(ItemArriveCondition());
    }

    /// <summary>
    /// ������ ���� ����
    /// </summary>
    /// <returns></returns>
    IEnumerator ItemArriveCondition()
    {
        //�ָӴ� ť�� ������� �ʴٸ�,
        if (m_PoketQueue.Count != 0)
        {
            //Pop Trigger ����
            RenderAnimator.SetTrigger(m_AnimID.Pop);
            //ť�� Out �� �з�
            switch (m_PoketQueue.Peek())
            {
                case SpawnerType.ItemType.Coin:
                    break;
                case SpawnerType.ItemType.GrowthMushroom:
                    yield return m_AnimClipName.popUplength;
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
        if (m_PoketQueue.Count == 0)
        {
            //����� Trigger ����
            RenderAnimator.SetTrigger(m_AnimID.Empty);
        }
    }

    public void SetEmptyBox()
    {
        RenderAnimator.SetTrigger(m_AnimID.Empty);
    }


    #endregion

   

}
