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
        List<int> availableIndices = new List<int>(); // Kullanýlabilir spawnPoint indekslerini saklamak için bir liste oluþturun
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            availableIndices.Add(i); // Baþlangýçta tüm spawnPoint indekslerini listeye ekleyin
        }

        for (int i = 0; i < _monsterCount; i++)
        {
            if (availableIndices.Count == 0)
            {
                break; // Kullanýlabilir spawnPoint kalmadýysa döngüyü sonlandýr
            }

            int randomIndex = Random.Range(0, availableIndices.Count); // Kullanýlabilir indekslerden rastgele birini seçer.
            int spawnIndex = availableIndices[randomIndex]; // Seçilen indeksi kullanarak spawnPoint indeksini alýr.
            availableIndices.RemoveAt(randomIndex); // Kullanýlan indeksi listeden kaldýrýr.

            GameObject spawnPoint = _spawnPoints[spawnIndex];

            GameObject monster = Instantiate(_monsterPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            _controlLevel._monsters.Add(monster.GetComponent<Monster>());
        }
    }

}
