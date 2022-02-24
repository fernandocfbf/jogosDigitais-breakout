using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour{
    public int strength;
    int damage = 0;
    public bool breakable = true;

    // Start is called before the first frame update
    void Start(){
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        damage ++;
        if(damage == strength && breakable) Destroy(gameObject);
    }
}
