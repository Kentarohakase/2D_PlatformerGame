using UnityEngine;

public class PlayerMovement : MonoBehaviour {

 public float speed = 5.0f;
 public float jumpForce = 10.0f;
 private Rigidbody2D rb;
 private bool isGrounded;

 // Start is called before the first frame update
 void Start( )
 {
  rb = GetComponent<Rigidbody2D>( );
 }

 // Update is called once per frame
 void Update( )
 {
  Move( );
  if (Input.GetButtonDown( "Jump" ) && isGrounded)
  {
   Jump( );
  }
 }

 void Move( )
 {
  float moveInput = Input.GetAxis( "Horizontal" );
  rb.velocity = new Vector2( moveInput * speed , rb.velocity.y );
 }

 void Jump( )
 {
  rb.AddForce( new Vector2( 0f , jumpForce ) , ForceMode2D.Impulse );
 }

 // Diese Methode setzt isGrounded auf true, wenn der Spieler den Boden berührt
 private void OnCollisionEnter2D( Collision2D collision )
 {

  if (collision.gameObject.CompareTag( "Ground" ))
  {
   isGrounded = true;
  }
 }

 // Diese Methode setzt isGrounded auf false, wenn der Spieler den Boden verlässt
 private void OnCollisionExit2D( Collision2D collision )
 {
  if (collision.gameObject.CompareTag( "Ground" ))
  {
   isGrounded = false;
  }
 }
}
