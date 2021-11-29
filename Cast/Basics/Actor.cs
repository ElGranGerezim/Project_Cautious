using System;

namespace Project_Cautious.Cast.Basics{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Actor
    {
        protected bool _isVisible;
        protected Point _position;
        protected Point _velocity;

        protected int _width = 0;
        protected int _height = 0;

        protected string _text = "";
        protected string _image = "";
        protected string _subtitle = "";

        protected Raylib_cs.Color _color = Raylib_cs.Color.BLUE;

        public Actor()
        {
            // Start these at 0, 0 by default
            _position = new Point(0, 0);
            _velocity = new Point(0, 0);
        }

        public void SetImage(string image)
        {
            _image = image;
        }

        public string GetImage()
        {
            return _image;
        }

        public bool HasImage()
        {
            return _image != "";
        }

        public bool HasText()
        {
            return _text != "";
        }

        public bool HasSubtitle(){
            return _subtitle != "";
        }

        private void SetSubtitle(string text){
            _subtitle = text;
        }

        public string GetSubtitle(){
            return _subtitle;
        }

        public bool HasBox()
        {
            return _width > 0 && _height > 0;
        }

        public string GetText()
        {
            return _text;
        }

        public void SetText(string text)
        {
            _text = text;
        }

        public int GetX()
        {
            return _position.GetX();
        }

        public int GetY()
        {
            return _position.GetY();
        }

        public int GetLeftEdge()
        {
            return _position.GetX();
        }

        public int GetRightEdge()
        {
            return _position.GetX() + _width;
        }

        public int GetTopEdge()
        {
            return _position.GetY();
        }

        public int GetBottomEdge()
        {
            return _position.GetY() + _height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void SetWidth(int width)
        {
            _width = width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int height)
        {
            _height = height;
        }

        public Point GetPosition()
        {
            return _position;
        }

        public void SetPosition(Point position)
        {
            _position = position;
        }

        public Point GetVelocity()
        {
            return _velocity;
        }

        public virtual void SetVelocity(Point newVelocity)
        {
            _velocity = newVelocity;
        }
        
        public virtual bool GetIsVisible(){
            return _isVisible;
        }

        public Raylib_cs.Color GetColor(){
            return _color;
        }

        public void MoveNext()
        {
            int x = _position.GetX();
            int y = _position.GetY();

            int dx = _velocity.GetX();
            int dy = _velocity.GetY();

            int newX = (x + dx) % Constants.MAX_X;
            int newY = (y + dy) % Constants.MAX_Y;

            if (newX < 0)
            {
                newX = Constants.MAX_X;
            }

            if (newY < 0)
            {
                newY = Constants.MAX_Y;
            }

            _position = new Point(newX, newY);
        }

        public virtual bool canGetHit(){ return false; }

        public override string ToString()
        {
            return $"Position: ({_position.GetX()}, {_position.GetY()}), Velocity({_velocity.GetX()}, {_velocity.GetY()})";
        }

    }
}