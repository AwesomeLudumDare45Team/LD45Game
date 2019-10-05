using UnityEngine;

public enum Direction { UP, DOWN, RIGHT, LEFT }

public class Boundaries
{
    public Vector2 m_minPosition;
    public Vector2 m_maxPosition;

    public Boundaries()
    {
        m_minPosition = Vector2.zero;
        m_maxPosition = Vector2.zero;
    }
    public Boundaries(Vector2 _minPosition, Vector2 _maxPosition)
    {
        m_minPosition = _minPosition;
        m_maxPosition = _maxPosition;
    }

    public bool IsInBoundaries(Vector2 _position, float _offset = 0)
    {
        return IsInBoundaries(_position, new Vector2(_offset, _offset));
    }

    public bool IsInBoundaries(Vector2 _position, Vector2 _offset)
    {
        return (DistanceToBoundary(Direction.UP, _position, _offset) > 0) 
            && (DistanceToBoundary(Direction.DOWN, _position, _offset) > 0)
            && (DistanceToBoundary(Direction.RIGHT, _position, _offset) > 0)
            && (DistanceToBoundary(Direction.LEFT, _position, _offset) > 0);
    }

    // positive value -> is inside / negative -> is outside
    public float DistanceToBoundary(Direction _direction, Vector2 _position, float _offset = 0)
    {
        return DistanceToBoundary(_direction, _position, new Vector2(_offset, _offset));
    }

    // positive value -> is inside / negative -> is outside
    public float DistanceToBoundary(Direction _direction, Vector2 _position, Vector2 _offset)
    {
        float result = 0;

        switch (_direction)
        {
            case Direction.UP:
                result = m_maxPosition.y + _offset.y - _position.y;
                break;
            case Direction.DOWN:
                result = - m_minPosition.y - _offset.y + _position.y;
                break;
            case Direction.RIGHT:
                result = m_maxPosition.x + _offset.x - _position.x;
                break;
            case Direction.LEFT:
                result = -m_minPosition.x - _offset.x + _position.x;
                break;
            default:
                break;
        }

        return result;
    }
}
