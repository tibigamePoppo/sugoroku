using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float mouse_sensitivity = -1f;
    [SerializeField] float touch_sensitivity = -0.01f;

    void Update()
    {
        //ドラッグ中もしくはスワイプ中
        if (Input.GetMouseButton(0))
        {
            float dx, dy;

            //PCマウスの場合
            dx = Input.GetAxis("Mouse X") * mouse_sensitivity;
            dy = Input.GetAxis("Mouse Y") * mouse_sensitivity;

            //スマホのタッチの場合
            if (Input.touchCount > 0)
            {
                dx = Input.touches[0].deltaPosition.x * touch_sensitivity;
                dy = Input.touches[0].deltaPosition.y * touch_sensitivity;
            }

            //ドラッグした分だけオブジェクトを動かす
            target.transform.Translate(dx, dy, 0.0f);
        }
    }
}
