using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessDzi
{
    class field : PictureBox
    {
        public int i { get; set; }
        public  int j { get; set; }

        public bool isChecked { get; set; }

        public int count { get; set; }
    }
}
