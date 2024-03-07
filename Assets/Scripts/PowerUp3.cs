using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp3 : MonoBehaviour
{
    
    public float multiploDelModificador = 2f;
    public float duracionDelModificador = 10f;
    public float velocidadDeMovimiento = 1f;


    private void Start()
    {
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -velocidadDeMovimiento);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);

        }
    }

}
