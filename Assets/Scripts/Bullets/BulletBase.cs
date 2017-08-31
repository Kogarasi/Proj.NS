
namespace NS.Bullet {
	public class BulletBase {
		public View.BulletView view;
		public virtual void move(){}

		public void setView( View.BulletView view ){
			this.view = view;
		}

	}
}