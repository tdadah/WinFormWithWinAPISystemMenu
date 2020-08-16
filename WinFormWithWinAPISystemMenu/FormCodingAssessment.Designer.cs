namespace WinFormWithWinAPISystemMenu
{
	partial class FormCodingAssessment
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.InstructionsLabel = new System.Windows.Forms.Label();
			this.FindCalculatorBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// InstructionsLabel
			// 
			this.InstructionsLabel.AutoSize = true;
			this.InstructionsLabel.Location = new System.Drawing.Point( 60, 48 );
			this.InstructionsLabel.Name = "InstructionsLabel";
			this.InstructionsLabel.Size = new System.Drawing.Size( 624, 40 );
			this.InstructionsLabel.TabIndex = 0;
			this.InstructionsLabel.Text = "Right click on the icon in the upper left hand corner next to \'Form1\' to see syst" +
	"em menu.\nClick on the button that says \'Code assesment\'.";
			// 
			// FindCalculatorBackgroundWorker
			// 
			this.FindCalculatorBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.FindCalculatorBackgroundWorker_DoWork );
			// 
			// FormCodingAssessment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 9F, 20F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 785, 412 );
			this.Controls.Add( this.InstructionsLabel );
			this.Name = "FormCodingAssessment";
			this.Text = "Coding assessment";
			this.ResumeLayout( false );
			this.PerformLayout();
			this.Icon = Properties.Resources.TD;
		}

		#endregion

		private System.Windows.Forms.Label InstructionsLabel;
		private System.ComponentModel.BackgroundWorker FindCalculatorBackgroundWorker;
	}
}

