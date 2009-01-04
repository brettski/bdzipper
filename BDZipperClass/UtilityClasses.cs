using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDZipper
{


    public class BDZItemList
    {

        public BDZItemList(string Text, string Value)
        {
            this.Text = Text;
            this.Value = Value;
        }

        public string Text
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }
}
