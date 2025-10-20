using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour{

    [Header("Movimiento")][SerializeField] //aun siendo privada la variable vM se puede acceder desde inspector
    
    private float velocidadMovimiento=6f;
    private Vector2 entradaMovimiento;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public bool mirandoDerecha=true;
    private bool enSuelo = true;
    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoSalto;
    [SerializeField] private AudioSource sonidoAndar;

    public bool EnSuelo() {

        return enSuelo;
    
    }

    [Header("Salto")] [SerializeField] private float fuerzaSalto=7f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();

    }
    public void OnMove(InputValue valor) {

        entradaMovimiento = valor.Get<Vector2>();
        if (entradaMovimiento.x > 0 && !mirandoDerecha)
            Girar(false);
        else if (entradaMovimiento.x < 0 && mirandoDerecha)
            Girar(true);

    }
    private void FixedUpdate(){

        var v = rb.linearVelocity;
        v.x = entradaMovimiento.x*velocidadMovimiento;
        rb.linearVelocity = v;

    }
    private void Girar(bool aIzquierda) { 
    
        mirandoDerecha = !mirandoDerecha;
        if (sprite)
            sprite.flipX = aIzquierda;
    }
    private void OnCollisionEnter2D(Collision2D other){

        if (other.gameObject.CompareTag("Suelo")) {

            enSuelo = true;
        }        
    }
    private void OnCollisionExit2D(Collision2D other){

        if (other.gameObject.CompareTag("Suelo")){

            enSuelo = false;
        }
    }
    public void Parar() {

      GetComponent<PlayerInput>().enabled = false;
    
    }
    public void OnJump(InputValue valor) {

        if (!enSuelo)
            return;

        var v = rb.linearVelocity;
        v.y = 0f;
        rb.linearVelocity = v;
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        if(!sonidoSalto.isPlaying)
            sonidoSalto.Play();

        //Debug.Log(valor);
    }
    // Update is called once per frame consume recursos
    void Update(){

        bool estaAndando = Mathf.Abs(entradaMovimiento.x)>0.1 && enSuelo;

        if (estaAndando) {
            if (!sonidoAndar.isPlaying) {

                sonidoAndar.Play();
            }
        }
        else{
            if (sonidoAndar.isPlaying)
                sonidoAndar.Stop();
        }
        /* if (entradaMovimiento.x > 0 && !mirandoDerecha)
             Girar(false);
         else if(entradaMovimiento.x<0 && mirandoDerecha)
             Girar(true);
        */
    }
}