using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int _monsterCount;

    public GameObject[] _spawnPoints;
    public GameObject _monsterPrefab;
    public LevelController _controlLevel;


    void Start()
    {
        List<int> availableIndices = new List<int>(); // Kullan�labilir spawnPoint indekslerini saklamak i�in bir liste olu�turun
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            availableIndices.Add(i); // Ba�lang��ta t�m spawnPoint indekslerini listeye ekleyin
        }

        for (int i = 0; i < _monsterCount; i++)
        {
            if (availableIndices.Count == 0)
            {
                break; // Kullan�labilir spawnPoint kalmad�ysa d�ng�y� sonland�r
            }

            int randomIndex = Random.Range(0, availableIndices.Count); // Kullan�labilir indekslerden rastgele birini se�er.
            int spawnIndex = availableIndices[randomIndex]; // Se�ilen indeksi kullanarak spawnPoint indeksini al�r.
            availableIndices.RemoveAt(randomIndex); // Kullan�lan indeksi listeden kald�r�r.

            GameObject spawnPoint = _spawnPoints[spawnIndex];

            GameObject monster = Instantiate(_monsterPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            _controlLevel._monsters.Add(monster.GetComponent<Monster>());
        }
    }

}
