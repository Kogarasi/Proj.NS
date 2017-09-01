using System;
using UnityEngine;

namespace NS.Bullet {
	public class BulletBase {
		public View.BulletView view;
		public Vector2 position = Vector2.zero;

		public Type viewType;

		public BulletBase(){
			viewType = default(Type);
		}

		public virtual void move(){}
		public virtual bool isDirty(){
			return false;
		}


		public void setView( View.BulletView view ){
			this.view = view;
		}

	}
}