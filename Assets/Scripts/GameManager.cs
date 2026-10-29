using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obstaculoPrefabs;
    private float minIntervaloPrefabs = 0.5f;
    private float maxIntervaloPrefabs = 2f;
    public enum Dificultad
    {
        Facil,
        Normal,
        Dificil
    };
    public Dificultad dificultad;
    private float timer = 0f;
    private float nextIntervaloPrefabs;
    public float spawnY = 10f;
    public float minX = -20f;
    public float maxX = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (dificultad)
        {
            case Dificultad.Facil:
                minIntervaloPrefabs = 0.75f;
                maxIntervaloPrefabs = 2f;
                break;
            case Dificultad.Normal:
                minIntervaloPrefabs = 0.5f;
                maxIntervaloPrefabs = 1.5f;
                break;
            case Dificultad.Dificil:
                minIntervaloPrefabs = 0.25f;
                maxIntervaloPrefabs = 1f;
                break;
            default:
                minIntervaloPrefabs = 0.75f;
                maxIntervaloPrefabs = 2f;
                break;

        }
        Debug.Log($"minimo: {minIntervaloPrefabs} | maximo: {maxIntervaloPrefabs}");
        nextIntervaloPrefabs = UnityEngine.Random.Range(minIntervaloPrefabs, maxIntervaloPrefabs);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextIntervaloPrefabs)
        {
            float randomX = UnityEngine.Random.Range(minX, maxX);
            Vector2 spawnPosition = new Vector2(randomX, spawnY);
            int randomIndex = UnityEngine.Random.Range(0, obstaculoPrefabs.Length);
            Instantiate(obstaculoPrefabs[randomIndex], spawnPosition, Quaternion.identity);

            timer = 0f;
            if(maxIntervaloPrefabs > minIntervaloPrefabs)
            {
                maxIntervaloPrefabs = (maxIntervaloPrefabs - 0.005f);
            }
            nextIntervaloPrefabs = UnityEngine.Random.Range(minIntervaloPrefabs, maxIntervaloPrefabs);
        }
    }
}
