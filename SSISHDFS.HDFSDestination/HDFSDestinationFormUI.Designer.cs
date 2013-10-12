﻿namespace SSISHDFS.HDFSDestination
{
  partial class HDFSDestinationFormUI
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbConnectionList = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnNewConnectionManager = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.panel4 = new System.Windows.Forms.Panel();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtDestinationPath = new System.Windows.Forms.TextBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.cbSourceColumns = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel4.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cbConnectionList);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.btnNewConnectionManager);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(402, 84);
      this.groupBox1.TabIndex = 9;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Connection Settings";
      // 
      // cbConnectionList
      // 
      this.cbConnectionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbConnectionList.FormattingEnabled = true;
      this.cbConnectionList.Location = new System.Drawing.Point(120, 33);
      this.cbConnectionList.Name = "cbConnectionList";
      this.cbConnectionList.Size = new System.Drawing.Size(188, 21);
      this.cbConnectionList.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 36);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(106, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Connection Manager";
      // 
      // btnNewConnectionManager
      // 
      this.btnNewConnectionManager.Location = new System.Drawing.Point(314, 33);
      this.btnNewConnectionManager.Name = "btnNewConnectionManager";
      this.btnNewConnectionManager.Size = new System.Drawing.Size(75, 23);
      this.btnNewConnectionManager.TabIndex = 2;
      this.btnNewConnectionManager.Text = "New";
      this.btnNewConnectionManager.UseVisualStyleBackColor = true;
      this.btnNewConnectionManager.Click += new System.EventHandler(this.btnNewConnectionManager_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(86, 7);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(5, 7);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 259);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(427, 38);
      this.panel1.TabIndex = 11;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Controls.Add(this.btnOK);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel2.Location = new System.Drawing.Point(257, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(170, 38);
      this.panel2.TabIndex = 8;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.groupBox1);
      this.panel3.Location = new System.Drawing.Point(12, 6);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(402, 84);
      this.panel3.TabIndex = 12;
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.groupBox2);
      this.panel4.Location = new System.Drawing.Point(13, 99);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(401, 66);
      this.panel4.TabIndex = 13;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.txtDestinationPath);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(401, 66);
      this.groupBox2.TabIndex = 0;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "HDFS Configuration";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 29);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(85, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Destination Path";
      // 
      // txtDestinationPath
      // 
      this.txtDestinationPath.Location = new System.Drawing.Point(119, 26);
      this.txtDestinationPath.Name = "txtDestinationPath";
      this.txtDestinationPath.Size = new System.Drawing.Size(188, 20);
      this.txtDestinationPath.TabIndex = 7;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.label3);
      this.groupBox3.Controls.Add(this.cbSourceColumns);
      this.groupBox3.Location = new System.Drawing.Point(13, 171);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(401, 73);
      this.groupBox3.TabIndex = 14;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Input Column";
      // 
      // cbSourceColumns
      // 
      this.cbSourceColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSourceColumns.FormattingEnabled = true;
      this.cbSourceColumns.Location = new System.Drawing.Point(119, 20);
      this.cbSourceColumns.Name = "cbSourceColumns";
      this.cbSourceColumns.Size = new System.Drawing.Size(188, 21);
      this.cbSourceColumns.TabIndex = 0;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(7, 23);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(79, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Source Column";
      // 
      // HDFSDestinationFormUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(427, 297);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel4);
      this.Name = "HDFSDestinationFormUI";
      this.Text = "HDFSDestinationUI";
      this.Load += new System.EventHandler(this.HDFSDestinationUI_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ComboBox cbConnectionList;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnNewConnectionManager;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtDestinationPath;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbSourceColumns;
  }
}