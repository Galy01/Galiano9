using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Monete : "+ ScoreNum;
    }


    



    private void OnCollisionEnter2D(Collision2D Coin) {
        if(Coin.gameObject.tag == "Coin"){
            ScoreNum +=1;
            Destroy(Coin.gameObject);
            MyscoreText.text = "Monete : "+ ScoreNum;
        }
    }

    void Update(){
        if(ScoreNum == 15){
             SceneManager.LoadScene(2);
             //Aggiungere schermata di vittoria
        }
    }

    
}
