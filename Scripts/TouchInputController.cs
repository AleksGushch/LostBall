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
            Touch touch_1 = Input.GetTouch(0);//регистрация первого касания
            if (touch_1.phase == TouchPhase.Moved) 
            {
                if (touch_1.deltaPosition.x > 10f)//10f погрешность при касании
                {
                    //Debug.Log("Движемся вправо");
                    direction = Vector2.right;
                }
                else if (touch_1.deltaPosition.x < -10f) 
                {
                    //Debug.Log("Движемся влево");
                    direction = Vector2.left;
                } 
            }
            if (touch_1.phase == TouchPhase.Ended) 
            {
                endPoint = touch_1.position;
                if (((endPoint.x - startPoint.x) > 100f) && (touch_1.deltaPosition.y <= 50f))
                {
                    Debug.Log("Свайп вправо");
                }
                else if (((endPoint.x - startPoint.x) < -100f) && (touch_1.deltaPosition.y <= 50f)) 
                {
                    Debug.Log("Свайп влево");
                }
                else
                {
                    Debug.Log("Свайп отменен");
                }
            }
            if (currentDirection != direction) 
            {
                //Debug.Log("Изменилось направление");
                startPoint = touch_1.position;
                currentDirection = direction;
            }
        }
        else if (Input.touchCount == 2) 
        {
            Touch touch_1 = Input.GetTouch(0);//регистрация первого касания
            Touch touch_2 = Input.GetTouch(1);//регистрация второго касания
            if ((touch_1.phase == TouchPhase.Began) || (touch_2.phase == TouchPhase.Began))
            {
                distance = Vector3.Distance(touch_1.position, touch_2.position);
            }
            if ((touch_1.phase == TouchPhase.Moved) || (touch_2.phase == TouchPhase.Moved))
            {
                difDist = Vector3.Distance(touch_1.position, touch_2.position);
                if (Mathf.Abs(difDist - distance)>distance*0.1f && difDist>distance)
                {
                    Debug.Log("Жест увеличения");
                }
                else if (Mathf.Abs(difDist - distance) > distance * 0.1f && difDist<distance)
                {
                    Debug.Log("Жест уменьшения");
                }
            }
        }
    }
}
