using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionHandler : MonoBehaviour
{
    [SerializeField] AudioSource audio1;
    [SerializeField] AudioSource audio2;

    [SerializeField] AudioSource audio3;

    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem successEffect;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float delay = 1;

    bool isTransitioning = false;
    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            
            case "Friendly": Debug.Log("Hey, all! You're Free to launch"); break;
            case "Fuel": Debug.Log("You got fuel"); break;
            case "Finish": Debug.Log("You delivered your cargo!"); 
                StartNewSceneSequened();
                break;
            default: Debug.Log("You crashed"); 
                StartCrashSequence();
            break;
        }
    }

    //TODO: Fix Crash / Land Sound Bug
    private void StartCrashSequence(){
        GetComponent<Movemenet>().enabled = false;
        audio1.enabled = false;
        audio2.enabled = false;
        if(!isTransitioning){
            audio3.PlayOneShot(crash);
            crashEffect.Play();
            isTransitioning = !isTransitioning;
        }
        Invoke("ReloadScene", delay/2);
    }        
    private void ReloadScene(){
        //reloads active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StartNewSceneSequened(){
        GetComponent<Movemenet>().enabled = false;
        audio1.enabled = false;
        audio2.enabled = false;
        if(!isTransitioning){
            audio3.PlayOneShot(success);
            successEffect.Play();
            isTransitioning = !isTransitioning;
        }
        Invoke("LoadNextScene", delay);
    }
    private void LoadNextScene(){
        //Load Next Scene
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene++;
        if(nextScene == SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(nextScene);
    }
}
