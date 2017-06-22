using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppUpdates.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                FileInfo fileInfo = new FileInfo(txtPath.Text);
                StreamServiceRef.IStreamService clientUpload = new StreamServiceRef.StreamServiceClient();
                StreamServiceRef.RemoteFileInfo uploadRequestInfo = new StreamServiceRef.RemoteFileInfo();

                using (FileStream stream = new FileStream(txtPath.Text, FileMode.Open, FileAccess.Read))
                {
                    uploadRequestInfo.FileName = fileInfo.Name;
                    uploadRequestInfo.Length = fileInfo.Length;
                    uploadRequestInfo.FileByteStream = stream;
                    clientUpload.UploadFile(uploadRequestInfo);
                    //clientUpload.UploadFile(stream);
                }
            }
        }
    }
}
