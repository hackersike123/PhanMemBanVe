using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace PhanMemBanVe.GUI.Utils
{
    public static class ReportFileLocator
    {
        // Returns a guaranteed accessible path to the RDLC file or null if not found.
        public static string GetOrCopyToOutput(string reportFileName)
        {
            if (string.IsNullOrWhiteSpace(reportFileName))
            {
                Debug.WriteLine("ReportFileLocator: reportFileName is null or empty");
                return null;
            }

            // Target path in output (bin\Debug...\Reports\file.rdlc)
            string outputDir = AppDomain.CurrentDomain.BaseDirectory;
            string outputReportsDir = Path.Combine(outputDir, "Reports");
            string outputReportPath = Path.Combine(outputReportsDir, reportFileName);

            Debug.WriteLine($"ReportFileLocator: Looking for {reportFileName}");
            Debug.WriteLine($"ReportFileLocator: Output dir = {outputDir}");
            Debug.WriteLine($"ReportFileLocator: Target path = {outputReportPath}");

            // Check if already exists in output
            if (File.Exists(outputReportPath))
            {
                Debug.WriteLine("ReportFileLocator: File found in output directory");
                return outputReportPath;
            }

            Debug.WriteLine("ReportFileLocator: File not in output, searching source...");

            // Candidate roots (project root, solution root)
            string baseDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar);
            DirectoryInfo binDir = new DirectoryInfo(baseDir);
            
            // Go up from bin\Debug or bin\Release
            DirectoryInfo projectDir = binDir.Parent != null && binDir.Parent.Parent != null
                ? binDir.Parent.Parent
                : binDir;

            DirectoryInfo solutionDir = projectDir.Parent;

            string[] candidateRoots = new[]
            {
                projectDir.FullName,
                solutionDir != null ? solutionDir.FullName : null
            }.Where(p => !string.IsNullOrEmpty(p)).Distinct().ToArray();

            Debug.WriteLine($"ReportFileLocator: Project dir = {projectDir.FullName}");
            if (solutionDir != null)
                Debug.WriteLine($"ReportFileLocator: Solution dir = {solutionDir.FullName}");

            // Search for source file
            string foundSourcePath = null;
            foreach (var root in candidateRoots)
            {
                // Try PhanMemBanVe.GUI\Reports\filename
                string candidate1 = Path.Combine(root, "PhanMemBanVe.GUI", "Reports", reportFileName);
                Debug.WriteLine($"ReportFileLocator: Checking {candidate1}");
                if (File.Exists(candidate1))
                {
                    foundSourcePath = candidate1;
                    Debug.WriteLine($"ReportFileLocator: Found at {candidate1}");
                    break;
                }

                // Try Reports\filename (for backward compatibility)
                string candidate2 = Path.Combine(root, "Reports", reportFileName);
                Debug.WriteLine($"ReportFileLocator: Checking {candidate2}");
                if (File.Exists(candidate2))
                {
                    foundSourcePath = candidate2;
                    Debug.WriteLine($"ReportFileLocator: Found at {candidate2}");
                    break;
                }
            }

            if (foundSourcePath == null)
            {
                Debug.WriteLine("ReportFileLocator: Source file NOT FOUND in any candidate location");
                return null;
            }

            // Try to copy to output
            try
            {
                if (!Directory.Exists(outputReportsDir))
                {
                    Debug.WriteLine($"ReportFileLocator: Creating directory {outputReportsDir}");
                    Directory.CreateDirectory(outputReportsDir);
                }

                Debug.WriteLine($"ReportFileLocator: Copying from {foundSourcePath} to {outputReportPath}");
                File.Copy(foundSourcePath, outputReportPath, overwrite: true);
                Debug.WriteLine("ReportFileLocator: Copy successful");
                return outputReportPath;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ReportFileLocator: Copy failed - {ex.Message}");
                // If copy fails, still attempt to use source directly
                Debug.WriteLine($"ReportFileLocator: Using source file directly: {foundSourcePath}");
                return foundSourcePath;
            }
        }
    }
}