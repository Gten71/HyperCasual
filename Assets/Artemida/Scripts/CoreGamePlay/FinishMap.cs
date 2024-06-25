using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMap : MonoBehaviour
{
    [SerializeField] private int countToDestroy;
    private CurrencyManager score;
    private StartMenuUI cheker;
    private void Start()
    {
        score =  FindObjectOfType<CurrencyManager>();
        cheker = FindObjectOfType<StartMenuUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (score.currency >= countToDestroy)
            {
                Destroy(gameObject);
            }
            else
            {
                cheker.start = false;
                cheker._win.enabled = true;
            }
        }
    }
}
