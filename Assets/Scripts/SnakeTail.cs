using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeTail : MonoBehaviour
{
public Transform SnakeTailGfx;
public float circleDiameter; 

private List<Transform> snakeTail = new List<Transform>();
private List<Vector2> positions = new List<Vector2>();

private void Start()
{
    positions.Add(SnakeTailGfx.position);
}

private void Update()
{
  float distance = ((Vector2) SnakeTailGfx.position-positions[0]). magnitude;

  if(distance > circleDiameter)
  {
    Vector2 direction = ((Vector2) SnakeTailGfx.position-positions[0]). normalized;
    
    positions.Insert(0, positions[0]+direction*circleDiameter);
    positions.RemoveAt(positions.Count - 1);

    distance -= circleDiameter;
  } 

  for (int i = 0; i < snakeTail.Count; i++)

  {
    snakeTail[i].position = Vector2.Lerp(positions[i+1], positions [i], distance / circleDiameter);
  }

}
 public void AddTail()
 {
  Transform tail = Instantiate(SnakeTailGfx,positions[positions.Count - 1], Quaternion.identity, transform);
  snakeTail.Add(tail);
  positions.Add(tail.position);
 }

}