using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {

    public Animator Crossfade;
    public int sceneBuildIndex; 

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Character"){
            StartCoroutine(FadeDelay());
            Crossfade.SetTrigger("Go");
        } 
    }

    private IEnumerator FadeDelay() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
