using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddHealth : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.name)
        {
            case "healthbox_Stage4":
                {
                    ItemManage.healthbox_Stage4 = false;
                    break;
                }
            case "healthbox_Stage5_no1":
                {
                    ItemManage.healthbox_Stage5_no1 = false;
                    break;
                }
        }

        HealthManage.PlayerHealth++;
        this.gameObject.SetActive(false);
        GameObject healthpoint = GameObject.Find("HealthPoint");
        healthpoint.GetComponent<Text>().text = "× " + HealthManage.PlayerHealth.ToString();
    }
}
