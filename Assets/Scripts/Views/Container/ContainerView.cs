using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS.View.Container {
	public class ContainerView<T> : Sparrow.View where T: MonoBehaviour {
		public static ContainerView<T> instance;
		void Awake () {
			instance = this;
		}
		
		void OnDestroy(){
			instance = null;
		}
	}
}