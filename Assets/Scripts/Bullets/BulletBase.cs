using UnityEngine;

namespace NS.Bullet {
	public class BulletBase {
		public View.BulletView view;
		public Vector2 position = Vector2.zero;
		public virtual void move(){}

		public void setView( View.BulletView view ){
			this.view = view;
		}

	}
}