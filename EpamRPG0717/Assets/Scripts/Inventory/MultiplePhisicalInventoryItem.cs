public class MultiplePhisicalInventoryItem : AbstractPhisicalInventoryItem {

    private int quantity;


    public int Quantity {
        set {
            quantity = value;
        }

        get {
            return quantity;
        }
    }

}