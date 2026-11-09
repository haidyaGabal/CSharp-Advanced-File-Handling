
using System;
using System.IO;
using System.Text;

namespace Files
{
    public class FileHelper
    {
        private static readonly Encoding encoder = new UTF8Encoding(false);

        public static void Create(string path, string? content)
        {
            var full = Normalize(path);

            EnsureDirectory(full);

            File.WriteAllText(full, content ?? string.Empty, encoder);
        }

        public static void Append(string path, string? text, bool addNewLine = false)
        {
            var full = Normalize(path);

            EnsureDirectory(full);

            var payload = text ?? string.Empty;

            if (addNewLine)
                payload += Environment.NewLine;

            File.AppendAllText(full, payload, encoder);
        }

        public static string ReadAll(string path)
        {
            var full = Normalize(path);

            if (!File.Exists(full))
            {
                EnsureDirectory(full);
                File.WriteAllText(full, string.Empty, encoder);
                return string.Empty;
            }

            return File.ReadAllText(full, encoder);
        }

        public static bool Delete(string path)
        {
            var full = Normalize(path);

            if (!File.Exists(full))
                return false;

            File.Delete(full);
            return true;
        }

        public static bool TryReadAll(string path, out string? content)
        {
            try
            {
                var full = Normalize(path);

                if (!File.Exists(full))
                {
                    content = null;
                    return false;
                }

                content = File.ReadAllText(full, encoder);
                return true;
            }
            catch
            {
                content = null;
                return false;
            }
        }

        public static bool TryCreate(string path, string? content)
        {
            try
            {
                Create(path, content);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Internal helper methods

        private static string Normalize(string path)
        {
            ArgumentNullException.ThrowIfNull(path);

            return Path.GetFullPath(path);
        }

        private static void EnsureDirectory(string fullFilePath)
        {
            var directory = Path.GetDirectoryName(fullFilePath);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
