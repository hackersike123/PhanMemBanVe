using System;
using System.IO;
using System.Linq;

namespace PhanMemBanVe.Utils
{
    public static class ReportFileLocator
    {
        // Returns a guaranteed accessible path to the RDLC file or null if not found.
        public static string GetOrCopyToOutput(string reportFileName)
        {
            if (string.IsNullOrWhiteSpace(reportFileName))
                return null;

            // Target path in output (bin\Debug...\Reports\file.rdlc)
            string outputDir = AppDomain.CurrentDomain.BaseDirectory;
            string outputReportsDir = Path.Combine(outputDir, "Reports");
            string outputReportPath = Path.Combine(outputReportsDir, reportFileName);

            if (File.Exists(outputReportPath))
                return outputReportPath;

            // Candidate roots (project root, solution root)
            string baseDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar);
            // Common pattern: ...\bin\Debug  OR ...\bin\Release
            DirectoryInfo binDir = new DirectoryInfo(baseDir);
            DirectoryInfo projectDir = binDir.Parent != null && binDir.Parent.Parent != null
                ? binDir.Parent.Parent    // go up from bin\Debug
                : binDir;

            // Additional candidate: solution root (one level higher)
            DirectoryInfo solutionDir = projectDir.Parent;

            string[] candidateRoots = new[]
            {
                projectDir.FullName,
                solutionDir != null ? solutionDir.FullName : null
            }.Where(p => !string.IsNullOrEmpty(p)).Distinct().ToArray();

            string foundSourcePath = null;
            foreach (var root in candidateRoots)
            {
                string candidate = Path.Combine(root, "Reports", reportFileName);
                if (File.Exists(candidate))
                {
                    foundSourcePath = candidate;
                    break;
                }
            }

            if (foundSourcePath == null)
                return null;

            try
            {
                if (!Directory.Exists(outputReportsDir))
                    Directory.CreateDirectory(outputReportsDir);

                File.Copy(foundSourcePath, outputReportPath, true);
                return outputReportPath;
            }
            catch
            {
                // If copy fails, still attempt to use source directly
                return foundSourcePath;
            }
        }
    }
}