using System;

namespace NS.Bullet {
	public class Bullet<T, U> : BulletBase where T: Bullet<T,U> where U: View.BulletView {
		public Bullet(){
			viewType = typeof( U );
		}
	}
}