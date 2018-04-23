using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManage : MonoBehaviour {

    public static bool PassOrReStart = true;

    #region ItemOfStage4
    public static bool healthbox_Stage4 = true;
    #endregion
    public static void LoadItemStage4()
    {
        if(healthbox_Stage4 || PassOrReStart)
        {
            healthbox_Stage4 = true;
            Object HealthBox = Resources.Load("Perfabs/HealthBox", typeof(GameObject));
            GameObject healthbox = Instantiate(HealthBox) as GameObject;
            healthbox.transform.position = new Vector3(28f, 18f, 21f);
            healthbox.name = "healthbox_Stage4";
        }
        
    }

    #region ItemOfStage5
    public static bool healthbox_Stage5_no1 = true;
    #endregion
    public static void LoadItemStage5()
    {
        if (healthbox_Stage5_no1 || PassOrReStart)
        {
            healthbox_Stage5_no1 = true;
            Object HealthBox = Resources.Load("Perfabs/HealthBox", typeof(GameObject));
            GameObject healthbox = Instantiate(HealthBox) as GameObject;
            healthbox.transform.position = new Vector3(-30f, 7.5f, 1f);
            healthbox.name = "healthbox_Stage5_no1";
        }
    }


}
