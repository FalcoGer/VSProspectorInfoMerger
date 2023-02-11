using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace VSProspectorInfoMerger
{
    public partial class MainForm : Form
    {
        private enum EDirection
        {
            input = 0,
            output = 1
        }

        private EDirection dir = EDirection.input;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // init default file paths
            tb_outputFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\VintageStoryData\\ModData\\";
            tb_inputFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\";

            // prepare file dialogue
            ofd_fileDialogue.Filter = "PI Json Documents|vsprospectorinfo.data.json|Json Documents|*.json|All Files|*.*";
            ofd_fileDialogue.DefaultExt = "json";
            ofd_fileDialogue.CheckFileExists = true;
            ofd_fileDialogue.Multiselect = false;
        }

        private void btn_browseOutputFile_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(tb_outputFile.Text);
            if (fi.Directory?.Exists != true)
            {
                fi = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\VintageStoryData\\ModData");
            }
            dir = EDirection.output;
            ofd_fileDialogue.InitialDirectory = fi.DirectoryName + "\\";
            ofd_fileDialogue.Title = "Select your PI data file.";
            ofd_fileDialogue.FileName = "vsprospectorinfo.data.json";
            ofd_fileDialogue.ShowDialog();
        }
        private void btn_browseInputFile_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(tb_inputFile.Text);
            if (fi.Directory?.Exists != true)
            {
                fi = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            }
            dir = EDirection.input;
            ofd_fileDialogue.InitialDirectory = fi.DirectoryName + "\\";
            ofd_fileDialogue.Title = "Select PI data file to merge into your own.";
            ofd_fileDialogue.FileName = string.Empty;
            ofd_fileDialogue.ShowDialog();
        }

        private void ofd_fileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            FileInfo fi = new FileInfo(ofd_fileDialogue.FileName);
            if (dir == EDirection.output)
            {
                tb_outputFile.Text = fi.FullName;
            }
            else if (dir == EDirection.input)
            {
                tb_inputFile.Text = fi.FullName;
            }
        }

        private void btn_merge_Click(object sender, EventArgs e)
        {
            FileInfo ofi = new FileInfo(tb_outputFile.Text);
            FileInfo ifi = new FileInfo(tb_inputFile.Text);
            int mergeCount = 0;     // number of items merged into the output file.
            int duplicateCount = 0; // number of items that were the same
            int warningCount = 0;   // number of items that had the same coordinates but different values
            int processedCount = 0; // number of items that had been processed
            int totalCount = 0;     // total number of items that were processed

            string json;

            if (!ifi.Exists)
            {
                MessageBox.Show("Input file does not exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!ofi.Exists)
            {
                MessageBox.Show("Own file does not exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load all data from output file
            List<PIDataBlock>? outputData = null;
            using (FileStream fs = ofi.OpenRead())
            {
                json = string.Join(string.Empty, ReadLines(() => fs, Encoding.UTF8).ToList());
                outputData = JsonConvert.DeserializeObject<List<PIDataBlock>>(json);
            }
            if (outputData == null)
            {
                MessageBox.Show("Error reading data from own file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // load all data from input file
            List<PIDataBlock>? inputData = null;
            using (FileStream fs = ifi.OpenRead())
            {
                json = string.Join(string.Empty, ReadLines(() => fs, Encoding.UTF8).ToList());
                inputData = JsonConvert.DeserializeObject<List<PIDataBlock>>(json);
            }
            if (inputData == null)
            {
                MessageBox.Show("Error reading data from input file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            totalCount = inputData.Count();

            // append data to the output file where it doesn't match to merge the data
            bool ignoreAllErrors = false;
            foreach (PIDataBlock db in inputData)
            {
                processedCount++;
                PIDataBlock? foundData = outputData.Find(x => { return x.X == db.X && x.Z == db.Z; });
                if (foundData == null)
                {
                    outputData.Add(db);
                    mergeCount++;
                }
                else
                {
                    duplicateCount++;
                    // check other values for sameness
                    if (!foundData.Equals(db) && ignoreAllErrors == false)
                    {
                        duplicateCount--;
                        warningCount++;
                        string message = "Data Missmatch.\nOwn File:\n--------------\n" +
                            foundData.ToString() +
                            "\n--------------\n\nOther File:\n--------------\n" +
                            db.ToString() +
                            "\n--------------\n\nDo you wish to ignore future errors?\n" +
                            "Yes: Ignore all future Errors (keep your versions)\n" +
                            "No: Ignore this error only (keep your version)\n" +
                            "Cancel: Stop operation. Your file remains unchanged.";

                        DialogResult result = MessageBox.Show(message, "MISSMATCH", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Cancel)
                        {
                            lbl_status.Text = string.Format("Aborted after {0} of {1} entries. {2} duplicates and {3} warnings.", processedCount, totalCount, duplicateCount, warningCount);
                            return;
                        }
                        else if (result == DialogResult.Yes)
                        {
                            ignoreAllErrors = true;
                        }
                    }
                }
            }

            if (mergeCount > 0)
            {
                // make a backup of ofi
                string bkpFileName = ofi.FullName + "." + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".bkp";
                ofi.CopyTo(bkpFileName);

                // write back to the output file
                json = JsonConvert.SerializeObject(outputData, Formatting.Indented);
                File.WriteAllText(ofi.FullName, json);
                lbl_status.Text = string.Format("Merged {0} entries out of {1}. {2} duplicates and {3} warnings.", mergeCount, totalCount, duplicateCount, warningCount);
            }
            else
            {
                lbl_status.Text = string.Format("Nothing new, file not written. {0} processed. {1} duplicates and {2} warnings.", totalCount, duplicateCount, warningCount);
            }
            
        }

        private IEnumerable<string> ReadLines(Func<Stream> streamProvider, Encoding encoding)
        {
            using (Stream? stream = streamProvider())
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                string? line = null;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        yield return line;
                    }
                } while (line != null);
            }
        }
    }
}
