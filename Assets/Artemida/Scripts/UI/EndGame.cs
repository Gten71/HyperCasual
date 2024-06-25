using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private Canvas  _game;
    void Start()
    {
        _game = transform.Find("Game").GetComponent<Canvas>();

        _game.enabled = false;
    }

    public void BackMenuGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    
}
