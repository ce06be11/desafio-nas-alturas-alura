using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraObstaculo : MonoBehaviour {

    [SerializeField]
    private float tempoDeGeracao;
    private float contadorDeGeracao;
    [SerializeField]
    private GameObject obstaculo;

    private void Awake() {
        contadorDeGeracao = tempoDeGeracao;
    }

    void Update() {
        //tira o tempo que passou desde a ultima atualizacao dele mesmo
        contadorDeGeracao -= Time.deltaTime;
        // ao chegar em zero, instancia um novo obstaculo na posicao e rotacao indicada
        if (contadorDeGeracao <= 0) {
            GameObject.Instantiate(obstaculo, transform.position, Quaternion.identity);
            contadorDeGeracao = tempoDeGeracao;
        }
    }

}
