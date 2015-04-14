using UnityEngine;
using System.Collections;

[System.Serializable]
public class Ball : ColoredObject {
	
	bool mouseDown = false;

	public LayerMask mask;

	void OnMouseDown() {
		mouseDown = true;
	}

	void Update() {
		if(mouseDown && Input.GetButtonUp("Fire1")) {
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 40f, ~LayerMask.NameToLayer("RaycastPlane"))) {
				Vector3 dir = hit.point - transform.position;
				GetComponent<Rigidbody2D>().AddForce(dir * 100f);
				mouseDown = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		Edge edge = col.gameObject.GetComponent<Edge>();
		if(null != edge) {
			Debug.Log(edge.color + " " + color);
			if(edge.color == color) {
				Destroy(col.gameObject);
			}
		}
	}
}
