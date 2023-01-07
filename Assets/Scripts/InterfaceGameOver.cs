using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGameOver : MonoBehaviour {

    [SerializeField] private GameObject imagemGameOver;
    [SerializeField] private Text valorRecorde;

    public void MostrarInterfaceGameOver() {
        AtualizarInterfaceGrafica();
        imagemGameOver.SetActive(true);

    }
    public void EsconderInterfaceGameOver() {
        imagemGameOver.SetActive(false);
    }

    private void AtualizarInterfaceGrafica() {
        // transfere o valor salvo pelo playerprefs para o arquivo texto em formato de string
      valorRecorde.text = PlayerPrefs.GetInt("recorde").ToString();
    }
}
