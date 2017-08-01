public class AbstractPhisicalInventoryItem : AbstractInventoryItem {

    private AbstractPhisicalObject phObject;

//	public abstract AbstractPhisicalObject Element { set; get;	}

    public AbstractPhisicalObject Element {
        set {
            phObject = value;
        }
        get {
            return phObject;
        }
    }

}