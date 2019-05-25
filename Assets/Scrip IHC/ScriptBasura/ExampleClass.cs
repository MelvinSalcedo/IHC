using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//agrandar una imagen por interpolacion Bilineal y prefilado de una imagen

public class ExampleClass : MonoBehaviour
{
	// detects when the other transform is closer than closeDistance
	// this is faster than using Vector3.magnitude
	public Transform other;
	public float closeDistance = 5.0f;

	void Start(){
		Vector3 a = new Vector3 (4,4,4);
		Vector3 b = new Vector3 (2,2,2);

		Vector3 r = a-b;;
		print ("r "+r);
		float LenSqr = r.sqrMagnitude;
		print (LenSqr);
	}
	void Update()
	{
		//print(this.transform.position+" "+other.position);
			Vector3 offset = other.position - transform.position;
			float sqrLen = offset.sqrMagnitude;
		//print(sqrLen +" "+closeDistance*closeDistance	);
			// square the distance we compare with
			if (sqrLen < 1)
			{
				print("The other transform is close to me!");
			}
	}
}