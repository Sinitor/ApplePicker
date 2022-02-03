using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Basket : MonoBehaviour
{
    public float Health = 3f;
    public int score = 0;
    public Text scoreText;
    [SerializeField] private Image currentHealth;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseX = mousePosition.x;
        mouseX = Mathf.Clamp(mouseX, -7.5f, 7.5f);
        transform.position = new Vector3(mouseX, -3f, 0);
    } 
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int appleValue = collision.GetComponent<Apple>().value;
        score += appleValue; 
        scoreText.text = "Score: " + score;
        Destroy(collision.gameObject);

        if (collision.tag == "BadApple")
        {
            Health--;
            if (Health == 2)
                currentHealth.fillAmount = currentHealth.fillAmount / 1.5f;
            if (Health == 1)
                 currentHealth.fillAmount = currentHealth.fillAmount / 2f;
            if (Health < 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
