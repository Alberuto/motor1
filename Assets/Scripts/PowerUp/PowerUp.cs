using UnityEngine;

public class PowerUp : MonoBehaviour{

    [Header("Puntuacion")] public int puntosPowerUp = 10;
    [Header("Audio")] public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        var rb = GetComponent<Rigidbody2D>();
        if (rb != null) {

            rb.gravityScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Player")) {

            Datos.Instance.AddPoints(puntosPowerUp);
            Datos.Instance.MostrarPuntosDinamicos(puntosPowerUp, transform.position);

            if (audioSource != null) {
                audioSource.Play();
                Destroy(gameObject,audioSource.clip.length);
            }
            else
                Destroy(gameObject);
        }   
    }
    // Update is called once per frame
    void Update(){

    }
}