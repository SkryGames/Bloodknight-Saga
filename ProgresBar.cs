using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgresBar : MonoBehaviour{

    public int maximum;
    public int current;
    public Image mask;

    private void Update(){
        GatCurrentFill();
    }

    public void UpdateHealth(int health){
        current = health;
    }

    void GatCurrentFill(){
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
