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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnNew = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtFileTypeFilter = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtSourceDirectory
      // 
      this.txtSourceDirectory.Location = new System.Drawing.Point(127, 21);
      this.txtSourceDirectory.Name = "txtSourceDirectory";
      this.txtSourceDirectory.Size = new System.Drawing.Size(161, 20);
      this.txtSourceDirectory.TabIndex = 0;
      // 
      // btnBrowse
      // 
      this.btnBrowse.Location = new System.Drawing.Point(295, 21);
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
      this.label1.Location = new System.Drawing.Point(15, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(86, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Source Directory";
      // 
      // txtRemoteDirectory
      // 
      this.txtRemoteDirectory.Location = new System.Drawing.Point(127, 74);
      this.txtRemoteDirectory.Name = "txtRemoteDirectory";
      this.txtRemoteDirectory.Size = new System.Drawing.Size(161, 20);
      this.txtRemoteDirectory.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 77);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Remote Directory";
      // 
      // cbConnectionList
      // 
      this.cbConnectionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbConnectionList.FormattingEnabled = true;
      this.cbConnectionList.Location = new System.Drawing.Point(127, 23);
      this.cbConnectionList.Name = "cbConnectionList";
      this.cbConnectionList.Size = new System.Drawing.Size(161, 21);
      this.cbConnectionList.TabIndex = 0;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(15, 26);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(106, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Connection Manager";
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(248, 194);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(329, 194);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnNew);
      this.groupBox1.Controls.Add(this.cbConnectionList);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Location = new System.Drawing.Point(13, 13);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(391, 62);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Connection Settings";
      // 
      // btnNew
      // 
      this.btnNew.Location = new System.Drawing.Point(295, 23);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new System.Drawing.Size(75, 23);
      this.btnNew.TabIndex = 1;
      this.btnNew.Text = "New";
      this.btnNew.UseVisualStyleBackColor = true;
      this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.txtFileTypeFilter);
      this.groupBox2.Controls.Add(this.txtSourceDirectory);
      this.groupBox2.Controls.Add(this.btnBrowse);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.txtRemoteDirectory);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Location = new System.Drawing.Point(13, 82);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(391, 106);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "General Settings";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(15, 51);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(72, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "FileType Filter";
      // 
      // txtFileTypeFilter
      // 
      this.txtFileTypeFilter.Location = new System.Drawing.Point(127, 48);
      this.txtFileTypeFilter.Name = "txtFileTypeFilter";
      this.txtFileTypeFilter.Size = new System.Drawing.Size(161, 20);
      this.txtFileTypeFilter.TabIndex = 2;
      // 
      // HDFSTaskUIForm
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(414, 226);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "HDFSTaskUIForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "HDFS Task";
      this.Load += new System.EventHandler(this.HDFSTaskUIForm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

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
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtFileTypeFilter;
  }
}