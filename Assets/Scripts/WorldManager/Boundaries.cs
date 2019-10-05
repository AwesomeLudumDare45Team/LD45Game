using UnityEngine;

[System.Serializable]
public enum Direction { UP, DOWN, RIGHT, LEFT }

[System.Serializable]
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

    public bool IsInBoundariesAll(in Vector2 _position, float _offset = 0)
    {
        return IsInBoundariesAll(_position, new Vector2(_offset, _offset));
    }

    public bool IsInBoundariesAll(in Vector2 _position, in Vector2 _offset)
    {
        return IsInBoundaries(Direction.UP, _position, _offset) 
            && IsInBoundaries(Direction.DOWN, _position, _offset)
            && IsInBoundaries(Direction.RIGHT, _position, _offset)
            && IsInBoundaries(Direction.LEFT, _position, _offset);
    }

    public bool IsInBoundaries(Direction _direction, in Vector2 _position, float _offset = 0)
    {
        return IsInBoundaries(_direction, _position, new Vector2(_offset, _offset));
    }
    public bool IsInBoundaries(Direction _direction, in Vector2 _position, Vector2 _offset)
    {
        return DistanceToBoundary(_direction, _position, _offset) > 0;
    }

    // positive value -> is inside / negative -> is outside
    // offset positif -> inside / offset negatif -> outside
    public float DistanceToBoundary(Direction _direction, in Vector2 _position, float _offset = 0)
    {
        return DistanceToBoundary(_direction, _position, new Vector2(_offset, _offset));
    }

    // positive value -> is inside / negative -> is outside
    // offset positif -> inside / offset negatif -> outside
    public float DistanceToBoundary(Direction _direction, in Vector2 _position, in Vector2 _offset)
    {
        float result = 0;

        switch (_direction)
        {
            case Direction.UP:
                result = m_maxPosition.y - _offset.y - _position.y;
                break;
            case Direction.DOWN:
                result = - m_minPosition.y - _offset.y + _position.y;
                break;
            case Direction.RIGHT:
                result = m_maxPosition.x - _offset.x - _position.x;
                break;
            case Direction.LEFT:
                result = -m_minPosition.x - _offset.x + _position.x;
                break;
            default:
                break;
        }

        return result;
    }

    // offset positif -> inside / offset negatif -> outside
    public Vector3 SnapPosition(Direction _direction, in Vector3 _position, float _offset = 0)
    {
        return SnapPosition(_direction, _position, new Vector2(_offset, _offset));
    }

    // offset positif -> inside / offset negatif -> outside
    public Vector3 SnapPosition(Direction _direction, in Vector3 _position, in Vector2 _offset)
    {
        Vector3 snapPosition = _position;
        Vector2 delta = _offset;

        // Manage offset
        if(_direction == Direction.UP || _direction == Direction.DOWN)
        {
            delta.x = 0;
            if (_direction == Direction.UP)
                delta.y = -delta.y;
        }

        if (_direction == Direction.RIGHT || _direction == Direction.LEFT)
        {
            delta.y = 0;
            if (_direction == Direction.RIGHT)
                delta.x = -delta.x;
        }

        // Add offset to value
        switch (_direction)
        {
            case Direction.UP:
                snapPosition.y = m_maxPosition.y + delta.y;
                break;
            case Direction.DOWN:
                snapPosition.y = m_minPosition.y + delta.y;
                break;
            case Direction.RIGHT:
                snapPosition.x = m_maxPosition.x + delta.x;
                break;
            case Direction.LEFT:
                snapPosition.x = m_minPosition.x + delta.x;
                break;
            default:
                break;
        }

        return snapPosition;
    }

    public Vector3 WrapPositionAll(in Vector3 _position, float _offset = 0)
    {
        return WrapPositionAll(_position, new Vector2(_offset, _offset));
    }

    public Vector3 WrapPositionAll(in Vector3 _position, in Vector2 _offset)
    {
        Vector3 snapPosition = _position;

        if (!IsInBoundaries(Direction.DOWN, snapPosition))
            snapPosition = SnapPosition(Direction.UP, snapPosition, _offset);

        if (!IsInBoundaries(Direction.UP, snapPosition))
            snapPosition = SnapPosition(Direction.DOWN, snapPosition, _offset);

        if (!IsInBoundaries(Direction.LEFT, snapPosition))
            snapPosition = SnapPosition(Direction.RIGHT, snapPosition, _offset);

        if (!IsInBoundaries(Direction.RIGHT, snapPosition))
            snapPosition = SnapPosition(Direction.LEFT, snapPosition, _offset);

        return snapPosition;
    }

    public Vector3 BoundPositionAll(in Vector3 _position, float _offset = 0)
    {
        return BoundPositionAll(_position, new Vector2(_offset, _offset));
    }

    public Vector3 BoundPositionAll(in Vector3 _position, in Vector2 _offset)
    {
        Vector3 snapPosition = _position;

        if (!IsInBoundaries(Direction.DOWN, snapPosition, _offset))
            snapPosition = SnapPosition(Direction.DOWN, snapPosition, _offset);

        if (!IsInBoundaries(Direction.UP, snapPosition, _offset))
            snapPosition = SnapPosition(Direction.UP, snapPosition, _offset);

        if (!IsInBoundaries(Direction.LEFT, snapPosition, _offset))
            snapPosition = SnapPosition(Direction.LEFT, snapPosition, _offset);

        if (!IsInBoundaries(Direction.RIGHT, snapPosition, _offset))
            snapPosition = SnapPosition(Direction.RIGHT, snapPosition, _offset);

        return snapPosition;
    }
}
