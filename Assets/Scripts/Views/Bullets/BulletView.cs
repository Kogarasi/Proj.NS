namespace NS.View.Bullet {
	public class BulletView : Sparrow.View {
		public virtual void move(){}
		public virtual bool isDirty(){
			return false;
		}
	}
}