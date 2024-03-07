using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    /*
    Los límites definidos con bound nos hacen falta debido a que el jugador se puede salir de la pantalla
    debido a que su rigidbody es quinemático, por lo que no se ve afectado por la gravedad ni puede colisionar
    con objetos estáticos.
    */
    private Boolean tamañoAumentado = true;
    [SerializeField] private float bound = 4.5f; // x axis bound
    private float multiplicador = 2.0f;

    private Vector2 startPos; // Posición inicial del jugador


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Guardamos la posición inicial del jugador
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();
    }

    void PlayerMovement()
    {
         float moveInput = Input.GetAxisRaw("Horizontal");
        // Controlaríamo el movimiento de la siguiente forma de no ser el rigidbody quinemático
        // transform.position += new Vector3(moveInput * speed * Time.deltaTime, 0f, 0f);

        Vector2 playerPosition = transform.position;
        // Mathf.Clamp nos permite limitar un valor entre un mínimo y un máximo
        playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * speed * Time.deltaTime, -bound, bound);
        transform.position = playerPosition;
    }

    public void ResetPlayer()
    {
        transform.position = startPos; // Posición inicial del jugador
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("powerUp1")) // Si colisionamos con un powerUp
        {
            Destroy(collision.gameObject); // Lo destruimos
            GameManager.Instance.AddLife(); // Añadimos una vida
        }
        if (collision.CompareTag("powerUp2")) // Si colisionamos con un powerUp
        {
            Destroy(collision.gameObject); // Lo destruimos
            GameManager.Instance.quitarVida(); // Añadimos una vida
        }
        if (collision.CompareTag("powerUp3")) // Si colisionamos con un powerUp
        {
            if (tamañoAumentado)
            {
                StartCoroutine(RecogerPowerUp());
            }
        }
    }

    IEnumerator RecogerPowerUp()
    {
        tamañoAumentado = false;
        gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * multiplicador, gameObject.transform.localScale.y);
        yield return new WaitForSeconds(10.0f); //Dentro del parentesis metemos la cantidad de segundos que queremos que dure el powerUp
        gameObject.transform.localScale /= multiplicador;
        tamañoAumentado = true;
    }
}
