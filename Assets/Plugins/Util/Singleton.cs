using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util {
	public class Singleton<T> where T: class, new() {
		private T _instance;

		T instance {
			get {
				if(_instance == null ){
					_instance = new T();
				}

				return _instance;
			}
		}
	}
}