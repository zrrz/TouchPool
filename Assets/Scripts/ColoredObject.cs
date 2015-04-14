using UnityEngine;
using System.Collections;

public class ColoredObject : MonoBehaviour {

	[System.Serializable]
	public enum ColorType {
		Red, Blue, Green, Purple
	}

	public ColorType color;
}
