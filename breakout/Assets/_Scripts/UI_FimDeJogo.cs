using UnityEngine;
using UnityEngine.UI;
public class UI_FimDeJogo : MonoBehaviour{
    public Text message;
    GameManager gm;
    private AudioSource source;

    void Start(){
        source = GetComponent<AudioSource>();
    }


    private void OnEnable(){
    	gm = GameManager.GetInstance();
        if (gm.vidas > 0) {
            message.text = "Você Ganhou!!!";
        }
        else {
            message.text = "Você Perdeu!!";
            source.Play();
        }
    }

    public void Voltar(){
    	gm.ChangeState(GameManager.GameState.GAME);
	}
}