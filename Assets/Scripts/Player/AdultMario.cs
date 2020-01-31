using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-30-PM-3-14
// 작성자   : 김세중
// 간단설명 :

public class AdultMario : MonoBehaviour
{
    // Variable
    #region Variable
    [SerializeField]
    private Vector3 HeadOverapBoxSize;
    [SerializeField]
    private Vector3 HeadOverapBoxOffset;
    [SerializeField]
    private LayerMask overlapCheckLayer;

    WaitForSeconds m_WaitDelaySeconds;

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        m_WaitDelaySeconds=new WaitForSeconds(0.5f);
    }
    private void OnEnable()
    {
        Common.CurrentPlayer = MarioSize.Adult;
    }
    private void Update()
    {
        //CheckGround();
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(transform.position+ HeadOverapBoxOffset, HeadOverapBoxSize);
    }

    #endregion

    // Private Method
    #region Private Method
    private void CheckGround()
    {
        //Vector2 vector2 = new Vector2(transform.position.x, transform.position.y + 0.015f);
        //RaycastHit2D hit = Physics2D.Raycast(vector2, transform.TransformDirection(Vector2.down), 0.03f/*, LayerMask.GetMask(Common.layerEnvirments)*/);
        //Debug.DrawRay(vector2, transform.TransformDirection(Vector2.down) * 0.03f, Color.red);

        Collider2D hit = Physics2D.OverlapBox(transform.position + HeadOverapBoxOffset, HeadOverapBoxSize, 0, overlapCheckLayer.value);

        if (hit != null)
        {
            if (hit.CompareTag(Common.tagEnvirments))
            {
                BrickObjectControl f_brickObjectcontrol = hit.gameObject.GetComponent<BrickObjectControl>();
                if (f_brickObjectcontrol != null)
                {
                    if (f_brickObjectcontrol.PoketQueue.Count == 0)
                    {
                        ItemSpawner.Instance.Pooling(1, SpawnerType.ItemType.BrickPopEffect, hit.transform.localPosition);
                        hit.gameObject.SetActive(false);
                    }
                   // StartCoroutine(DelayActiveFalse(hit));
                }
            }
        }
 
    }
    #endregion

    // Public Method
    #region Public Method


    #endregion
}
