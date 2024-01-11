using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace Refinity.IO
{
    /// <summary>
    /// Utility class for directory operations.
    /// </summary>
    public static class IOUtility
    {
        /// <summary>
        /// Creates a directory at the specified path if it does not already exist.
        /// </summary>
        /// <param name="path">The path of the directory to create.</param>
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Deletes a directory and all its contents if it exists.
        /// </summary>
        /// <param name="path">The path of the directory to delete.</param>
        public static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        /// <summary>
        /// Copies a directory and its contents from the source path to the destination path.
        /// </summary>
        /// <param name="sourcePath">The path of the source directory.</param>
        /// <param name="destinationPath">The path of the destination directory.</param>
        public static void CopyDirectory(string sourcePath, string destinationPath)
        {
            if (!Directory.Exists(sourcePath))
            {
                throw new DirectoryNotFoundException("The specified source directory does not exist.");
            }

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(destinationPath, fileName);
                File.Copy(file, destination);
            }
        }

        /// <summary>
        /// Moves a directory from the source path to the destination path.
        /// </summary>
        /// <param name="sourcePath">The path of the source directory.</param>
        /// <param name="destinationPath">The path of the destination directory.</param>
        public static void MoveDirectory(string sourcePath, string destinationPath)
        {
            if (!Directory.Exists(sourcePath))
            {
                throw new DirectoryNotFoundException("The specified source directory does not exist.");
            }

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(destinationPath, fileName);
                File.Move(file, destination);
            }

            Directory.Delete(sourcePath, true);
        }

        /// <summary>
        /// Copies a file from the source path to the destination path.
        /// </summary>
        /// <param name="sourcePath">The path of the source file.</param>
        /// <param name="destinationPath">The path of the destination file.</param>
        public static void CopyFile(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException("The specified source file does not exist.");
            }

            File.Copy(sourcePath, destinationPath);
        }

        /// <summary>
        /// Moves a file from the source path to the destination path.
        /// </summary>
        /// <param name="sourcePath">The path of the file to be moved.</param>
        /// <param name="destinationPath">The destination path where the file will be moved to.</param>
        /// <exception cref="FileNotFoundException">Thrown if the specified source file does not exist.</exception>
        public static void MoveFile(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException("The specified source file does not exist.");
            }

            File.Move(sourcePath, destinationPath);
        }

        /// <summary>
        /// Deletes a file if it exists.
        /// </summary>
        /// <param name="path">The path of the file to delete.</param>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Reads a file and returns its contents as a string.
        /// </summary>
        /// <param name="path">The path of the file to read.</param>
        /// <returns>The contents of the file as a string.</returns>
        public static string ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The specified file does not exist.");
            }

            return File.ReadAllText(path);
        }

        /// <summary>
        /// Writes a string to a file.
        /// </summary>
        /// <param name="path">The path of the file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="append">Whether to append the contents to the file or overwrite it.</param>
        /// <param name="encoding">The encoding to use when writing to the file.</param>
        public static void WriteFile(string path, string contents, bool append = false, System.Text.Encoding? encoding = null)
        {
            if (encoding == null)
            {
                encoding = System.Text.Encoding.UTF8;
            }

            if (append)
            {
                File.AppendAllText(path, contents, encoding);
            }
            else
            {
                File.WriteAllText(path, contents, encoding);
            }
        }

        /// <summary>
        /// Writes a string to a file.
        /// </summary>
        /// <param name="path">The path of the file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="append">Whether to append the contents to the file or overwrite it.</param>
        /// <param name="encoding">The encoding to use when writing to the file.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task WriteFileAsync(string path, string contents, bool append = false, System.Text.Encoding? encoding = null)
        {
            if (encoding == null)
            {
                encoding = System.Text.Encoding.UTF8;
            }

            if (append)
            {
                await File.AppendAllTextAsync(path, contents, encoding);
            }
            else
            {
                await File.WriteAllTextAsync(path, contents, encoding);
            }
        }

        /// <summary>
        /// Reads a file and returns its contents as a byte array.
        /// </summary>
        /// <param name="path">The path of the file to read.</param>
        /// <returns>The contents of the file as a byte array.</returns>
        public static byte[] ReadFileBytes(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The specified file does not exist.");
            }

            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// Writes a byte array to a file.
        /// </summary>
        /// <param name="path">The path of the file to write to.</param>
        /// <param name="contents">The byte array to write to the file.</param>
        /// <param name="append">Whether to append the contents to the file or overwrite it.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task WriteFileBytesAsync(string path, byte[] contents, bool append = false)
        {
            if (contents == null)
            {
                throw new ArgumentNullException(nameof(contents));
            }

            string contentsString = System.Text.Encoding.Default.GetString(contents);

            if (append)
            {
                await File.AppendAllTextAsync(path, contentsString);
            }
            else
            {
                await File.WriteAllBytesAsync(path, contents);
            }
        }

        /// <summary>
        /// Reads a file and returns its contents as a stream.
        /// </summary>
        /// <param name="path">The path of the file to read.</param>
        /// <returns>The contents of the file as a stream.</returns>
        public static Stream GetFileStream(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The specified file does not exist.");
            }

            return File.OpenRead(path);
        }

        /// <summary>
        /// Writes a stream to a file.
        /// </summary>
        /// <param name="path">The path of the file to write to.</param>
        /// <param name="stream">The stream to write to the file.</param>
        /// <param name="append">Whether to append the contents to the file or overwrite it.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task WriteFileStreamAsync(string path, Stream stream, bool append = false)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (append)
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Append))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
            else
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }

        /// <summary>
        /// Reads a file and returns its contents as a stream.
        /// </summary>
        /// <param name="path">The path of the file to read.</param>
        /// <returns>The contents of the file as a stream.</returns>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<Stream> GetFileStreamAsync(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The specified file does not exist.");
            }

            return await Task.Run(() => File.OpenRead(path));
        }

        /// <summary>
        /// Compresses a file using GZip compression.
        /// </summary>
        /// <param name="sourceFilePath">The path of the source file to compress.</param>
        /// <param name="compressedFilePath">The path where the compressed file will be created.</param>
        public static void CompressFile(string sourceFilePath, string compressedFilePath)
        {
            using (FileStream sourceFile = File.OpenRead(sourceFilePath))
            {
                using (FileStream compressedFile = File.Create(compressedFilePath))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFile, CompressionMode.Compress))
                    {
                        sourceFile.CopyTo(compressionStream);
                    }
                }
            }
        }

        /// <summary>
        /// Compresses a file using GZip compression.
        /// </summary>
        /// <param name="sourceFilePath">The path of the source file to compress.</param>
        /// <param name="compressedFilePath">The path where the compressed file will be created.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task CompressFileAsync(string sourceFilePath, string compressedFilePath)
        {
            using (FileStream sourceFile = File.OpenRead(sourceFilePath))
            {
                using (FileStream compressedFile = File.Create(compressedFilePath))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFile, CompressionMode.Compress))
                    {
                        await sourceFile.CopyToAsync(compressionStream);
                    }
                }
            }
        }

        /// <summary>
        /// Decompresses a file using GZip compression.
        /// </summary>
        /// <param name="compressedFilePath">The path of the compressed file to decompress.</param>
        /// <param name="decompressedFilePath">The path where the decompressed file will be created.</param>
        public static void DecompressFile(string compressedFilePath, string decompressedFilePath)
        {
            using (FileStream compressedFile = File.OpenRead(compressedFilePath))
            {
                using (FileStream decompressedFile = File.Create(decompressedFilePath))
                {
                    using (GZipStream decompressionStream = new GZipStream(compressedFile, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFile);
                    }
                }
            }
        }

        /// <summary>
        /// Decompresses a file using GZip compression.
        /// </summary>
        /// <param name="compressedFilePath">The path of the compressed file to decompress.</param>
        /// <param name="decompressedFilePath">The path where the decompressed file will be created.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task DecompressFileAsync(string compressedFilePath, string decompressedFilePath)
        {
            using (FileStream compressedFile = File.OpenRead(compressedFilePath))
            {
                using (FileStream decompressedFile = File.Create(decompressedFilePath))
                {
                    using (GZipStream decompressionStream = new GZipStream(compressedFile, CompressionMode.Decompress))
                    {
                        await decompressionStream.CopyToAsync(decompressedFile);
                    }
                }
            }
        }

        /// <summary>
        /// Compresses a directory into a zip file.
        /// </summary>
        /// <param name="sourceDirectoryPath">The path of the directory to compress.</param>
        /// <param name="compressedFilePath">The path of the compressed zip file.</param>
        public static void CompressDirectory(string sourceDirectoryPath, string compressedFilePath)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryPath, compressedFilePath);
        }

        /// <summary>
        /// Compresses a directory asynchronously.
        /// </summary>
        /// <param name="sourceDirectoryPath">The path of the directory to compress.</param>
        /// <param name="compressedFilePath">The path of the compressed file to create.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task CompressDirectoryAsync(string sourceDirectoryPath, string compressedFilePath)
        {
            await Task.Run(() => ZipFile.CreateFromDirectory(sourceDirectoryPath, compressedFilePath));
        }

        /// <summary>
        /// Decompresses a directory from a compressed file to a specified directory path.
        /// </summary>
        /// <param name="compressedFilePath">The path of the compressed file.</param>
        /// <param name="decompressedDirectoryPath">The path of the directory where the decompressed files will be placed.</param>
        public static void DecompressDirectory(string compressedFilePath, string decompressedDirectoryPath)
        {
            ZipFile.ExtractToDirectory(compressedFilePath, decompressedDirectoryPath);
        }

        /// <summary>
        /// Asynchronously decompresses a directory from a compressed file.
        /// </summary>
        /// <param name="compressedFilePath">The path of the compressed file.</param>
        /// <param name="decompressedDirectoryPath">The path where the decompressed directory will be created.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task DecompressDirectoryAsync(string compressedFilePath, string decompressedDirectoryPath)
        {
            await Task.Run(() => ZipFile.ExtractToDirectory(compressedFilePath, decompressedDirectoryPath));
        }
    }
}