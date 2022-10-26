using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    
    bool gameOver = false; //has the game ended
    
    public void EndGame()
    {

        
        if(gameOver == false)
        {

            gameOver = true;
            Debug.Log("Game Over");
            GameOver();

        }
        

    }


    void GameOver()
    {
        
        SceneManager.LoadScene("GameOver");

    }


}
