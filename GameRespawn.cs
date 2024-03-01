using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    public Vector3 playerPosition;
    [SerializeField] List<GameObject> checkpoints;
    [SerializeField] Vector3 vectorPoint;

    void Update()
    {
        if(transform.position.y < threshold)
        {
            GetComponent<CharacterController>().enabled = false;
            transform.position = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
            GetComponent<CharacterController>().enabled = true;
            GameManager.health -= 1;
            /*GameManager.health -= 1;
            PlayerPrefs.SetInt("Health", GameManager.health);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);*/
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            vectorPoint = other.transform.position;
            playerPosition = vectorPoint;
        }
    }

}
