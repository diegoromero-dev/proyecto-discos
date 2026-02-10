namespace proyecto_APP_0._1._0
{
    partial class frmdiscos
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
            this.dgvdisco = new System.Windows.Forms.DataGridView();
            this.pbtapadiscos = new System.Windows.Forms.PictureBox();
            this.btnagregar = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btneliminarlogica = new System.Windows.Forms.Button();
            this.lblfiltroconboton = new System.Windows.Forms.Label();
            this.txtfiltro = new System.Windows.Forms.TextBox();
            this.btnfiltro = new System.Windows.Forms.Button();
            this.lblfiltrosinboton = new System.Windows.Forms.Label();
            this.txtfiltrosinboton = new System.Windows.Forms.TextBox();
            this.cbcriterio = new System.Windows.Forms.ComboBox();
            this.cbcampo = new System.Windows.Forms.ComboBox();
            this.lblcampo = new System.Windows.Forms.Label();
            this.lblcriterio = new System.Windows.Forms.Label();
            this.btnfiltroavanzado = new System.Windows.Forms.Button();
            this.txtfiltroavanzado = new System.Windows.Forms.TextBox();
            this.lblfiltro = new System.Windows.Forms.Label();
            this.txtfiltroavanzadosolonumeros = new System.Windows.Forms.TextBox();
            this.btnresetearbusquedafiltrada = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdisco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtapadiscos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvdisco
            // 
            this.dgvdisco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdisco.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvdisco.Location = new System.Drawing.Point(12, 134);
            this.dgvdisco.MultiSelect = false;
            this.dgvdisco.Name = "dgvdisco";
            this.dgvdisco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdisco.Size = new System.Drawing.Size(556, 286);
            this.dgvdisco.TabIndex = 0;
            this.dgvdisco.SelectionChanged += new System.EventHandler(this.dgvdisco_SelectionChanged);
            // 
            // pbtapadiscos
            // 
            this.pbtapadiscos.Location = new System.Drawing.Point(574, 134);
            this.pbtapadiscos.Name = "pbtapadiscos";
            this.pbtapadiscos.Size = new System.Drawing.Size(268, 287);
            this.pbtapadiscos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbtapadiscos.TabIndex = 1;
            this.pbtapadiscos.TabStop = false;
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(12, 426);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(89, 23);
            this.btnagregar.TabIndex = 2;
            this.btnagregar.Text = "Agregar disco";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btnmodificar
            // 
            this.btnmodificar.Location = new System.Drawing.Point(107, 426);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(89, 23);
            this.btnmodificar.TabIndex = 3;
            this.btnmodificar.Text = "Modificar disco";
            this.btnmodificar.UseVisualStyleBackColor = true;
            this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(607, 514);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(110, 23);
            this.btneliminar.TabIndex = 4;
            this.btneliminar.Text = "Eliminar fisicamente";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btneliminarlogica
            // 
            this.btneliminarlogica.Location = new System.Drawing.Point(723, 514);
            this.btneliminarlogica.Name = "btneliminarlogica";
            this.btneliminarlogica.Size = new System.Drawing.Size(116, 23);
            this.btneliminarlogica.TabIndex = 5;
            this.btneliminarlogica.Text = "Eliminar logicamente";
            this.btneliminarlogica.UseVisualStyleBackColor = true;
            this.btneliminarlogica.Click += new System.EventHandler(this.btneliminarlogica_Click);
            // 
            // lblfiltroconboton
            // 
            this.lblfiltroconboton.AutoSize = true;
            this.lblfiltroconboton.Location = new System.Drawing.Point(12, 16);
            this.lblfiltroconboton.Name = "lblfiltroconboton";
            this.lblfiltroconboton.Size = new System.Drawing.Size(106, 13);
            this.lblfiltroconboton.TabIndex = 6;
            this.lblfiltroconboton.Text = "Busqueda por boton:";
            // 
            // txtfiltro
            // 
            this.txtfiltro.Location = new System.Drawing.Point(124, 13);
            this.txtfiltro.Name = "txtfiltro";
            this.txtfiltro.Size = new System.Drawing.Size(198, 20);
            this.txtfiltro.TabIndex = 7;
            // 
            // btnfiltro
            // 
            this.btnfiltro.Location = new System.Drawing.Point(328, 10);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(75, 23);
            this.btnfiltro.TabIndex = 8;
            this.btnfiltro.Text = "Buscar";
            this.btnfiltro.UseVisualStyleBackColor = true;
            this.btnfiltro.Click += new System.EventHandler(this.btnfiltro_Click);
            // 
            // lblfiltrosinboton
            // 
            this.lblfiltrosinboton.AutoSize = true;
            this.lblfiltrosinboton.Location = new System.Drawing.Point(12, 50);
            this.lblfiltrosinboton.Name = "lblfiltrosinboton";
            this.lblfiltrosinboton.Size = new System.Drawing.Size(104, 13);
            this.lblfiltrosinboton.TabIndex = 9;
            this.lblfiltrosinboton.Text = "Busqueda sin boton:";
            // 
            // txtfiltrosinboton
            // 
            this.txtfiltrosinboton.Location = new System.Drawing.Point(124, 50);
            this.txtfiltrosinboton.Name = "txtfiltrosinboton";
            this.txtfiltrosinboton.Size = new System.Drawing.Size(198, 20);
            this.txtfiltrosinboton.TabIndex = 10;
            this.txtfiltrosinboton.TextChanged += new System.EventHandler(this.txtfiltrosinboton_TextChanged);
            // 
            // cbcriterio
            // 
            this.cbcriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcriterio.FormattingEnabled = true;
            this.cbcriterio.Location = new System.Drawing.Point(250, 86);
            this.cbcriterio.Name = "cbcriterio";
            this.cbcriterio.Size = new System.Drawing.Size(130, 21);
            this.cbcriterio.TabIndex = 11;
            // 
            // cbcampo
            // 
            this.cbcampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcampo.FormattingEnabled = true;
            this.cbcampo.Location = new System.Drawing.Point(66, 86);
            this.cbcampo.Name = "cbcampo";
            this.cbcampo.Size = new System.Drawing.Size(130, 21);
            this.cbcampo.TabIndex = 12;
            this.cbcampo.SelectedIndexChanged += new System.EventHandler(this.cbcampo_SelectedIndexChanged);
            // 
            // lblcampo
            // 
            this.lblcampo.AutoSize = true;
            this.lblcampo.Location = new System.Drawing.Point(17, 89);
            this.lblcampo.Name = "lblcampo";
            this.lblcampo.Size = new System.Drawing.Size(43, 13);
            this.lblcampo.TabIndex = 13;
            this.lblcampo.Text = "Campo:";
            // 
            // lblcriterio
            // 
            this.lblcriterio.AutoSize = true;
            this.lblcriterio.Location = new System.Drawing.Point(202, 89);
            this.lblcriterio.Name = "lblcriterio";
            this.lblcriterio.Size = new System.Drawing.Size(42, 13);
            this.lblcriterio.TabIndex = 14;
            this.lblcriterio.Text = "Criterio:";
            // 
            // btnfiltroavanzado
            // 
            this.btnfiltroavanzado.Location = new System.Drawing.Point(563, 87);
            this.btnfiltroavanzado.Name = "btnfiltroavanzado";
            this.btnfiltroavanzado.Size = new System.Drawing.Size(75, 23);
            this.btnfiltroavanzado.TabIndex = 15;
            this.btnfiltroavanzado.Text = "Buscar";
            this.btnfiltroavanzado.UseVisualStyleBackColor = true;
            this.btnfiltroavanzado.Click += new System.EventHandler(this.btnfiltroavanzado_Click);
            // 
            // txtfiltroavanzado
            // 
            this.txtfiltroavanzado.Location = new System.Drawing.Point(424, 87);
            this.txtfiltroavanzado.Name = "txtfiltroavanzado";
            this.txtfiltroavanzado.Size = new System.Drawing.Size(133, 20);
            this.txtfiltroavanzado.TabIndex = 16;
            // 
            // lblfiltro
            // 
            this.lblfiltro.AutoSize = true;
            this.lblfiltro.Location = new System.Drawing.Point(386, 89);
            this.lblfiltro.Name = "lblfiltro";
            this.lblfiltro.Size = new System.Drawing.Size(32, 13);
            this.lblfiltro.TabIndex = 17;
            this.lblfiltro.Text = "Filtro:";
            // 
            // txtfiltroavanzadosolonumeros
            // 
            this.txtfiltroavanzadosolonumeros.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtfiltroavanzadosolonumeros.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtfiltroavanzadosolonumeros.Location = new System.Drawing.Point(424, 86);
            this.txtfiltroavanzadosolonumeros.Name = "txtfiltroavanzadosolonumeros";
            this.txtfiltroavanzadosolonumeros.Size = new System.Drawing.Size(133, 20);
            this.txtfiltroavanzadosolonumeros.TabIndex = 18;
            this.txtfiltroavanzadosolonumeros.Visible = false;
            this.txtfiltroavanzadosolonumeros.TextChanged += new System.EventHandler(this.txtfiltroavanzadosolonumeros_TextChanged);
            this.txtfiltroavanzadosolonumeros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfiltroavanzadosolonumeros_KeyPress);
            // 
            // btnresetearbusquedafiltrada
            // 
            this.btnresetearbusquedafiltrada.Location = new System.Drawing.Point(644, 87);
            this.btnresetearbusquedafiltrada.Name = "btnresetearbusquedafiltrada";
            this.btnresetearbusquedafiltrada.Size = new System.Drawing.Size(148, 23);
            this.btnresetearbusquedafiltrada.TabIndex = 19;
            this.btnresetearbusquedafiltrada.Text = "Resetear busqueda filtrada";
            this.btnresetearbusquedafiltrada.UseVisualStyleBackColor = true;
            this.btnresetearbusquedafiltrada.Click += new System.EventHandler(this.btnresetearbusquedafiltrada_Click);
            // 
            // frmdiscos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 549);
            this.Controls.Add(this.btnresetearbusquedafiltrada);
            this.Controls.Add(this.txtfiltroavanzadosolonumeros);
            this.Controls.Add(this.lblfiltro);
            this.Controls.Add(this.txtfiltroavanzado);
            this.Controls.Add(this.btnfiltroavanzado);
            this.Controls.Add(this.lblcriterio);
            this.Controls.Add(this.lblcampo);
            this.Controls.Add(this.cbcampo);
            this.Controls.Add(this.cbcriterio);
            this.Controls.Add(this.txtfiltrosinboton);
            this.Controls.Add(this.lblfiltrosinboton);
            this.Controls.Add(this.btnfiltro);
            this.Controls.Add(this.txtfiltro);
            this.Controls.Add(this.lblfiltroconboton);
            this.Controls.Add(this.btneliminarlogica);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.pbtapadiscos);
            this.Controls.Add(this.dgvdisco);
            this.MaximumSize = new System.Drawing.Size(872, 588);
            this.MinimumSize = new System.Drawing.Size(872, 588);
            this.Name = "frmdiscos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discos";
            this.Load += new System.EventHandler(this.frmdiscos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdisco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtapadiscos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvdisco;
        private System.Windows.Forms.PictureBox pbtapadiscos;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btneliminarlogica;
        private System.Windows.Forms.Label lblfiltroconboton;
        private System.Windows.Forms.TextBox txtfiltro;
        private System.Windows.Forms.Button btnfiltro;
        private System.Windows.Forms.Label lblfiltrosinboton;
        private System.Windows.Forms.TextBox txtfiltrosinboton;
        private System.Windows.Forms.ComboBox cbcriterio;
        private System.Windows.Forms.ComboBox cbcampo;
        private System.Windows.Forms.Label lblcampo;
        private System.Windows.Forms.Label lblcriterio;
        private System.Windows.Forms.Button btnfiltroavanzado;
        private System.Windows.Forms.TextBox txtfiltroavanzado;
        private System.Windows.Forms.Label lblfiltro;
        private System.Windows.Forms.TextBox txtfiltroavanzadosolonumeros;
        private System.Windows.Forms.Button btnresetearbusquedafiltrada;
    }
}

