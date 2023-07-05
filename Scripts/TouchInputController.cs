using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputController : MonoBehaviour
{
    Vector2 currentDirection;
    Vector2 direction;
    Vector2 startPoint;
    Vector2 endPoint;
    float distance;
    float difDist;
    void Start()
    {
        currentDirection = Vector2.right;
    }
    void Update()
    {
        if (Input.touchCount == 1) 
        {
            Touch touch_1 = Input.GetTouch(0);//����������� ������� �������
            if (touch_1.phase == TouchPhase.Moved) 
            {
                if (touch_1.deltaPosition.x > 10f)//10f ����������� ��� �������
                {
                    //Debug.Log("�������� ������");
                    direction = Vector2.right;
                }
                else if (touch_1.deltaPosition.x < -10f) 
                {
                    //Debug.Log("�������� �����");
                    direction = Vector2.left;
                } 
            }
            if (touch_1.phase == TouchPhase.Ended) 
            {
                endPoint = touch_1.position;
                if (((endPoint.x - startPoint.x) > 100f) && (touch_1.deltaPosition.y <= 50f))
                {
                    Debug.Log("����� ������");
                }
                else if (((endPoint.x - startPoint.x) < -100f) && (touch_1.deltaPosition.y <= 50f)) 
                {
                    Debug.Log("����� �����");
                }
                else
                {
                    Debug.Log("����� �������");
                }
            }
            if (currentDirection != direction) 
            {
                //Debug.Log("���������� �����������");
                startPoint = touch_1.position;
                currentDirection = direction;
            }
        }
        else if (Input.touchCount == 2) 
        {
            Touch touch_1 = Input.GetTouch(0);//����������� ������� �������
            Touch touch_2 = Input.GetTouch(1);//����������� ������� �������
            if ((touch_1.phase == TouchPhase.Began) || (touch_2.phase == TouchPhase.Began))
            {
                distance = Vector3.Distance(touch_1.position, touch_2.position);
            }
            if ((touch_1.phase == TouchPhase.Moved) || (touch_2.phase == TouchPhase.Moved))
            {
                difDist = Vector3.Distance(touch_1.position, touch_2.position);
                if (Mathf.Abs(difDist - distance)>distance*0.1f && difDist>distance)
                {
                    Debug.Log("���� ����������");
                }
                else if (Mathf.Abs(difDist - distance) > distance * 0.1f && difDist<distance)
                {
                    Debug.Log("���� ����������");
                }
            }
        }
    }
}
