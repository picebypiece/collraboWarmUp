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
    [SerializeField]
    Camera m_Camera;
    private Transform player = null;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    //private void Awake()
    //{
    //    Ray f_ray = m_Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    //    RaycastHit2D f_hit = Physics2D.Raycast(this.transform.position, -Vector2.up);

    //    if (f_hit.collider != null)
    //    {
    //        f_hit.collider.gameObject.GetComponent<TileObject>().Renderer.enabled = true;
    //    }
    //}

    private void LateUpdate()
    {

        //Ray f_ray = m_Camera.ViewportPointToRay(new Vector3(1, 1, 0));
        //Ray f_ray = m_Camera.vir (new Vector3(1, 1, 0));
        //RaycastHit2D f_hit = Physics2D.Raycast(this.transform.position, -Vector2.up);

        //if (f_hit.collider.CompareTag(Common.tagEnvirments))
        //{
        //    f_hit.collider.gameObject.GetComponent<TileObject>().Renderer.enabled = true;
        //}

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
