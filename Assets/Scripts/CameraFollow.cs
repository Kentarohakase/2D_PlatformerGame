using UnityEngine;

[RequireComponent( typeof( Camera ) )]
public class CameraFollow : MonoBehaviour {
 [SerializeField]
 private Transform target; // Das Ziel, dem die Kamera folgen soll

 [SerializeField, Range( 0.01f , 1.0f )]
 private float smoothSpeed = 0.5f; // Geschwindigkeit der Glättung

 [SerializeField]
 private Vector3 offset; // Versatz der Kamera zum Ziel

 [SerializeField]
 private bool lookAtTarget = false; // Soll die Kamera das Ziel ansehen?

 private void FixedUpdate( )
 {
  if (target == null)
  {
   return;
  }


  Vector3 desiredPosition = target.position + offset;
  Vector3 smoothedPosition = Vector3.Lerp( transform.position , desiredPosition , smoothSpeed );
  transform.position = smoothedPosition;

  if (lookAtTarget)
  {
   transform.LookAt( target );
  }
 }
}
