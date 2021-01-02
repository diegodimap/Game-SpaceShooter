using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour {

    public void startGame() {
        //Application.LoadLevel(1);
        SceneManager.LoadScene("level1");
    }
    public void playAgain() {
        //Application.LoadLevel(0);
        SceneManager.LoadScene("menu");
    }
    public void winGame() {
        //Application.LoadLevel("win");
        SceneManager.LoadScene("win");
    }
    public static void winGame2() {
        //Application.LoadLevel("win");
        SceneManager.LoadScene("win");
    }
    public void loseGame() {
        //Application.LoadLevel("lose");
        SceneManager.LoadScene("lose");
    }
    public static void loseGame2() {
        //Application.LoadLevel("lose");
        SceneManager.LoadScene("lose");
    }
    public void quitGame() {
        Application.Quit();   
    }
}
