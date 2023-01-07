using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculaPonto : MonoBehaviour
{

    private int pontuacao;
    [SerializeField] private Text textoPontuacao;
    private AudioSource audioPontuacao;

    private void Awake() {
        audioPontuacao = GetComponent<AudioSource>();
    }

    public void AdicionarPontos() {
        pontuacao++;
        textoPontuacao.text = pontuacao.ToString();
        audioPontuacao.Play();
    }

    public void Reiniciar() {
        pontuacao = 0;
        textoPontuacao.text = pontuacao.ToString();
    }

    public void SalvarRecorde() {
        //salva a pontuacao no disco usando a chave recorde como tipo int
        if (PlayerPrefs.GetInt("recorde") < pontuacao) {
            PlayerPrefs.SetInt("recorde", pontuacao);
        }
    }

}
