using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpspeed;
    private static Rigidbody rg3d;
    private Vector3 movement;
    private int GroundType;
    static Vector3 FrozenSpeed;
    static Vector3 FrozenAngularSpeed;

    void Start()
    {
        HealthManage.LiveOrNot = true;
        GroundType = 0;
        movement = new Vector3(0f, 0f, 0f); 
        rg3d = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if(HealthManage.LiveOrNot)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            movement = new Vector3(moveX, 0f, moveZ);
            movement = movement.normalized;
            movement = Quaternion.AngleAxis(CameraController.RotationOffsetY, Vector3.up) * movement;
            if (GroundType == 1)
            {
                rg3d.AddForce(movement * speed);
            }
            else if (GroundType == 2)
            {
                rg3d.velocity = 1.8f * movement;
            }
            else if (GroundType == 3)
            {
                rg3d.AddForce(-movement * speed * 0.8f);
            }
            else if (GroundType == 0)
            {
                rg3d.AddForce(movement * speed * 0.05f);
            }

            if (Input.GetKey(KeyCode.LeftShift) && GroundType != 0)
            {
                movement = new Vector3(0f, -15f, 0f);
                rg3d.AddForce(movement * speed);
            }


            if (Input.GetKey(KeyCode.Space))
            {
                if (GroundType == 1 || GroundType == 2 || GroundType == 3)
                {
                    rg3d.velocity = new Vector3(rg3d.velocity.x, jumpspeed, rg3d.velocity.z);
                }
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
            tag = "GameOver";
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
        yield return new WaitForSeconds(1.5f);
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
        
    }

    public static void FreezePlayer()
    {
        FrozenAngularSpeed = rg3d.angularVelocity;
        FrozenSpeed = rg3d.velocity;
        rg3d.constraints = RigidbodyConstraints.FreezeAll;
        
    }

    public static void UnFreezePlayer()
    {
        rg3d.constraints = RigidbodyConstraints.None;
        rg3d.velocity = FrozenSpeed;
        rg3d.angularVelocity = FrozenAngularSpeed;
    }
}
