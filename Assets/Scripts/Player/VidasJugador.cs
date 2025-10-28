using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasJugador : MonoBehaviour{

    [Header("Imágenes")] [SerializeField] private List<Image> hearts = new List<Image>();

    [Header("Config")][SerializeField] private int maxLives;

    public int currentLives;

    public static VidasJugador vj;

    private void Awake(){

        maxLives = Mathf.Clamp(maxLives, 0, hearts.Count);
       // RemoveLives();
        SetLives(maxLives);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }
    // Update is called once per frame
    void Update() {

    }
    private void showHearts() { 
        
    
    }
    private void SetLives(int vidas) { 
        
        currentLives = Mathf.Clamp(vidas, 0, maxLives);

        for (int i = 0; i < hearts.Count; i++){
            
            if(i>=maxLives)
                hearts[i].enabled = false; //hearts[i].gameObject.SetActive(false);
            //continue; lo mismo no hace falta
            else 
                hearts[i].enabled = true;

            hearts[i].gameObject.SetActive(i < currentLives);
        }
    }
    public void RemoveLives(){

        maxLives--;
        SetLives(currentLives);
    }
    public void AddLives(){

        maxLives++;
        SetLives(currentLives);
    }
}
