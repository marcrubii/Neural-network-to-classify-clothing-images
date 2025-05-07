namespace ClienteV3
{
    partial class Preguntados
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.RegisBox = new System.Windows.Forms.GroupBox();
            this.registroBot = new System.Windows.Forms.Button();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.mailLbl = new System.Windows.Forms.Label();
            this.passBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.usuBox = new System.Windows.Forms.TextBox();
            this.InicioSesionBox = new System.Windows.Forms.GroupBox();
            this.inicioBot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.passBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.usuBox2 = new System.Windows.Forms.TextBox();
            this.conectarBot = new System.Windows.Forms.Button();
            this.conn = new System.Windows.Forms.Button();
            this.listaconectados = new System.Windows.Forms.DataGridView();
            this.conectadosLbl = new System.Windows.Forms.Label();
            this.consultasBox = new System.Windows.Forms.GroupBox();
            this.consBot = new System.Windows.Forms.Button();
            this.MVPRadioBot = new System.Windows.Forms.RadioButton();
            this.partidaRadioBot = new System.Windows.Forms.RadioButton();
            this.passRadioBot = new System.Windows.Forms.RadioButton();
            this.mostrarBot = new System.Windows.Forms.Button();
            this.RegisBox.SuspendLayout();
            this.InicioSesionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaconectados)).BeginInit();
            this.consultasBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegisBox
            // 
            this.RegisBox.Controls.Add(this.registroBot);
            this.RegisBox.Controls.Add(this.mailBox);
            this.RegisBox.Controls.Add(this.mailLbl);
            this.RegisBox.Controls.Add(this.passBox);
            this.RegisBox.Controls.Add(this.label2);
            this.RegisBox.Controls.Add(this.label1);
            this.RegisBox.Controls.Add(this.usuBox);
            this.RegisBox.Location = new System.Drawing.Point(51, 53);
            this.RegisBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegisBox.Name = "RegisBox";
            this.RegisBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegisBox.Size = new System.Drawing.Size(224, 318);
            this.RegisBox.TabIndex = 0;
            this.RegisBox.TabStop = false;
            this.RegisBox.Text = "Registro";
            // 
            // registroBot
            // 
            this.registroBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registroBot.Location = new System.Drawing.Point(17, 256);
            this.registroBot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.registroBot.Name = "registroBot";
            this.registroBot.Size = new System.Drawing.Size(189, 42);
            this.registroBot.TabIndex = 6;
            this.registroBot.Text = "Registrarse";
            this.registroBot.UseVisualStyleBackColor = true;
            this.registroBot.Click += new System.EventHandler(this.registroBot_Click);
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(29, 208);
            this.mailBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(135, 22);
            this.mailBox.TabIndex = 5;
            // 
            // mailLbl
            // 
            this.mailLbl.AutoSize = true;
            this.mailLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailLbl.Location = new System.Drawing.Point(25, 180);
            this.mailLbl.Name = "mailLbl";
            this.mailLbl.Size = new System.Drawing.Size(78, 25);
            this.mailLbl.TabIndex = 4;
            this.mailLbl.Text = "Correo";
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(29, 146);
            this.passBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passBox.Name = "passBox";
            this.passBox.Size = new System.Drawing.Size(135, 22);
            this.passBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // usuBox
            // 
            this.usuBox.Location = new System.Drawing.Point(29, 78);
            this.usuBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuBox.Name = "usuBox";
            this.usuBox.Size = new System.Drawing.Size(135, 22);
            this.usuBox.TabIndex = 0;
            // 
            // InicioSesionBox
            // 
            this.InicioSesionBox.Controls.Add(this.mostrarBot);
            this.InicioSesionBox.Controls.Add(this.inicioBot);
            this.InicioSesionBox.Controls.Add(this.label3);
            this.InicioSesionBox.Controls.Add(this.passBox2);
            this.InicioSesionBox.Controls.Add(this.label4);
            this.InicioSesionBox.Controls.Add(this.label5);
            this.InicioSesionBox.Controls.Add(this.usuBox2);
            this.InicioSesionBox.Location = new System.Drawing.Point(353, 53);
            this.InicioSesionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InicioSesionBox.Name = "InicioSesionBox";
            this.InicioSesionBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InicioSesionBox.Size = new System.Drawing.Size(229, 318);
            this.InicioSesionBox.TabIndex = 1;
            this.InicioSesionBox.TabStop = false;
            this.InicioSesionBox.Text = "Iniciar Sesión";
            // 
            // inicioBot
            // 
            this.inicioBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioBot.Location = new System.Drawing.Point(29, 226);
            this.inicioBot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inicioBot.Name = "inicioBot";
            this.inicioBot.Size = new System.Drawing.Size(139, 71);
            this.inicioBot.TabIndex = 6;
            this.inicioBot.Text = "Iniciar Sesión";
            this.inicioBot.UseVisualStyleBackColor = true;
            this.inicioBot.Click += new System.EventHandler(this.inicioBot_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 4;
            // 
            // passBox2
            // 
            this.passBox2.Location = new System.Drawing.Point(29, 146);
            this.passBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passBox2.Name = "passBox2";
            this.passBox2.Size = new System.Drawing.Size(135, 22);
            this.passBox2.TabIndex = 3;
            this.passBox2.TextChanged += new System.EventHandler(this.passBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Usuario";
            // 
            // usuBox2
            // 
            this.usuBox2.Location = new System.Drawing.Point(29, 78);
            this.usuBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuBox2.Name = "usuBox2";
            this.usuBox2.Size = new System.Drawing.Size(135, 22);
            this.usuBox2.TabIndex = 0;
            // 
            // conectarBot
            // 
            this.conectarBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conectarBot.Location = new System.Drawing.Point(627, 53);
            this.conectarBot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.conectarBot.Name = "conectarBot";
            this.conectarBot.Size = new System.Drawing.Size(168, 46);
            this.conectarBot.TabIndex = 2;
            this.conectarBot.Text = "Conectar";
            this.conectarBot.UseVisualStyleBackColor = true;
            this.conectarBot.Click += new System.EventHandler(this.conectarBot_Click);
            // 
            // conn
            // 
            this.conn.Location = new System.Drawing.Point(827, 53);
            this.conn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.conn.Name = "conn";
            this.conn.Size = new System.Drawing.Size(75, 46);
            this.conn.TabIndex = 3;
            this.conn.UseVisualStyleBackColor = true;
            // 
            // listaconectados
            // 
            this.listaconectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaconectados.Location = new System.Drawing.Point(619, 201);
            this.listaconectados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listaconectados.Name = "listaconectados";
            this.listaconectados.RowHeadersWidth = 51;
            this.listaconectados.RowTemplate.Height = 24;
            this.listaconectados.Size = new System.Drawing.Size(176, 150);
            this.listaconectados.TabIndex = 4;
            // 
            // conectadosLbl
            // 
            this.conectadosLbl.AutoSize = true;
            this.conectadosLbl.Location = new System.Drawing.Point(624, 171);
            this.conectadosLbl.Name = "conectadosLbl";
            this.conectadosLbl.Size = new System.Drawing.Size(130, 16);
            this.conectadosLbl.TabIndex = 5;
            this.conectadosLbl.Text = "Lista de Conectados";
            // 
            // consultasBox
            // 
            this.consultasBox.Controls.Add(this.consBot);
            this.consultasBox.Controls.Add(this.MVPRadioBot);
            this.consultasBox.Controls.Add(this.partidaRadioBot);
            this.consultasBox.Controls.Add(this.passRadioBot);
            this.consultasBox.Location = new System.Drawing.Point(38, 42);
            this.consultasBox.Name = "consultasBox";
            this.consultasBox.Size = new System.Drawing.Size(390, 154);
            this.consultasBox.TabIndex = 6;
            this.consultasBox.TabStop = false;
            this.consultasBox.Text = "Consultas";
            // 
            // consBot
            // 
            this.consBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consBot.Location = new System.Drawing.Point(255, 62);
            this.consBot.Name = "consBot";
            this.consBot.Size = new System.Drawing.Size(107, 43);
            this.consBot.TabIndex = 3;
            this.consBot.Text = "Consultar";
            this.consBot.UseVisualStyleBackColor = true;
            this.consBot.Click += new System.EventHandler(this.consBot_Click);
            // 
            // MVPRadioBot
            // 
            this.MVPRadioBot.AutoSize = true;
            this.MVPRadioBot.Location = new System.Drawing.Point(17, 111);
            this.MVPRadioBot.Name = "MVPRadioBot";
            this.MVPRadioBot.Size = new System.Drawing.Size(160, 20);
            this.MVPRadioBot.TabIndex = 2;
            this.MVPRadioBot.TabStop = true;
            this.MVPRadioBot.Text = "Dime quién es el MVP";
            this.MVPRadioBot.UseVisualStyleBackColor = true;
            // 
            // partidaRadioBot
            // 
            this.partidaRadioBot.AutoSize = true;
            this.partidaRadioBot.Location = new System.Drawing.Point(17, 73);
            this.partidaRadioBot.Name = "partidaRadioBot";
            this.partidaRadioBot.Size = new System.Drawing.Size(205, 20);
            this.partidaRadioBot.TabIndex = 1;
            this.partidaRadioBot.TabStop = true;
            this.partidaRadioBot.Text = "Dame la partida más longeva";
            this.partidaRadioBot.UseVisualStyleBackColor = true;
            // 
            // passRadioBot
            // 
            this.passRadioBot.AutoSize = true;
            this.passRadioBot.Location = new System.Drawing.Point(17, 35);
            this.passRadioBot.Name = "passRadioBot";
            this.passRadioBot.Size = new System.Drawing.Size(147, 20);
            this.passRadioBot.TabIndex = 0;
            this.passRadioBot.TabStop = true;
            this.passRadioBot.Text = "Dime mi contraseña";
            this.passRadioBot.UseVisualStyleBackColor = true;
            // 
            // mostrarBot
            // 
            this.mostrarBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostrarBot.Location = new System.Drawing.Point(170, 141);
            this.mostrarBot.Name = "mostrarBot";
            this.mostrarBot.Size = new System.Drawing.Size(36, 32);
            this.mostrarBot.TabIndex = 7;
            this.mostrarBot.Text = "*";
            this.mostrarBot.UseVisualStyleBackColor = true;
            this.mostrarBot.Click += new System.EventHandler(this.mostrarBot_Click);
            // 
            // Preguntados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(931, 413);
            this.Controls.Add(this.consultasBox);
            this.Controls.Add(this.conectadosLbl);
            this.Controls.Add(this.conn);
            this.Controls.Add(this.conectarBot);
            this.Controls.Add(this.listaconectados);
            this.Controls.Add(this.InicioSesionBox);
            this.Controls.Add(this.RegisBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Preguntados";
            this.Text = "Preguntados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Preguntados_FormClosing);
            this.Load += new System.EventHandler(this.Preguntados_Load);
            this.RegisBox.ResumeLayout(false);
            this.RegisBox.PerformLayout();
            this.InicioSesionBox.ResumeLayout(false);
            this.InicioSesionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaconectados)).EndInit();
            this.consultasBox.ResumeLayout(false);
            this.consultasBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox RegisBox;
        private System.Windows.Forms.TextBox usuBox;
        private System.Windows.Forms.Label mailLbl;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registroBot;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.GroupBox InicioSesionBox;
        private System.Windows.Forms.Button inicioBot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox usuBox2;
        private System.Windows.Forms.Button conectarBot;
        private System.Windows.Forms.Button conn;
        private System.Windows.Forms.DataGridView listaconectados;
        private System.Windows.Forms.Label conectadosLbl;
        private System.Windows.Forms.GroupBox consultasBox;
        private System.Windows.Forms.RadioButton passRadioBot;
        private System.Windows.Forms.Button consBot;
        private System.Windows.Forms.RadioButton MVPRadioBot;
        private System.Windows.Forms.RadioButton partidaRadioBot;
        private System.Windows.Forms.Button mostrarBot;
    }
}

