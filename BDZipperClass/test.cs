using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BDZipper
{
    /// <summary>
    /// Simply my test class to figure things out.
    /// </summary>
    public class test
    {
        DirectoryInfo di = new DirectoryInfo(@"c:\");
        FileInfo fi;        
        
        //Constructor :)
        private test()
        {

        }

        public static test New()
        {

            return null;
        }

        public string getFileList()
        {
            

            return string.Empty;
        }
    }

    public class running
    {
        // factory
        test t = test.New();
        // constructor
        //test u = new test();
        

    }

}
