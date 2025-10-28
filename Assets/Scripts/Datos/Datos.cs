using System.Collections;
using TMPro;
using UnityEngine;

public class Datos : MonoBehaviour{

    [Header("UI")] public Canvas canvas;

    public TextMeshProUGUI puntosTexto;

    public TextMeshProUGUI puntosDinamicos;

    public static Datos Instance;

    public int puntos;

    public int vidas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        if(puntosDinamicos)
            puntosDinamicos.gameObject.SetActive(false);

        ActualizarDatos();
    }
    // Update is called once per frame
    void Update(){



    }
    public void MostrarPuntosDinamicos(int punts, Vector3 posicionMundoPowerUp) {

        if (puntosDinamicos)

            puntosDinamicos.text = "+" + punts;

        //convertir el mundo - > Pantalla

        Vector3 sceenPos = Camera.main.WorldToScreenPoint(posicionMundoPowerUp + Vector3.up * 1.2f);
        puntosDinamicos.transform.position = sceenPos;

        if (sceenPos.z < 0f) {

            puntosDinamicos.gameObject.SetActive(false);
        }
        RectTransform rt = puntosDinamicos.rectTransform;

        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay) {

            rt.position = sceenPos;

        }else { 
            
            RectTransform canvasRT = canvas.transform as RectTransform;
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRT, sceenPos, canvas.worldCamera, out localPoint); 
            rt.anchoredPosition=localPoint;
        }

        puntosDinamicos.gameObject.SetActive(true);
        StartCoroutine(AnimarPuntosUI(rt));
    }
    private IEnumerator AnimarPuntosUI(RectTransform rt) {

        float duration = 0.4f;
        float t = 0f;
        Vector2 start = rt.anchoredPosition;

        while (t<duration) {
            t += Time.deltaTime;
            rt.anchoredPosition = start+new Vector2(0, t * 40f);
            yield return null;
        }

        puntosDinamicos.gameObject.SetActive(false);
    }
    public void Awake(){

        if (Instance != null && Instance != this){
            Destroy(gameObject);
            //return; puedes descomentar y quitar el else pero no me mola.
        }
        else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ActualizarDatos() { 

        if(puntosTexto)
            puntosTexto.text = "Puntuacion: "+puntos.ToString();
    }
    public void AddPoints(int points) {
        puntos += points;
        ActualizarDatos ();
    }
}