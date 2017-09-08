using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	namespace NS.View.Enemy {
	public class EnemyView : Sparrow.View {
		public virtual void move(){

		}

		public virtual bool isDirty(){
			return false;
		}
	}
}