using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpspeed;
    private Rigidbody rg3d;
    private Vector3 movement;
    private int GroundType;
    //private ConstantForce constantforce;


    void Start()
    {
        GroundType = 0;
        movement = new Vector3(0f, 0f, 0f); 
        rg3d = GetComponent<Rigidbody>();
        //constantforce = GetComponent<ConstantForce>();
    }


    void FixedUpdate()
    {
        if (GroundType == 1)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            movement = new Vector3(moveX, 0f, moveZ);
            rg3d.AddForce(movement * speed);
        }
        else if (GroundType == 2)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            movement = new Vector3(moveX, 0f, moveZ);
            rg3d.velocity = 2.1f * movement;
        }
        else if (GroundType == 3)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            movement = new Vector3(-moveX, 0f, -moveZ);
            rg3d.AddForce(movement * speed * 0.8f);
        }
        else if(GroundType == 0)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            movement = new Vector3(moveX, 0f, moveZ);
            rg3d.AddForce(movement * speed * 0.05f);
        }

        if(Input.GetKey(KeyCode.LeftShift) && GroundType != 0)
        {
            movement = new Vector3(0f, -15f, 0f);
            rg3d.AddForce(movement * speed);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if(GroundType == 1 || GroundType == 2 || GroundType == 3)
            {
                rg3d.velocity = new Vector3(rg3d.velocity.x, jumpspeed, rg3d.velocity.z);
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            GroundType = 1;
        }
        else if(other.gameObject.CompareTag("GroundBlue"))
        {
            GroundType = 2;
            rg3d.useGravity = false;
        }
        else if (other.gameObject.CompareTag("GroundRed"))
        {
            GroundType = 3;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            GroundType = 0;
        }
        else if (other.gameObject.CompareTag("GroundBlue"))
        {
            GroundType = 0;
            rg3d.useGravity = true;
        }
        else if(other.gameObject.CompareTag("GroundRed"))
        {
            GroundType = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            PlayerDie();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (other.relativeVelocity.y > 10.5f || other.relativeVelocity.y < -10.5f)
            {
                PlayerDie();
            }
        }
        if (other.gameObject.CompareTag("GameOver"))
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        if(HealthManage.LiveOrNot)
        {
            tag = null;
            HealthManage.LiveOrNot = false;
            HealthManage.PlayerHealth--;
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        GameObject gameoverUI = GameObject.Find("GameOverUI");
        GameObject healthpoint = GameObject.Find("HealthPoint");
        healthpoint.GetComponent<Text>().text = "× " + HealthManage.PlayerHealth.ToString();
        Animator anim;
        anim = gameoverUI.GetComponent<Animator>();
        anim.SetTrigger("GameOverTrigger");
        yield return new WaitForSeconds(2.0f);
        anim.SetTrigger("GameOverTrigger");
        yield return new WaitForSeconds(1.0f);
        if (HealthManage.PlayerHealth == 0)
        {
            SceneManager.LoadSceneAsync("Stage1");
            HealthManage.PlayerHealth = HealthManage.BeginningHealth;
        }
        else
        {
            ItemManage.PassOrReStart = false;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
        HealthManage.LiveOrNot = true;
    }

}
