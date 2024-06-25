using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Скорость движения персонажа

    void Update()
    {
        // Проверяем нажатие на экран
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Если пальцем двигают по экрану
            if (touch.phase == TouchPhase.Moved)
            {
                // Определяем направление движения
                Vector3 moveDirection = new Vector3(touch.deltaPosition.x, 0f, 0f);
                moveDirection.Normalize();

                // Двигаем персонажа в соответствии с направлением и скоростью
                transform.Translate(moveDirection * speed * Time.deltaTime);
            }
        }
    }
}
