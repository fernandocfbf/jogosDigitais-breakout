using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    public GameObject Bloco; 

    // Start is called before the first frame update
    void Start()
    {
        CreateObjects();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void CreateObjects(){
        if(GameObject.Find("Bloco") == null){
            for(int i = 2; i < 9; i++){
                for(int j = 0; j < 4; j++){
                    Vector3 posicao = new Vector3(-9 + 1.8f * i, 4 - 0.75f * j);
                    Instantiate(Bloco, posicao, Quaternion.identity, transform);
                }
            }
        }
    }

    
}
