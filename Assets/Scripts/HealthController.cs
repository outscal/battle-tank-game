using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class HealthController 
{
    private TankModel tankModel;
    private TankController tankController;
    private TextMeshProUGUI scoreText;
    private float score = 0;
    private float _score = 0;
    public HealthController(){
        getHealth();
    }
    
    // private void Awake(){
    //     scoreText = GetComponent<TextMeshProUGUI>();
        
    //     score = _score;
    // }
    private void getHealth(){
        _score = tankModel.Health;
    }

    private void Start(){
        RefreshUI();
    }

    public void IncreaseScore(int decrement){
        score -= decrement;
        RefreshUI();
    }

    private void RefreshUI(){
       
        scoreText.text = "score: "+ score;
    }
}
