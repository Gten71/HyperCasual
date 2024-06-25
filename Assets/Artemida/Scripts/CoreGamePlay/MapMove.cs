using UnityEngine;


public class MapMove : MonoBehaviour
{
    private float speed = 4;
    private StartMenuUI cheker;
    private void Start()
    {
        cheker = FindObjectOfType<StartMenuUI>();
    }
    void Update()
    { 
        if (cheker.start)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       Destroy(gameObject);
    }
}
