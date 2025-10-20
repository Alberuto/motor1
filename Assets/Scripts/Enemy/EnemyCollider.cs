using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollider : MonoBehaviour{

    [SerializeField] private float tiempoEspera;

    private PlayerMove playerMove;
    private PlayerAnimation playerAnimation;
    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoMorir;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        playerMove = GetComponent<PlayerMove>();
        playerAnimation = GetComponent<PlayerAnimation>();

    }
    private void OnCollisionEnter2D(Collision2D other) {

        if (other.collider.CompareTag("Enemy")) {

            StartCoroutine(PararYReiniciar());

        }
    }
    private IEnumerator PararYReiniciar() {


       // Time.timeScale = 0;

        sonidoMorir.Play();

        playerAnimation.AnimacionMuerte();

        playerMove.Parar();

        yield return new WaitForSecondsRealtime (tiempoEspera);

        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}