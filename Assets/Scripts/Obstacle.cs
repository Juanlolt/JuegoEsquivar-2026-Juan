using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float fallspeed = 8f;
    public float minY = -15f;
    public GameManager gameManager;
    private GameManager.Dificultad dificultad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();//GetComponent<GameManager>();
        switch(gameManager.dificultad)
        {
            case (GameManager.Dificultad.Facil):
                fallspeed = 5f;
                break;
            case (GameManager.Dificultad.Normal):
                fallspeed = 7.5f;
                break;
            case (GameManager.Dificultad.Dificil):
                fallspeed = 10f;
                break;
        }
        Debug.Log($"Velocidad de caida {fallspeed}");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallspeed * Time.deltaTime);
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
