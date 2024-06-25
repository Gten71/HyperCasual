using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CurrencyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int decreaseAmount; // ���������� ������ ��� ����������
    public GameObject objectToChangeMaterial; // ������ �� ������, � �������� ����� ��������� ��������
    public GameObject costTextObject; // ������ �� ������ ������ ���������
    public Material newMaterial; // ����� ��������
    public Text costText; // ������ �� ��������� ������ ��� ����������� ���������
    private bool isHolding = false; // ���� ��� ������������ ��������� ������

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
            costText.text = "It is cost: " + decreaseAmount.ToString(); // ��������� �����
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        costTextObject.SetActive(true); // �������� ������ ������ ���������
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
        // ��������� ������� ���������� CurrencyManager
        if (CurrencyManager.instance != null)
        {
            // ���������, ���������� �� ������ ��� �������
            if (CurrencyManager.instance.currency >= decreaseAmount)
            {
                // ���� ����������, ��������� ���������� ������ �� ��������� �����
                CurrencyManager.instance.DecreaseCurrency(decreaseAmount);
                Debug.Log("Purchase successful!");

                // ��������� ����� �������� � �������
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
