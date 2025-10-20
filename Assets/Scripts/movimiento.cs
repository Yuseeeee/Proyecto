using UnityEngine;

public class PersonajeMov : MonoBehaviour
{
    public float speed = 5f;
	public float rotationSpeed = 200f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v) * speed * Time.deltaTime;
        transform.Translate(move, Space.Self);


		float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);
    }
}
