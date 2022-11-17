namespace zAppDev.Strategy.Utilities
{
    public class FileSystem
    {
        public static void SyncronizePaths(string srcPath, string targetPath, string fileFilter, DateTime? cuttoff = null)
        {
            var sourcedi = new DirectoryInfo(srcPath);
            if (!sourcedi.Exists)
                return;

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            if (!Directory.Exists(targetPath)) return;

            var sourcediFiles = sourcedi.EnumerateFiles(fileFilter);
            foreach (var sourcefi in sourcediFiles)
            {
                var targetDiFilePath = Path.Combine(targetPath, sourcefi.Name);

                var doCopy = !File.Exists(targetDiFilePath); //do copy if target file does not exist

                if (!doCopy) //exists, check file-modified timestamp
                {
                    if (sourcefi.LastWriteTimeUtc > File.GetLastWriteTimeUtc(targetDiFilePath)
                        &&
                        (!cuttoff.HasValue || File.GetLastWriteTimeUtc(targetDiFilePath) < cuttoff.Value)
                        )
                        doCopy = true;
                }

                if (!doCopy) continue;

                File.Copy(sourcefi.FullName, targetDiFilePath, true);
            }

            var sourcediSubdirs = sourcedi.EnumerateDirectories();
            foreach (var sourcediSubdir in sourcediSubdirs)
            {
                SyncronizePaths(Path.Combine(srcPath, sourcediSubdir.Name), Path.Combine(targetPath, sourcediSubdir.Name), fileFilter);
            }
        }

        public static void SaveFile(string directory, string fileName, string contents)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(Path.Combine(directory, fileName), contents);
        }
    }
}
