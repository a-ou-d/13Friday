using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Controller
{
    private bool canTakeDamage = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Enemy") && canTakeDamage)
        {           
            PlayerTakeDamage();
            
            //5ÃÊµ¿¾È TakeDamage ÇÔ¼ö ¸ØÃã
            StartCoroutine(DisableDamageForSeconds(2f));
        }
    }

    public void PlayerTakeDamage()
    {
        GameManager.Instance.DecreaseLife(1);
    }

    public IEnumerator DisableDamageForSeconds(float seconds)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(seconds);
        canTakeDamage = true;
    }
}
