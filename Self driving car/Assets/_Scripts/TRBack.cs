using UnityEngine;
using System.Collections;

public class TRBack : MonoBehaviour {
		public Light Red ;
		public Light Green;
		public Light Yellow ;
		void Start() {
			StartCoroutine(Red1());
		}

		IEnumerator Gren() {
			Yellow.enabled = false;
			Green.enabled = true;
			Red.enabled = false;
			yield return new WaitForSeconds(15);
			StartCoroutine(Yellow1());

		}
		IEnumerator Yellow1() {
			Yellow.enabled = true;
			Green.enabled = false;
			Red.enabled = false;
			yield return new WaitForSeconds(5);
			StartCoroutine(Red1());

		}
		IEnumerator Red1() {
			Yellow.enabled = false;
			Green.enabled = false;
			Red.enabled = true;
			yield return new WaitForSeconds(15);
		StartCoroutine(Yellow2());

		}
	IEnumerator Yellow2() {
		Yellow.enabled = true;
		Green.enabled = false;
		Red.enabled = false;
		yield return new WaitForSeconds(5);
		StartCoroutine(Gren());
	}
}


