using UnityEngine;
using UnityEngine.UI;

public class PlayerScale : MonoBehaviour
{
    [SerializeField] private float startingScale = 0.3f;
    [SerializeField] private float maxScale = 2f;
    private CurrencyManager _text;
    [SerializeField] private int _maxScoreForMaxSize;
    private float scaleMultiplier = 0.001f;
    private float currentScale;
    private int score = 0;

    private void Start()
    {
        _text =  FindObjectOfType<CurrencyManager>();
        currentScale = startingScale;
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

    void Update()
    {
        score = _text.currency;
        float scaleFactor = Mathf.Clamp01((float)score / (float)_maxScoreForMaxSize);
        float targetScale = Mathf.Lerp(startingScale, maxScale, scaleFactor);
        currentScale = Mathf.Lerp(currentScale, targetScale, Time.deltaTime * 2);
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
