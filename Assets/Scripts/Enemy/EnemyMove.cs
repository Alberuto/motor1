
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    [Header("Posiciones")]
    [SerializeField] private Transform puntoA, puntoB;

    [Header("Velocidad")]
    [SerializeField] private float velocidad = 2f;

    private bool yendoHaciaB = true;

    // Update is called once per frame
    void Update(){

        Vector2 destino = yendoHaciaB ? puntoB.position : puntoA.position;
        Vector2 actual = transform.position;

        transform.position = Vector2.MoveTowards(actual, destino, velocidad * Time.deltaTime);

        if ((Vector2)transform.position == destino) {

            yendoHaciaB = !yendoHaciaB;

           // sin yendoB transform.position = Vector2.MoveTowards(destino, actual, velocidad * Time.deltaTime);
        }
    }
}