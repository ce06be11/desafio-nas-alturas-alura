using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCena : MonoBehaviour
{
    
    private ControlaAviao aviao;
    private CalculaPonto pontuacao;
    private InterfaceGameOver interfaceGameOver;

    private void Start() {
        aviao = GameObject.FindObjectOfType<ControlaAviao>();
        pontuacao = GameObject.FindObjectOfType<CalculaPonto>();
        interfaceGameOver = GameObject.FindObjectOfType<InterfaceGameOver>();
    }

    public void FinalizarJogo() {
        // coloca a velocidade do jogo como 0
        Time.timeScale = 0f;
        // salva o recorde atual
        pontuacao.SalvarRecorde();
        //chama a imagem de game over
        interfaceGameOver.MostrarInterfaceGameOver();
        
    }

    public void ReiniciarJogo() {
        interfaceGameOver.EsconderInterfaceGameOver();
        Time.timeScale = 1f;
        aviao.Reiniciar();
        DestruirObstaculos();
        pontuacao.Reiniciar();
    }

    private void DestruirObstaculos() {
      ControlaObstaculo[] obstaculos = GameObject.FindObjectsOfType<ControlaObstaculo>();
        foreach(ControlaObstaculo obstaculo in obstaculos) {
            obstaculo.DestruirObjeto();
        }
    }

}
