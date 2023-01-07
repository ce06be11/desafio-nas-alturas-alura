using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaObstaculo : MonoBehaviour {

    private Vector3 direcaoMovimento;
    [SerializeField] private float velocidadeMovimento = 0.05f;
    [SerializeField] private float variacaoPosicaoY;
    private Vector3 posicaoAviao;
    private bool pontuei;
    private CalculaPonto pontuacao;

    private void Awake() {
        direcaoMovimento = Vector3.left;
        transform.Translate(Vector3.up * Random.Range(-variacaoPosicaoY, variacaoPosicaoY));
    }

    private void Start() {
        posicaoAviao = GameObject.FindObjectOfType<ControlaAviao>().transform.position;
        pontuacao = GameObject.FindObjectOfType<CalculaPonto>(); 
    }

    private void Update() {
        // movimenta o obstaculo para a esquerda
        transform.Translate(direcaoMovimento * velocidadeMovimento * Time.deltaTime);
        if (!pontuei && transform.position.x < posicaoAviao.x) {
            pontuei = true;
            pontuacao.AdicionarPontos();
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao) {
        DestruirObjeto();
    }

    public void DestruirObjeto() {
        GameObject.Destroy(gameObject);
    }

}
