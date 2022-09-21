using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void ResetSc() /*Metodo publico chamado ResetSc que reseta a cena*/
    {
        print("Resetou");/*Printa no console para confirmar q foi reiniciado*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);/*O metodo "GetActiveScene()" retorna a cena atual e a propriedade retorna o num de cenas menos
         1(n entendi direito socorro) */
        Time.timeScale = 1f; /*Voltar o tempo do jogo, para que ele descongele quando a opcao de resetar for clicada*/
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
