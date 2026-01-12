using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizTester.Helpers
{
    class WinMergeDiff
    {

        public static void CompareWithWinMerge(string file1, string file2)
        {
            var winMergePath = @"C:\Program Files\WinMerge\WinMergeU.exe";
            if (!File.Exists(winMergePath))
            {
                using (OpenFileDialog of = new OpenFileDialog())
                {
                    of.Filter = "WinMergeU.exe (*.exe)";
                    of.Title = "Select WinMergeU.exe from WinMerge folder";
                    if (of.ShowDialog() == DialogResult.OK)
                    {
                        winMergePath = of.FileName;
                    }else
                    {
                        winMergePath = null;
                    }
                }
            }

            if (winMergePath != null)
            {
                Task.Run(() =>
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = "WinMergeU.exe",
                        Arguments = $"/enablexml /ignorews \"{file1}\" \"{file2}\"",
                        UseShellExecute = true
                    };

                    Process.Start(psi);
                });
            }
        }

    }
}
