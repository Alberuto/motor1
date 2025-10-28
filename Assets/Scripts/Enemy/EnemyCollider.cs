using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollider : MonoBehaviour{

    //[SerializeField] private float tiempoEspera;
    private PlayerMove playerMove;
    private PlayerAnimation playerAnimation;
    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoMorir;
    [SerializeField] private AudioSource sonidoDamage;

    private VidasJugador playerLifes;
    private bool inmune = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        playerMove = GetComponent<PlayerMove>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerLifes = GetComponent<VidasJugador>();
    }
    private void OnCollisionEnter2D(Collision2D other) {

        if (other.collider.CompareTag("Enemy")) {

            if (!inmune){
                playerLifes.RemoveLives();
                sonidoDamage.Play();
                StartCoroutine(ActivarInmunidad());
            }
            if (playerLifes.currentLives==0)
                StartCoroutine(PararYReiniciar());
        }
    }
    private IEnumerator PararYReiniciar() {

       // Time.timeScale = 0;
        sonidoMorir.Play();
        playerAnimation.AnimacionMuerte();
        playerMove.Parar();
        yield return new WaitForSecondsRealtime (5);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerator ActivarInmunidad(){

        inmune = true;
        yield return new WaitForSecondsRealtime(5);
        inmune = false;
    }
}