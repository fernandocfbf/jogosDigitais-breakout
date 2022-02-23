using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour{
    public int strength;
    int damage = 0;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (strength - damage == 1) 
            transform.GetComponent<Renderer>().material.color = new Color(0, 255, 255);
        else if (strength - damage == 2) 
            transform.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
        else 
            transform.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

    }

    private void OnTriggerEnter2D(Collider2D collision){
        damage ++;
        if(damage == strength) Destroy(gameObject);
    }
}
