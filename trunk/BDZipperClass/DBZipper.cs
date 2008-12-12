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

        private DirectoryInfo _currentDirectory;
        private string _currentDirectoryString;
        
        /// <summary>
        /// Create a new class of BDZipper.  Need to start with current directory
        /// </summary>
        /// <param name="CurDir">Current Directory as full path string</param>
        public BDZipper(string CurDir) 
        {
            CurrentDirectoryString = CurDir;
        }
        /// <summary>
        /// Create a new class of BDZipper.  Need to start with current directory
        /// </summary>
        /// <param name="CurDir">Current Directory as DirectoryInfo Object</param>
        public BDZipper(DirectoryInfo CurDir)
        {
            CurrentDirectory = CurDir;
        }

        public DirectoryInfo CurrentDirectory
        {
            get { return _currentDirectory; }

            set 
            { 
                _currentDirectory = value;
                _currentDirectoryString = value.FullName;
            }

        }
        /// <summary>
        /// Current working directory (linux: pwd)
        /// </summary>
        public string CurrentDirectoryString
        {
            get { return _currentDirectoryString; }

            set 
            { 
                _currentDirectoryString = value;
                _currentDirectory = new DirectoryInfo(value);
            }
        }
        /// <summary>
        /// Returns if CurrentDirectory exists
        /// </summary>
        public bool CurrentDirectoryExists
        {
            get { return _currentDirectory.Exists; }
        }
        /// <summary>
        /// Breadcrumb of CurrentDirectory path for top of page
        /// </summary>
        public string Breadcrumb
        { 
            get; 
            
            set; 
        }
        /// <summary>
        /// Cannot navigate any higher then this point.
        /// !Theoretical Property!
        /// </summary>
        public string HighestDirectoryAllowed
        { get; set; }
        /// <summary>
        /// Return collection for use for page directory list. 
        /// Key is item value, Value is item text
        /// </summary>
        /// <returns>Key is item value, Value is item text</returns>
        public Dictionary<string,string> GetItemListValues()
        {
            Dictionary<string, string> ItemList = new Dictionary<string,string>();
            // Write Parent ..
            ItemList.Add("d$..", "<a href='?sd=d$$'>..</a>");
            // Write directories
            foreach (DirectoryInfo di in _currentDirectory.GetDirectories())
            {
                ItemList.Add("d$" + di.Name, string.Format("<a href='?sd={0}'>{0}</a>", di.Name));
            }
            // Next Files (More logic added to this later to act on file.
            foreach (FileInfo fi in _currentDirectory.GetFiles())
            {
                ItemList.Add("f$" + fi.Name, fi.Name);
            }

            return ItemList;
        }
        public string[,] GetItemListValues()
        {
            // Array is zero based so we don't need -1 since we manually add parent directory
            int n = _currentDirectory.GetDirectories().Length + _currentDirectory.GetFiles().Length;
            string[,] ItemList = new string[n, 2];
            // write parent
            ItemList[0, 0] = "d$..";
            ItemList[0, 1] = "<a href='?sd=d$$'>..</a>";


            return ItemList;
        }
        /// <summary>
        /// Checks to see if directory is a sub-directory of CurrentDirectory
        /// </summary>
        /// <param name="Dir">Only directory name, not the full path</param>
        /// <returns></returns>
        public bool CheckIfSubDirInCurrentDir(string Dir)
        {
            return System.IO.Directory.Exists(_currentDirectoryString + Dir);
            
        }

        
    }


}
