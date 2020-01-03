using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-03-PM-3-57
// 작성자   : 배형영
// 간단설명 :

public class PlayerCamera : MonoBehaviour
{
    // Variable
    #region Variable

    private Transform player = null;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    private void LateUpdate()
    {
        if (player != null)
        {
            //if (transform.position.x < player.position.x)
            //    transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            if (transform.position.x < player.position.x)
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), Time.deltaTime*2);
        }
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }
    #endregion
}
