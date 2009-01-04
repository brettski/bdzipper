using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BDZipper
{
    /// <summary>
    /// New BDZipper Class
    /// </summary>
    class bdz
    {
        private DirectoryInfo _currentDirectory;

        public bdz(string fpdir)
        {

        }

        public bdz(DirectoryInfo dirInfo)
        {
            
        }

        public DirectoryInfo CurrentDirectory
        {
            get { return _currentDirectory; }
        }

        public string CurrentDirectoryString
        {
            get { return _currentDirectory.FullName + "\\"; }
        }

        /// <summary>
        /// Check if given directory name exists as sub (child) directory.
        /// </summary>
        /// <param name="dir">Directory name only, no path info</param>
        /// <returns></returns>
        public bool CheckIfSubDirInCurrentDir(string dir)
        {
            return Directory.Exists(CurrentDirectoryString + dir);
        }

        public bool ChangeToChildDirectory(string dir)
        {
            if (!CheckIfSubDirInCurrentDir(dir))
                return false;
            else
            {
                // Directory exits, lets change to it
                return ChangeToDirectory(CurrentDirectoryString + dir);
                
            }
        }

        private bool ChangeToDirectory(string fp2Dir)
        {
            //TODO:Build in security checks
            // Must add sec checks etc.
            try
            {
                _currentDirectory = new DirectoryInfo(fp2Dir);
            }
            catch
            {
                return false;
            }
            return _currentDirectory.Exists;
        }
        /// <summary>
        /// Checks if app is allowed to access give directory
        /// </summary>
        /// <param name="fp2dir">Full path to directory to check</param>
        /// <returns></returns>
        public bool CheckAccessToDirectory(string fp2dir)
        {
            return false;
        }

        public string ReturnAccessToDirectory(string fp2dir)
        {
            return "";
        }
    } 
}
