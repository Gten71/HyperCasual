using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchMove : MonoBehaviour
{
   // [Tooltip("скорость вперед")]
   // public float speedF;
    [Tooltip("скорость лев прав")]
    public float speedLR;
    [Tooltip("аниматор перса")]
    private Animator _anim;
    [Tooltip("проверка на начало игры")]
    private StartMenuUI cheker;
    [Tooltip("позиция курсора и направление для движения в лев прав")]
    private Vector3 mouse, targetPosition;
    void Start()
    {
        cheker = FindObjectOfType<StartMenuUI>();
        _anim = gameObject.GetComponent<Animator>(); // подключаю аниматор
    }
    void Update()
    {
        if (cheker.start)
        {
            _anim.SetBool("Sprint",true); // включаю анимацию бега 
            //transform.Translate(Vector3.forward * speedF * Time.deltaTime); //бег вперед
            /* получаем корды курсора и делим их на два чтобы не выходить за рамки карты тк максимальный размер карты от -1 до 1 */
            mouse = (Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0f)) / (Screen.width / 2f);
            targetPosition = new Vector3(mouse.x, 0, transform.position.z); // вектор котоырй принимает позицию курсора и бега вперед
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speedLR); // применяем всю кашу малашу с эффектом замедла

        }
        else if(!cheker.start)
        {
            _anim.SetBool("Sprint",false);
        }
    }
}
