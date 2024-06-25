using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CurrencyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int decreaseAmount; // Количество валюты для уменьшения
    public GameObject objectToChangeMaterial; // Ссылка на объект, к которому нужно применить материал
    public GameObject costTextObject; // Ссылка на объект текста стоимости
    public Material newMaterial; // Новый материал
    public Text costText; // Ссылка на текстовый объект для отображения стоимости
    private bool isHolding = false; // Флаг для отслеживания удержания кнопки

    private void Start()
    {
        objectToChangeMaterial = GameObject.FindWithTag("PlayerSkin");

        if (objectToChangeMaterial == null)
        {
            Debug.LogError("Player object is missing!");
        }
        UpdateCostText();
    }

    private void UpdateCostText()
    {
        if (costText != null)
        {
            costText.text = "It is cost: " + decreaseAmount.ToString(); // Обновляем текст
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        costTextObject.SetActive(true); // Включаем объект текста стоимости
        StartCoroutine(PurchaseCoroutine());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }

    private IEnumerator PurchaseCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        if (isHolding)
        {
            TryPurchase();
        }
    }

    private void TryPurchase()
    {
        // Проверяем наличие экземпляра CurrencyManager
        if (CurrencyManager.instance != null)
        {
            // Проверяем, достаточно ли валюты для покупки
            if (CurrencyManager.instance.currency >= decreaseAmount)
            {
                // Если достаточно, уменьшаем количество валюты на указанную сумму
                CurrencyManager.instance.DecreaseCurrency(decreaseAmount);
                Debug.Log("Purchase successful!");

                // Применяем новый материал к объекту
                if (objectToChangeMaterial != null && newMaterial != null)
                {
                    Renderer renderer = objectToChangeMaterial.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = newMaterial;
                    }
                }
            }
            else
            {
                Debug.Log("Not enough currency for purchase!");
            }
        }
        else
        {
            Debug.LogError("CurrencyManager instance is missing!");
        }
    }
}
