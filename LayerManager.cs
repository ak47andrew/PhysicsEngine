namespace ks;

public class LayerManager {
    List<List<PhysicsObject>> layers;

    public LayerManager(int numLayers) {
        layers = [];
        for (int i = 0; i < numLayers; i++)
            AddLayer();
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

    public void DrawLayer(int layer){
        foreach (PhysicsObject obj in layers[layer]) {
            obj.Draw();
        }
    }

    public void UpdateLayer(int layer, float deltaTime) {
        foreach (PhysicsObject obj in layers[layer]) {
            if (obj is MovementObject)
                ((MovementObject)obj).Update(deltaTime);
        }
    }
}
