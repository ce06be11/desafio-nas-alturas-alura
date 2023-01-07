using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTela : MonoBehaviour {

    /* Acredito que o metodo utilizado a frente nao seja a melhor opcao disponivel. E interessante tentar fazer um scroll,
     utilizando um objeto do tipo QUAD na Unity e uma textura que se repete infinitamente. Assim seria necessario apenas 
     rotacionar o objeto, tornando o codigo bem menos complexo e consequentemente mais agil. Ainda nao testei essa possibilidade,
    mas acredito que seja valido o teste. O codigo a seguir nao segue essa linha.*/

    [SerializeField] float velocidadeMovimento;
    private Vector3 direcaoMovimento;
    private Vector3 posicaoInicial;
    private float tamanhoDaImagem;

    private void Awake() {
        direcaoMovimento = Vector3.left;
        posicaoInicial = transform.position;
        //captura o tamanho da imagem no eixo x considerando o SpriteRenderer E a escala atual
        tamanhoDaImagem = GetComponent<SpriteRenderer>().size.x * transform.localScale.x;
    }

    void Update() {
        // calcula o deslocamento da imagem, considerando a velocidade que ela deve se movimentar e o tempo que o jogo comecou
        float deslocamentoImagem = Mathf.Repeat(velocidadeMovimento * Time.time, tamanhoDaImagem);
        // muda a posicao da imagem considerando a posicao inicial e somando o deslocamento anterior
        transform.position = posicaoInicial + (direcaoMovimento * deslocamentoImagem);
    }

}
