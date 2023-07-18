using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;

    public Wave[] waves;

    public Transform spawnPoint;

    public TMP_Text waveCountdownText;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    public GameManager gameManager;

    public bool isPlayerReady = false;
    public GameObject readyBtn;

    void Start()
    {
        EnemiesAlive = 0;    
    }

    void Update()
    {
        if (EnemiesAlive > 0 || !isPlayerReady)
        {
            return;
        }

        if (waveIndex == waves.Length && PlayerStats.Lives > 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.enemies.Length;

        for (int i = 0; i < wave.enemies.Length; i++)
        {
            SpawnEnemy(wave.enemies[i]);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    public void SetReady()
    {
        isPlayerReady = true;
        readyBtn.SetActive(false);
    }
}
