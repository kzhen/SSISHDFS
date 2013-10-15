namespace SSISHDFS.HDFSTask
{
  partial class HDFSTaskUIForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.txtSourceDirectory = new System.Windows.Forms.TextBox();
      this.directoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtRemoteDirectory = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbConnectionList = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtSourceDirectory
      // 
      this.txtSourceDirectory.Location = new System.Drawing.Point(104, 12);
      this.txtSourceDirectory.Name = "txtSourceDirectory";
      this.txtSourceDirectory.Size = new System.Drawing.Size(100, 20);
      this.txtSourceDirectory.TabIndex = 0;
      // 
      // btnBrowse
      // 
      this.btnBrowse.Location = new System.Drawing.Point(210, 10);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(75, 23);
      this.btnBrowse.TabIndex = 1;
      this.btnBrowse.Text = "Browse";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(86, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Source Directory";
      // 
      // txtRemoteDirectory
      // 
      this.txtRemoteDirectory.Location = new System.Drawing.Point(104, 39);
      this.txtRemoteDirectory.Name = "txtRemoteDirectory";
      this.txtRemoteDirectory.Size = new System.Drawing.Size(100, 20);
      this.txtRemoteDirectory.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 42);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Remote Directory";
      // 
      // cbConnectionList
      // 
      this.cbConnectionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbConnectionList.FormattingEnabled = true;
      this.cbConnectionList.Location = new System.Drawing.Point(124, 94);
      this.cbConnectionList.Name = "cbConnectionList";
      this.cbConnectionList.Size = new System.Drawing.Size(161, 21);
      this.cbConnectionList.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 97);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(106, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Connection Manager";
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(209, 226);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 7;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(128, 226);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 8;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // HDFSTaskUIForm
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(302, 261);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cbConnectionList);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtRemoteDirectory);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnBrowse);
      this.Controls.Add(this.txtSourceDirectory);
      this.Name = "HDFSTaskUIForm";
      this.Text = "HDFSTaskUIForm";
      this.Load += new System.EventHandler(this.HDFSTaskUIForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtSourceDirectory;
    private System.Windows.Forms.FolderBrowserDialog directoryBrowser;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtRemoteDirectory;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbConnectionList;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
  }
}