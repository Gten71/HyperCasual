using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class SpawnMap : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabs;
    private GameObject[] _map;
    private Random rand = new Random();
    private StartMenuUI cheker;
    [SerializeField] private float _timer;
    private float _timeNow;
    private bool emptyCheker = false;
    [SerializeField] private int countToSpawn;
    private CurrencyManager _text;
    private int countMaps = 0;
    private void Start()
    {
        _timeNow = _timer;
        cheker = FindObjectOfType<StartMenuUI>();
        _text =  FindObjectOfType<CurrencyManager>();
    }

    void Update()
    {
        if (_text.currency <= 0) {
            cheker.start = false;
            cheker._lose.enabled = true; 
        }
        if (cheker.start)
        {
            _timeNow -= Time.deltaTime;
            if (_timeNow < 0)
            {
                _map = GameObject.FindGameObjectsWithTag("Varota");
                SpawningMap();
            }
        }

        
    }

    private void SpawningMap()
    {
        if (countMaps < countToSpawn)
        {
            if (_map.Length == 0)
            {
                Instantiate(_prefabs[rand.Next(1, 3)], transform.position, Quaternion.identity);
                _timeNow = _timer;
                countMaps++;
            }
            else if (_map.Length < 3)
            {
                Instantiate(_prefabs[rand.Next(0, _prefabs.Length - 1)], transform.position, Quaternion.identity);
                _timeNow = _timer;
                countMaps++;
            }
            else
            {
                Instantiate(_prefabs[0], transform.position, Quaternion.identity);
                _timeNow = _timer;
                countMaps++;
            }
        }
        else if(countMaps == countToSpawn)
        {
            Instantiate(_prefabs[_prefabs.Length-1], transform.position, Quaternion.identity);
            countMaps++;
        }
    }


}
