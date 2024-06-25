using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    public int currency;
    public Text scoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + currency.ToString();
    }

    public void DecreaseCurrency(int amount)
    {
        currency -= amount;
        UpdateScoreText(); // Обновляем текст
    }
}
