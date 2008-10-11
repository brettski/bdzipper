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
        /// <summary>
        /// String of current directory we are pointing at
        /// </summary>
        public string CurrentDirectory
        { get; set; }
        /// <summary>
        /// Breadcrumb path for top of page
        /// </summary>
        public string Breadcrumb
        { get; set; }
        /// <summary>
        /// Cannot navigate any higher then this point.
        /// </summary>
        public string HighestDirectoryAllowed
        { get; set; }

    }


}
