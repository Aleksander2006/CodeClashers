using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTrigger : MonoBehaviour {

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
