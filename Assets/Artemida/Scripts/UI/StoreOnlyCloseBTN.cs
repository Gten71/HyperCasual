using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreOnlyCloseBTN : MonoBehaviour
{
    private Canvas _gameMenu;
    private Canvas _store;
    private AudioSource _click;
    void Start()
    {
        _click = transform.Find("Click").GetComponent<AudioSource>();
        _store = transform.Find("Store").GetComponent<Canvas>();
        _gameMenu = transform.Find("GameMenu").GetComponent<Canvas>();
    }

    public void CloseStore()
    {
        _click.Play();
        _store.enabled = false;
        _gameMenu.enabled = true;
        GameObject scoreBox = GameObject.FindGameObjectWithTag("ScoreBox");
        if (scoreBox != null)
        {
            Canvas canvasComponent = scoreBox.GetComponent<Canvas>();
            if (canvasComponent != null)
            {
                canvasComponent.enabled = false;
            }
            else
            {
                Debug.LogError("Canvas component not found on object with tag 'ScoreBox'");
            }
        }
        else
        {
            Debug.LogError("Object with tag 'ScoreBox' not found");
        }
    }
}
