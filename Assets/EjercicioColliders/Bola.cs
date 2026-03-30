using UnityEngine;

public class Bola : MonoBehaviour
{
	public float fuerza = 500f;
	public float rotacion = 100f;
	public float limiteCaida = -5f;

	Vector3 posicionInicial;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		posicionInicial = transform.position;
	}

	void Update()
	{
		// ROTAR (apuntar)
		float h = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up * h * rotacion * Time.deltaTime);

		// LANZAR
		if (Input.GetButtonDown("Jump")) // Espacio
		{
			rb.AddForce(transform.forward * fuerza, ForceMode.Impulse);
		}

		// REINICIO si cae
		if (transform.position.y < limiteCaida)
		{
			Reiniciar();
		}
	}

	void Reiniciar()
	{
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		transform.position = posicionInicial;
		transform.rotation = Quaternion.identity;
	}
}