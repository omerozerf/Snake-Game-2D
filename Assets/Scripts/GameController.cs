using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   public void RestartGame()
   {
      Time.timeScale = 1;
      SceneManager.LoadScene(0);
      gameObject.SetActive(true);
   }
}
