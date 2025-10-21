using UnityEngine;

public class Bala : MonoBehaviour{

    [Header("Ajustes de movimiento")]
    [SerializeField] private int velocidad;

    [Header("Tiempo de vida")]
    [SerializeField] private int tiempoVida;

    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoDisparo;
    [SerializeField] private AudioSource sonidoExplosion;

    [Header("Efectos")]
    [SerializeField] private GameObject efectoImpacto;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        if (sonidoDisparo != null) { 
            sonidoDisparo.Play();
        }
        rb=GetComponent<Rigidbody2D>();
        
        rb.linearVelocity = transform.right * velocidad;

        Destroy(gameObject, tiempoVida);

    }

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Enemy")) {

            if (sonidoExplosion != null){

                sonidoExplosion.Play();

//version con puntos estaticos:
//                Datos.Instance.AddPoints(25);
//                Datos.Instance.MostrarPuntosDinamicos(25,transform.position);

//version con puntos personalizados por enemigo:

                Datos.Instance.AddPoints(collision.gameObject.GetComponent<EnemyMove>().puntos);
                Datos.Instance.MostrarPuntosDinamicos(collision.gameObject.GetComponent<EnemyMove>().puntos, transform.position);
            }

            //sonidoExplosion.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject,3f);

        }
    }

    // Update is called once per frame
    void Update(){

        
    }
}