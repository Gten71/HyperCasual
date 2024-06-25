using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public enum Operation { Add, Subtract, Multiply, Divide };
    public Operation operation;
    private int score;
    [SerializeField] private CurrencyManager currencyManager = null;
    [SerializeField] private TextMeshProUGUI operationText = null;

    void Start()
    {
        FindCurrencyManager();
        GenerateScore();
        UpdateOperationText();
    }

    private void FindCurrencyManager()
    {
        if (CurrencyManager.instance != null)
        {
            currencyManager = CurrencyManager.instance;
        }
        else
        {
            Debug.LogError("CurrencyManager instance not found!");
        }
    }

    private void GenerateScore()
    {
        int currentScore = currencyManager.currency;
        Operation[] operations = (Operation[])System.Enum.GetValues(typeof(Operation));
        operation = operations[Random.Range(0, operations.Length)];
        switch (operation)
        {
            case Operation.Multiply:
            case Operation.Divide:
                // Default generation by 1 to 5 for multiple adn divide
                score = Random.Range(1, 5);
                break;
            case Operation.Subtract:
                // Generation by formule by Õ * 1/5 to Õ * 2/3
                score = Random.Range(currentScore * 1 / 5, currentScore * 2 / 3);
                break;
            // X - user points
            default: // Operation.Add
                // Generation by formule by X * 1/2 to Õ * 1.5
                score = Random.Range(currentScore * 1 / 2, (int)(currentScore * 1.5));
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        switch (operation)
        {
            case Operation.Add:
                currencyManager.currency += score;
                break;
            case Operation.Subtract:
                currencyManager.currency -= score;
                break;
            case Operation.Multiply:
                currencyManager.currency *= score;
                break;
            case Operation.Divide:
                currencyManager.currency /= score;
                break;
        }

        currencyManager.UpdateScoreText();
    }

    private void UpdateOperationText()
    {
        string operationSymbol = GetOperationSymbol(operation);
        operationText.text = operationSymbol + " " + score.ToString();
    }

    private string GetOperationSymbol(Operation operation)
    {
        switch (operation)
        {
            case Operation.Add: return "+";
            case Operation.Subtract: return "-";
            case Operation.Multiply: return "x";
            case Operation.Divide: return "/";
            default: return "";
        }
    }
}
