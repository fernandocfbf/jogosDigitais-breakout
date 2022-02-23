using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour{
  public GameObject Bloco;
  GameManager gm;
  GameObject newObject;
  int randomColor = 0;
  int[] spritColor;

  void Start(){
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += Construir;
  }

  void Construir(){
       if (gm.gameState == GameManager.GameState.GAME){
          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }
          for(int i = 2; i < 10; i++){
              for(int j = 0; j < 4; j++){
                  randomColor = SetColor();
                  spritColor = GetColorPattern(randomColor);
                  Vector3 posicao = new Vector3(-9 + 1.55f * i, 4 - 0.8f * j);
                  newObject = Instantiate(Bloco, posicao, Quaternion.identity, transform);
                  newObject.GetComponent<Renderer>().material.color = new Color(spritColor[0], spritColor[1], spritColor[2]);
                  newObject.GetComponent<Bloco>().strength = randomColor;
            }
          }
      }
  }

  private int SetColor(){
    int chooseNumber = Random.Range(1, 4);
    return chooseNumber;
  }

  private int[] GetColorPattern(int num){
      if (num == 1) return new int[] {0, 0, 0}; //color 1
      else if (num == 2) return new int[] {255, 0, 0}; //color 2
      return new int[] {0, 0, 255}; //color 3
  }

  void Update(){
      if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME){
          Construir();
      }
  }
}

