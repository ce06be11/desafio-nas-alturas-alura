using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlaAviao : MonoBehaviour {
    private Rigidbody2D fisica;
    [SerializeField] private float forcaImpulso;
    private ControlaCena controlaCena;
    private Vector3 posicaoInicial;
    private bool deveImpulsionar;

    private void Awake() {
        // atribui a variavel "fisica" o metodo GetComponent
        this.fisica = GetComponent<Rigidbody2D>();
        posicaoInicial = transform.position;
    }

    private void Start() {
        controlaCena = GameObject.FindObjectOfType<ControlaCena>();
    }

    private void Update() {
         if (Input.GetButtonDown("Fire1")) {
            deveImpulsionar = true;
        }
        
    }

    private void FixedUpdate() {
        // testa se o jogador clica com o mouse
        if (deveImpulsionar) {
            this.Impulsionar();
        }
    }

    // gera um impulso para cima 
    private void Impulsionar() {
        //zera a forca para que ela nao se acumule com diversos cliques
        fisica.velocity = Vector2.zero;
        fisica.AddForce(Vector2.up * forcaImpulso, ForceMode2D.Impulse);
        deveImpulsionar = false;
    }

    // metodo chamado sempre que a unity detectar uma colisao com o objeto
    private void OnCollisionEnter2D(Collision2D colisao) {
        fisica.simulated = false;
        controlaCena.FinalizarJogo();
    }

    public void Reiniciar() {
        transform.position = posicaoInicial;
        fisica.simulated = true;
    }

}
