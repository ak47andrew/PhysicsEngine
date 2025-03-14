namespace ks;

public abstract class PhysicsObject {
    public int Layer;
    public LayerManager LayerManager;

    public PhysicsObject(LayerManager manager, int layer) {
        Layer = layer;
        LayerManager = manager;
        manager.AddObjectToLayer(this, layer);
    }

    public abstract void Draw();
}
