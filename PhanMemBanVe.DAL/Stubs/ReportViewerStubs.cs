// Temporary stubs for Microsoft.Reporting.WinForms to allow build without actual ReportViewer package.
// Remove this file once the real NuGet package (Microsoft.ReportingServices.ReportViewerControl.Winforms)
// is installed and references added.
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Microsoft.Reporting.WinForms
{
    public enum ProcessingMode { Local, Remote }

    public class ReportParameter
    {
        public ReportParameter(string name, string value) { }
        public ReportParameter(string name, string value, bool visible) { }
    }

    public class ReportDataSource
    {
        public ReportDataSource(string name, object value) { }
    }

    public class LocalReport
    {
        public List<ReportDataSource> DataSources { get; } = new List<ReportDataSource>();
        public void LoadReportDefinition(Stream stream) { }
        public void SetParameters(IEnumerable<ReportParameter> parameters) { }
    }

    public class ReportViewer : Control
    {
        public ProcessingMode ProcessingMode { get; set; }
        public LocalReport LocalReport { get; } = new LocalReport();
        public void Reset() { }
        public void RefreshReport() { }
    }
}
