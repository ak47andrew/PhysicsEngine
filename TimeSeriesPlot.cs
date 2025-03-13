using Raylib_cs;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ks;

public class TimeSeriesPlot
{
    private List<float> _data = new List<float>();
    private Rectangle _bounds;
    private Color _lineColor;
    private string _label;
    private int _maxHistory;

    public TimeSeriesPlot(Rectangle bounds, Color color, string label, int maxHistory = 1652 * 3)
    {
        _bounds = bounds;
        _lineColor = color;
        _label = label;
        _maxHistory = maxHistory;
    }

    public void AddDataPoint(float value)
    {
        _data.Add(value);
        TrimHistory();
    }

    public void Draw()
    {
        // Draw background and border
        Raylib.DrawRectangleRec(_bounds, Color.White);
        Raylib.DrawRectangleLinesEx(_bounds, 1, Color.Black);

        if (_data.Count < 2) return;

        // Calculate plot bounds
        float minVal = _data.Min();
        float maxVal = _data.Max();
        if (minVal == maxVal)
        {
            maxVal += 1;
            minVal -= 1;
        }

        float xStep = _bounds.Width / (_data.Count - 1);
        float yScale = _bounds.Height / (maxVal - minVal);

        // Draw data lines
        for (int i = 1; i < _data.Count; i++)
        {
            float x1 = _bounds.X + (i - 1) * xStep;
            float y1 = _bounds.Y + _bounds.Height - (_data[i - 1] - minVal) * yScale;
            float x2 = _bounds.X + i * xStep;
            float y2 = _bounds.Y + _bounds.Height - (_data[i] - minVal) * yScale;
            
            Raylib.DrawLineV(new Vector2(x1, y1), new Vector2(x2, y2), _lineColor);
        }

        // Draw label
        Raylib.DrawText(_label, (int)_bounds.X + 5, (int)_bounds.Y + 5, 12, Color.Black);
    }

    private void TrimHistory()
    {
        while (_data.Count > _maxHistory)
        {
            _data.RemoveAt(0);
        }
    }
}
