using UnityEngine;

public class StartMenuUI : MonoBehaviour
{
    private Canvas _gameMenu,_game,_store;
    public Canvas _win,_lose;
    private AudioSource _music;
    private AudioSource _click;
    private bool _checker = false;
    public bool start = false;
    private void Start()
    {
        _lose = transform.Find("GameOver").GetComponent<Canvas>();
        _win = transform.Find("Win").GetComponent<Canvas>();
        _music = transform.Find("Music").GetComponent<AudioSource>();
        _game = transform.Find("Game").GetComponent<Canvas>();
        _store = transform.Find("Store").GetComponent<Canvas>();
        _gameMenu = transform.Find("GameMenu").GetComponent<Canvas>();
        _click = transform.Find("Click").GetComponent<AudioSource>();
    }
    public void GameStart()
    {
        _gameMenu.enabled = false;
        start = true;
        _game.enabled = true;
    }

    public void OnOrOffMusic()
    {
        _click.Play();
        if (_checker)
        {
            _click.mute = false;
            _music.mute = false;
            _checker = false;
        }
        else
        {
            _click.mute = true;
            _music.mute = true;
            _checker = true;
        }
    }

    public void OpenStore()
    {
        _click.Play();
        _gameMenu.enabled = false;
        _store.enabled = true;

        GameObject scoreBox = GameObject.FindGameObjectWithTag("ScoreBox");
        if (scoreBox != null)
        {
            Canvas canvasComponent = scoreBox.GetComponent<Canvas>();
            if (canvasComponent != null)
            {
                canvasComponent.enabled = true;
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
