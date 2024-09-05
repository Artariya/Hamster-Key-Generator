using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Dapper;
using System.IO;

namespace Hamster_Key_Generator
{
    public partial class Export : Form
    {
        private List<NumericUpDown> _numericList = new List<NumericUpDown>();
        private int controlSpacing = 26;

        public Export()
        {
            InitializeComponent();
        }

        private void Export_Load(object sender, EventArgs e)
        {
            LoadKeyStorage();
        }

        public void LoadKeyStorage()
        {
            // clear last controls
            _numericList.Clear();
            var controlsToKeep = new List<Control> { buttonRefresh, buttonExport };
            foreach (Control control in groupBox1.Controls.OfType<Control>().ToList())
            {
                if (!controlsToKeep.Contains(control))
                {
                    groupBox1.Controls.Remove(control);
                }
            }

            string dbPath = "Data Source=keys.db";

            using (var connection = new SQLiteConnection(dbPath))
            {
                string query = "SELECT platform, COUNT(id) AS cnt FROM keys GROUP BY platform";
                var result = connection.Query<dynamic>(query).ToList();
                int yPos = 20;

                Label allLabel = new Label();
                allLabel.Text = "All";
                allLabel.Location = new System.Drawing.Point(10, yPos + 3);
                allLabel.AutoSize = true;
                groupBox1.Controls.Add(allLabel);

                NumericUpDown allNumeric = new NumericUpDown();
                allNumeric.Location = new System.Drawing.Point(70, yPos);
                allNumeric.Width = 100;
                allNumeric.Maximum = 1000;
                groupBox1.Controls.Add(allNumeric);

                allNumeric.KeyUp += (sender, e) =>
                {
                    foreach (var numeric in _numericList)
                    {
                        if (numeric.Maximum < allNumeric.Value)
                        {
                            numeric.Value = numeric.Maximum;
                        }
                        else
                        {
                            numeric.Value = allNumeric.Value;
                        }
                    }
                }; ;
                allNumeric.ValueChanged += (sender, e) =>
                {
                    foreach (var numeric in _numericList)
                    {
                        if (numeric.Maximum < allNumeric.Value)
                        {
                            numeric.Value = numeric.Maximum;
                        }
                        else
                        {
                            numeric.Value = allNumeric.Value;
                        }
                    }
                }; ;
                yPos += controlSpacing;

                foreach (var row in result)
                {
                    string platform = row.platform;
                    long count = row.cnt;

                    Label label = new Label();
                    label.Text = platform.ToUpper();
                    label.Location = new Point(10, yPos + 3);
                    label.AutoSize = true;
                    groupBox1.Controls.Add(label);

                    NumericUpDown numeric = new NumericUpDown();
                    numeric.Value = 0;
                    numeric.Location = new Point(70, yPos);
                    numeric.Width = 100;
                    numeric.Maximum = (int)count;
                    numeric.Minimum = 0;
                    numeric.Name = "numeric_platform_" + platform;
                    groupBox1.Controls.Add(numeric);
                    _numericList.Add(numeric);

                    Label labelCount = new Label();
                    labelCount.Text = $"{count} Keys";
                    labelCount.Location = new Point(180, yPos + 3);
                    labelCount.AutoSize = true;
                    groupBox1.Controls.Add(labelCount);

                    yPos += controlSpacing;
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadKeyStorage();
        }

        private string[] getKeys()
        {
            List<string> keys = new List<string>();
            foreach (var item in listBoxKeys.Items)
            {
                if (checkBoxMonoSpace.Checked)
                {
                    keys.Add($"`{item}`");
                }
                else
                {
                    keys.Add(item.ToString());
                }
            }
            return keys.ToArray();
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            string[] keys = getKeys();
            if (keys.Length > 0)
            {
                SaveFileDialog sf = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    DefaultExt = "txt",
                    FileName = "keys(" + DateTime.Now.ToString("yy-MM-dd-HH-mm") + ").txt",
                    Title = "Save your keys"
                };
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(sf.FileName, keys);
                    MessageBox.Show("Key successfully saved.", "Keys saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonCopyAll_Click(object sender, EventArgs e)
        {
            string[] keys = getKeys();
            if (keys.Length > 0)
            {
                StringBuilder allItems = new StringBuilder();
                foreach (var item in keys)
                {
                    allItems.AppendLine(item.ToString());
                }
                Clipboard.SetText(allItems.ToString());
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            string dbPath = "Data Source=keys.db";
            using (var connection = new SQLiteConnection(dbPath))
            {
                foreach (var numeric in _numericList)
                {
                    string platform = numeric.Name.Replace("numeric_platform_", "");
                    int limit = (int)numeric.Value;
                    string selectQuery = "SELECT id, key FROM keys WHERE platform = @Platform ORDER BY RANDOM() LIMIT @Limit";
                    var keys = connection.Query<dynamic>(selectQuery, new { Platform = platform, Limit = limit }).ToList();
                    foreach (var key in keys)
                    {
                        listBoxKeys.Items.Add(key.key);
                    }
                    string deleteQuery = "DELETE FROM keys WHERE id = @Id";
                    foreach (var key in keys)
                    {
                        connection.Execute(deleteQuery, new { Id = key.id });
                    }
                }
            }
            LoadKeyStorage();
        }
    }
}
