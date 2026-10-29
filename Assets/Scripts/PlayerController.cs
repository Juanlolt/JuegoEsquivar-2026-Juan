using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int vidas;
    public float velocidad;
    private float xMin = -15f, xMax = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Imput manager antiguo
        /*float move = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        transform.Translate(move, 0f, 0f); */

        //Imput system nuevo
        float direction = 0f;
        Keyboard teclado = Keyboard.current;
        if (teclado != null)
        {
            if(teclado.leftArrowKey.isPressed || teclado.aKey.isPressed)
            {
                direction -= 1f;
            }
            if (teclado.rightArrowKey.isPressed || teclado.dKey.isPressed)
            {
                direction += 1f;
            }
        }

        /*Gamepad mando = Gamepad.current;
        if (teclado != null && Mathf.Abs(mando.leftStick.x.ReadValue()) > 0.1)
        {
            direction = mando.leftStick.x.ReadValue();
        } */

        transform.Translate(direction * Time.deltaTime * velocidad, 0f, 0f);
        Vector2 posicion = transform.position;
        posicion.x = Mathf.Clamp(posicion.x, xMin, xMax);
        transform.position = posicion; 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                Destroy(other.gameObject);
                vidas --;

                if (vidas <= 0)
                {
                    Debug.Log("GAME OVER");
                }
                else
                {
                    Debug.Log("Tienes " + vidas + " vidas");
                }
            }
        }
    }
}
