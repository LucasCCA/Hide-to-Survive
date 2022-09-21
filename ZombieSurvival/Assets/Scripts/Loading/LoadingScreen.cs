using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen instance;/*Isso eh um singleton(instancia unica dessa classe)*/
    private AsyncOperation currentOperation;/*Referencia da instancia do carregamento atual que foi retornado pelo LoadSceneAsync*/

    private void Awake()/*Quando o objeto eh instanciado na cena*/
    {
        instance = this;/*Atribuir esta instancia ao campo da instancia unica */
        DontDestroyOnLoad(this.gameObject);/*Marcamos o objeto para que nao seja destruido na mudanca de cena*/
    }

    public void ChangeScene(string sceneName)/*o sceneName vai ser fornecido por quem chamar essa funcao*/
    {
        SceneManager.LoadScene("Carregando");/*Chamar a cena de carregamento*/
        StartCoroutine(LoadingSceneCoroutine(sceneName));/*Iniciar uma coroutine(executa um metodo de forma simultanea)*/
    }


    IEnumerator LoadingSceneCoroutine(string sceneName)/*coroutine precisa ter acesso ao sceneName*/
    {
        yield return null;/*Pular frame para que nao seja iniciado o carregamento da cena "Carregando" juntamente com a cena a ser carregada*/
        currentOperation = SceneManager.LoadSceneAsync(sceneName);/*Inicia o carregamento da cena e guardamos a operacao retornada*/
        currentOperation.allowSceneActivation = false;/*Impedir que a cena abra no momento em que ela terminar de carregar, pra proporcionar um delay antes de abrir a cena*/
        while (!currentOperation.isDone)/*A cada frame checa se carregou, caso contrario espera mais um frame e checa de novo*/
        {
            /*Se allowSceneActivation = false, o progresso de carregamento para nos 90%
            Entao se o progresso for maior ou igual a 90%, sera utilizado o yield return para esperar "no min" 1 segundo
            antes de permitir que a cena termine de ser carregada*/
            if (currentOperation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(3f);
                currentOperation.allowSceneActivation = true;
            }
            yield return null;/*Pular mais um frame*/
        }

    }

}