﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BDZipper
{
    /// <summary>
    /// Main class for our app
    /// </summary>
    //[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
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
                _currentDirectoryString = value.FullName + "\\";
            }
        }
        /// <summary>
        /// Current working directory (linux: pwd)
        /// This will change current directory to one set
        /// </summary>
        public string CurrentDirectoryString
        {
            get { return _currentDirectoryString; }
            // Not sure if we want to keep this here.  Perhaps after security is setup and single 
            // change directory method
            set 
            { 
                _currentDirectory = new DirectoryInfo(value);
                _currentDirectoryString = _currentDirectory.FullName + "\\";
            }
        }
        /// <summary>
        /// Returns if CurrentDirectory exists
        /// </summary>
        public bool CurrentDirectoryExists
        {
            get { return CurrentDirectory.Exists; }
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
        /// Gets ItemList values as a List collection of Object.BDZItemsList
        /// </summary>
        /// <returns>Generic List collection BDZItemList</returns>
        public List<BDZItemList> GetItemListValues()
        {
            List<BDZItemList> ItemList = new List<BDZItemList>();
            // Write Parent
            ItemList.Add(new BDZItemList("<a href='?sd=d$$'>..</a>", "d$.."));
            // Write directories
            foreach (DirectoryInfo di in CurrentDirectory.GetDirectories())
            {
                ItemList.Add(new BDZItemList(string.Format("<a href='?sd={0}'>{0}</a>", di.Name), "d$" + di.Name));
            }
            foreach (FileInfo fi in CurrentDirectory.GetFiles())
            {
                ItemList.Add(new BDZItemList(fi.Name, "f$" + fi.Name));
            }

            return ItemList;
        }
        /// <summary>
        /// Checks to see if directory is a sub-directory of CurrentDirectory
        /// </summary>
        /// <param name="Dir">Only directory name, not the full path</param>
        /// <returns></returns>
        public bool CheckIfSubDirInCurrentDir(string Dir)
        {
            return System.IO.Directory.Exists(CurrentDirectoryString + Dir);
            
        }
        /// <summary>
        /// Change a directory
        /// </summary>
        /// <param name="dir">Full path to directory</param>
        /// <returns>Result of change.  No directory change if false</returns>
        public bool ChangeToDirectory(string dir)
        {

            return true;
        }
        /// <summary>
        /// Changes to child (sub) directory within current directory.
        /// </summary>
        /// <param name="dir">string, directory name only, do not include path. 
        /// Must be child in current directory.</param>
        /// <returns>True is change is successful; False, unsuccessful no directory change</returns>
        public bool ChangeToChildDirectory(string dir)
        {
            if (!CheckIfSubDirInCurrentDir(dir))
                return false;
            else
            {
                DirectoryInfo disave = CurrentDirectory;
                CurrentDirectory = new DirectoryInfo(CurrentDirectoryString + dir);
                if (!CurrentDirectory.Exists)
                {
                    // put us back where we were
                    CurrentDirectory = disave;
                    return false;
                }
                else
                    return true;
            }
        }
        public bool ChangeToParentDirectory()
        {
            try
            {
                CurrentDirectory = new DirectoryInfo(CurrentDirectory.Parent.FullName);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public string DirectoryAccessResult(string fp2Dir)
        {
            DateTime dt = DateTime.Now;
            try
            {
                dt = Directory.GetCreationTime(fp2Dir);
                Directory.GetAccessControl(fp2Dir);
            }
            catch (UnauthorizedAccessException)
            {
                return "Unable to access that folder, Not Authorized.<br /><br />";
            }
            catch (System.Security.SecurityException)
            {
                return "Web security level will not allow access to security info";
            }
            catch (Exception ex)
            {
                return "in class: " + ex.ToString();
            }
            return "OK: " + dt.ToString() + "<br />" + fp2Dir;
        }

        
    }


}
