using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Project.Common;

namespace Project.Controllers
{
    [Route("File")]
    public class FileController : Controller
    {
        #region Controller Actions

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            string path = Constants.PathToReadFiles;
            if (System.IO.File.Exists(path))
            {
                // This path is a file
                ProcessFile(path);
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
            CopySpecifiedBytesToAnotherFile(Constants.FileToCopy, Constants.FileNewSpecifiedPath, Constants.BytesToCopy);

            return View();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Process all files in the directory passed in, recurse on any directories that are found, and process the files they contain.
        /// </summary>
        /// <param name="targetDirectory"></param>
        private static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        /// <summary>
        /// Insert logic for processing found files here.
        /// </summary>
        /// <param name="path"></param>
        private static void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathSource"></param>
        /// <param name="pathNew"></param>
        /// <param name="numBytesToRead"></param>
        private static void CopySpecifiedBytesToAnotherFile(string pathSource, string pathNew, int numBytesToRead)
        {
            try
            {

                using (FileStream fsSource = new FileStream(pathSource,
                    FileMode.Open, FileAccess.Read))
                {

                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
                    // int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;

                    // Write the byte array to the other FileStream.
                    using (FileStream fsNew = new FileStream(pathNew,
                        FileMode.Create, FileAccess.Write))
                    {
                        fsNew.Write(bytes, 0, numBytesToRead);
                    }
                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }


        #endregion
    }
}