using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
   public float scaleAmount = 0.1f; // Количество, на которое увеличивается объект при соприкосновении с едой

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Food"))
       {
        transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
            Debug.Log("Объект увеличился");
       }
   }
}
