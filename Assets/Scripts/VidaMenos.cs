using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMenos : MonoBehaviour
{
    public float velocidadAbajo = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -velocidadAbajo);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }




    }

