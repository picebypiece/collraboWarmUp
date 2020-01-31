using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-31-PM-11-31
// 작성자   : 김세중
// 간단설명 :

public class BrickPiece : MonoBehaviour
{
    // Variable
    #region Variable
    [SerializeField]
    Vector3 SaveOriginPos;
    [SerializeField]
    Rigidbody2D m_RigidBody;
    [SerializeField]
    int VectorDir;
    [SerializeField]
    protected Vector2[] moveDirections =
    {
        Vector2.left,
        Vector2.right
    };
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        m_RigidBody = this.gameObject.GetComponent<Rigidbody2D>();
      
    }

    private void OnEnable()
    {  
        SaveOriginPos = this.transform.position;
        StartCoroutine(DelaySetActiveFalse());
    }



    private void OnDisable()
    {
        this.transform.position = SaveOriginPos;
    }
    #endregion

    // Private Method
    #region Private Method
    public IEnumerator DelaySetActiveFalse()
    {
        while (true)
        {
            m_RigidBody.AddForce(Vector3.up * 75, ForceMode2D.Force);

            m_RigidBody.AddForce(moveDirections[VectorDir] * 15, ForceMode2D.Force);
            yield return new WaitForSeconds(1.5f);
            break;
        }
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
    #endregion

    // Public Method
    #region Public Method

    #endregion
}
