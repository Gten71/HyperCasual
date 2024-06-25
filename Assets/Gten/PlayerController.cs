using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // �������� �������� ���������

    void Update()
    {
        // ��������� ������� �� �����
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ���� ������� ������� �� ������
            if (touch.phase == TouchPhase.Moved)
            {
                // ���������� ����������� ��������
                Vector3 moveDirection = new Vector3(touch.deltaPosition.x, 0f, 0f);
                moveDirection.Normalize();

                // ������� ��������� � ������������ � ������������ � ���������
                transform.Translate(moveDirection * speed * Time.deltaTime);
            }
        }
    }
}
