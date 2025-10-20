using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour{

    [Header("Disparo")]
    [SerializeField] private GameObject prefabBala;

    [SerializeField] private Transform puntoDisparoDerecha;
    [SerializeField] private Transform puntoDisparoIzquierda;

    private PlayerMove playerMove;
    private PlayerAnimation pa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        playerMove = GetComponent<PlayerMove>();
        pa = GetComponent<PlayerAnimation>();
    }

    public void OnDisparar(InputValue valor) {

        if (!valor.isPressed) 
            return;
        
        if (prefabBala == null || puntoDisparoDerecha == null || puntoDisparoIzquierda == null) 
            return;


        StartCoroutine("CorrutinaDisparo");
    }

    private IEnumerator CorrutinaDisparo() {

        if(playerMove.EnSuelo())
            pa.AnimacionDisparo();

        yield return new WaitForSecondsRealtime(0.2f);


        if (playerMove.mirandoDerecha)
            Instantiate(prefabBala, puntoDisparoDerecha.position, puntoDisparoDerecha.rotation);

        else
            Instantiate(prefabBala, puntoDisparoIzquierda.position, puntoDisparoIzquierda.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
