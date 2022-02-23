using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour{
  public GameObject Bloco;
  public Sprite Inimigo1;
  public Sprite Inimigo2;
  public Sprite Inimigo3;
  GameManager gm;
  GameObject newObject;
  int randomSpaceShip = 0;
  Sprite randomSprite;

  void Start(){
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += Construir;
  }

  void Construir(){
       if (gm.gameState == GameManager.GameState.GAME){
          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }
          for(int i = 1; i < 10; i++){
              for(int j = 0; j < 4; j++){
                  randomSpaceShip = SetSpaceShipe();
                  randomSprite = GetSpaceShipeLevel(randomSpaceShip);
                  Vector3 posicao = new Vector3(-9 + 1.75f * i, 4 - 1.3f * j);
                  newObject = Instantiate(Bloco, posicao, Quaternion.identity, transform);
                  newObject.GetComponent<Bloco>().strength = randomSpaceShip;
                  newObject.GetComponent<SpriteRenderer>().sprite = randomSprite;
            }
          }
      }
  }

  private int SetSpaceShipe(){
    int chooseNumber = Random.Range(1, 4);
    return chooseNumber;
  }

  private Sprite GetSpaceShipeLevel(int num){
      if (num == 1) return Inimigo1; //color 1
      else if (num == 2) return Inimigo2; //color 2
      return Inimigo3; //color 3
  }

  void Update(){
      if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME){
          Construir();
      }
  }
}

