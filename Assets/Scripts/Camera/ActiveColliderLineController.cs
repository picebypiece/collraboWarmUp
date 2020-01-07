using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-06-PM-4-30
// 작성자   : 김세중
// 간단설명 :

public class ActiveColliderLineController : MonoBehaviour
{
    // Variable
    #region Variable

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag(Common.tagGround))
        {
            if (collision.gameObject.CompareTag(Common.tagEnvirments))
            {
                collision.gameObject.GetComponent<TileObject>().Renderer.enabled = true;
            }
            else if (collision.gameObject.CompareTag(Common.tagEnemy))
            {
                collision.gameObject.GetComponent<Enemy>().Property_SpriteRenderer.enabled = true;
            }
        }
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    #endregion
}
