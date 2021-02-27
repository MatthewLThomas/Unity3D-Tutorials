using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            
            case "Friendly": Debug.Log("Hey, all! You're Free to launch"); break;
            case "Fuel": Debug.Log("You got fuel"); break;
            case "Finish": Debug.Log("You delivered your cargo!"); 
                LoadNextScene();
                break;
            default: Debug.Log("You crashed"); 
                ReloadScene();
            break;
        }
    }

    private void ReloadScene(){
        //reloads active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
