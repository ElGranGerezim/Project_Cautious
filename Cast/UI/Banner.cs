using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.UI{
    public class Banner : Actor {
        public Banner(bool isVisible, string filepath, string subtitle){
            SetVisibility(isVisible);
            _subtitle = subtitle;
            SetImage(filepath);
            SetWidth(Constants.DEFAULT_BANNER_WIDTH);
            SetHeight(Constants.DEFAULT_BANNER_HEIGHT);
            Point center = new Point(Constants.MAX_X / 2 - (_width/2), Constants.MAX_Y / 2 - (_height / 2));
            SetPosition(center);
        }

        public void SetVisibility(bool isVisible){
            _isVisible = isVisible;
        }
    }
}