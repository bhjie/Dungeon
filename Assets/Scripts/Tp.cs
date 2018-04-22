using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tp : MonoBehaviour {
    public string NextStage;
    public GameObject FinishUI;
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(GameManage.GameModel == 2 || SceneManager.GetActiveScene().name == "Stage8")
            {
                Rigidbody rg3d = other.gameObject.GetComponent<Rigidbody>();
                rg3d.velocity = new Vector3(0, 0, 0);
                rg3d.constraints = RigidbodyConstraints.FreezePosition;
                StageFinish.IfFinish = true;
                FinishUI.SetActive(true);
            }
            else if (GameManage.GameModel == 1)
            {
                ItemManage.PassOrReStart = true;
                SceneManager.LoadSceneAsync(NextStage);
            }
        }
    }
}
