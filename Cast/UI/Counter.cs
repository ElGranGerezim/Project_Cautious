using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.UI{
    public class Counter : Actor{
        private int _count;
        public Counter(string title, int count, Point position){
            _isVisible = true;
            _text = title;
            _count = count;
            SetWidth(Constants.DEFAULT_FONT_SIZE * _text.Length);
            SetHeight(Constants.DEFAULT_FONT_SIZE);
            SetPosition(position);
            UpdateText();
        }

        public void CountUp(){
            _count ++;
            UpdateText();
        }

        public void CountDown(){
            _count --;
            UpdateText();
        }

        private void UpdateText(){
            _subtitle = _count.ToString();
        }
    }
}