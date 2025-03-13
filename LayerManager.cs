namespace ks;

public class LayerManager {
    List<List<PhysicsObject>> layers;

    public LayerManager() {
        layers = [];
    }

    public void AddLayer (){
        layers.Add([]);
    }

    public void AddObjectToLayer(PhysicsObject obj, int layerIndex) {
        layers[layerIndex].Add(obj);
    }

    public void ClearLayer(int layerIndex) {
        layers[layerIndex].Clear();
    }

    public void RemoveObjectFromLayer(PhysicsObject obj, int layerIndex) {
        layers[layerIndex].Remove(obj);
    }
}