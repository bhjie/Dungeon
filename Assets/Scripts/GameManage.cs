using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour {
    public static bool IsPause = false;
    public static bool IfFinish = false;
    public static int GameModel = 1;
    public static Vector3 RevivePoint;

	public static void PauseGame()
    {
        PlayerMovement.FreezePlayer();
    }

    public static void ResumeGame()
    {
        PlayerMovement.UnFreezePlayer();
    }

    public static void RestartGame()
    {
        if(GameModel == 1)
        {
            SceneManager.LoadSceneAsync("Stage1");
            HealthManage.PlayerHealth = HealthManage.BeginningHealth;
        }
        else if(GameModel == 2)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}
