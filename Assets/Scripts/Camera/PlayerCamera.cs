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
    CreateTileMap m_CreateTileMap;
    [SerializeField]
    DeathLineController m_DeathLineController;
    [SerializeField]
    ActiveColliderLineController m_ActiveColliderLineController;
    [SerializeField]
    EdgeCollider2D m_CameraCollider;
    [SerializeField]
    Camera m_Camera;
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    Vector2 CameraWidthHeight;
    [SerializeField]
    Vector2 ColliderProcession;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        if (m_CreateTileMap == null)
        {
            m_CreateTileMap = GameObject.Find(Common.TileGrideName).GetComponent<CreateTileMap>();
        }

        m_Camera.orthographic = true;
        m_Camera.orthographicSize = 1.2f;
        CameraWidthHeight.y = 2 * m_Camera.orthographicSize;
        CameraWidthHeight.x = CameraWidthHeight.y * m_Camera.aspect;
    }
    private void Start()
    {
        //    ColliderProcession.x = m_CreateTileMap.m_MaxMapprocession.Colum-1* 0.16f;
        //    ColliderProcession.y = m_CreateTileMap.m_MaxMapprocession.Row * 0.16f;
        //    m_CameraCollider.offset = ColliderProcession;
        //m_CameraCollider.offset = m_CreateTileMap.m_MaxMapprocession.Colum * 0.16f;
        //m_CameraCollider.offset.y = m_CreateTileMap.m_MaxMapprocession.Row * 0.16f;
        m_DeathLineController.RayDistance[0] = m_CreateTileMap.m_MaxMapprocession.Colum * 0.16f;
        m_DeathLineController.RayDistance[1] = m_CreateTileMap.m_MaxMapprocession.Row * 0.16f;
        m_ActiveColliderLineController.RayDistance[0] = m_CreateTileMap.m_MaxMapprocession.Colum * 0.16f;
        FirstCameraRender();
    }

#if UNITY_EDITOR
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(this.transform.position, CameraWidthHeight);
    //}
#endif

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
    /// <summary>
    /// 최초 카메라 렌더링
    /// </summary>
    void FirstCameraRender()
    {
        Collider2D[] CameraBoxHit = Physics2D.OverlapBoxAll(this.transform.position, CameraWidthHeight, 0);

        if (CameraBoxHit != null)
        {
            foreach (var Object in CameraBoxHit)
            {
                Collider2D f_Collider2D = Object;
                if (!f_Collider2D.CompareTag(Common.tagGround) && !f_Collider2D.CompareTag(Common.tagCamera))
                {
                    GameObject f_GameObject = f_Collider2D.gameObject;

                    if (f_GameObject.CompareTag(Common.tagEnvirments))
                    {
                        f_GameObject.GetComponent<TileObject>().Renderer.enabled = true;
                    }
                    else if (f_GameObject.CompareTag(Common.tagEnemy))
                    {
                        f_GameObject.GetComponent<Enemy>().Property_SpriteRenderer.enabled = true;
                        f_GameObject.GetComponent<Enemy>().enabled = true;
                    }
                }
            }
        }
    }
#endregion

    // Public Method
#region Public Method

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }
#endregion
}
