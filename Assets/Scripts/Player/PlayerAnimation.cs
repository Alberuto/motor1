using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour{

    [Header("Componentes")]
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;

    private PlayerMove playerMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMove>();

    }
    // Update is called once per frame
    void Update() {

        animator.SetFloat("y", rb.linearVelocity.y);       
        animator.SetBool("enSuelo", playerMove.EnSuelo());

    }
    public void OnMove(InputValue value) {

        animator.SetFloat("x", value.Get<Vector2>().x);

    }
    public void AnimacionMuerte() {

        animator.SetTrigger("Muerte");
    
    }
    public void AnimacionDisparo(){

        animator.ResetTrigger("Disparar");
        animator.SetTrigger("Disparar");

    }
}