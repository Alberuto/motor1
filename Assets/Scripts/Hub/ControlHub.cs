using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlHub : MonoBehaviour{

    public GameObject panelPrincipal;

    public void SalirJuego() {

        Application.Quit();
    
    }
    public void Load(string sceneName) {

        if (Application.CanStreamedLevelBeLoaded(sceneName)){

            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        else {

            Debug.Log($"Escena {sceneName} no encontrada");
        }
    }
    void Start(){
        
    }
    void Update(){
        
    }
}