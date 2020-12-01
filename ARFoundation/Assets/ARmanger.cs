
using UnityEngine;
using UnityEngine.XR.ARFoundation;//引用ARFOUNDATION API
using UnityEngine.XR.ARSubsystems;//引用ARFOUNDATION API
using System.Collections.Generic;//引用 系統.集合.一般 包含清單 List

/// <summary>
/// 點擊地面生成物件
/// </summary>
//RC 要求元件:在第一次套用腳本時執行
[RequireComponent(typeof(ARRaycastManager))]

public class ARmanger : MonoBehaviour
{
    [Header("點擊後生成物件")]
    public GameObject obj;
    [Header("AR管理器")]
    public ARRaycastManager arManger
        ;
    //滑鼠座標
    private Vector2 pointMouse;
    //碰撞資訊
    private List<ARRaycastHit> hits;

    /// <summary>
    /// 點擊
    /// </summary>

    private void Tap()
    {
        //判斷玩家是否點擊
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pointMouse = Input.mousePosition;  //滑鼠座標=玩家的滑鼠座標
            print(pointMouse);
        }
        //判斷射線是否打到物件
        if (arManger.Raycast(pointMouse, hits, TrackableType.PlaneWithinPolygon))
        {
            // 生成物件(物件，座標，角度)
            // hits[0].pose.position 點擊到地面的第一個位置
            // Quaternion.identity 零角度
            Instantiate(obj, hits[0].pose.position, Quaternion.identity);
        }
        //生成物件
    }

    private void Update()
    {
        Tap();

    }

}
