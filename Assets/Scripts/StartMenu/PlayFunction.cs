using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFunction : MonoBehaviour
{
    public Animator Crossfade;
    [SerializeField] GameObject Fade;

    void Start (){
        Fade.SetActive(false);
    }

    public void Playfunction(){

        Fade.SetActive(true);
        StartCoroutine(FadeDelay());
        Crossfade.SetTrigger("Go");  
    }

    public IEnumerator FadeDelay() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
