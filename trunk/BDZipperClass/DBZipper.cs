using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BDZipper
{
    /// <summary>
    /// Main class for our app
    /// </summary>
    public class BDZipper
    {
        public BDZipper() 
        {
        }
        /// <summary>
        /// Sub-directories of the current directory
        /// </summary>
        public List<DirectoryInfo> Directories
        { get; set; }
        /// <summary>
        /// file in current directory
        /// </summary>
        public List<FileInfo> Files
        { get; set; }

        public string CurrentDirectory
        { get; set; }



    }


}
