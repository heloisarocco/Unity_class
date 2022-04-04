using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer_topDown : MonoBehaviour
{
    Rigidbody2D fisica;
    public float velocidade = 10;
    Vector2 positionToMove;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //getaxisRAW = sem uma aceleracao, vai direto para o 1
        float controleH = Input.GetAxis("Horizontal");
        float controleV = Input.GetAxis("Vertical");
        //normalized limita os valores para -1 e e. Assim nao fica mais rapido andando na diagonal.
        fisica.velocity = new Vector2(controleH, controleV).normalized * velocidade;

        //if eu clicar com o botão direito, ele guarda a posição do mouse
        if (Input.GetMouseButton(0))
        {
            
        //ScreenToWorldPoint < tela para unity (x,y > x,y,z)
            positionToMove = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //imprimir a posicao do mouse no console da unity
            print(positionToMove);
            
        //lerp = interpola uma posicao
        //ele vai de uma posicao a outra SUAVE
        //Time.deltatime * xf = intervalo de tempo entre uma posição e outra    
        }
        transform.position = Vector2.Lerp(transform.position, positionToMove, Time.deltaTime * 3f );
    }
}