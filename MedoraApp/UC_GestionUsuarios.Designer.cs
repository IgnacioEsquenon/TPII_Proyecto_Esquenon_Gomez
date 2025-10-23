namespace MedoraApp
{
    partial class UC_GestionUsuarios
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_Usuarios = new System.Windows.Forms.DataGridView();
            this.id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Roles = new System.Windows.Forms.ComboBox();
            this.lb_Especialidad = new System.Windows.Forms.Label();
            this.CB_Especialidades = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Estados = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 51);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion de Usuarios";
            // 
            // DGV_Usuarios
            // 
            this.DGV_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Usuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_usuario,
            this.Estado,
            this.nombre,
            this.apellido,
            this.dni,
            this.email,
            this.nombre_rol,
            this.nombre_Especialidad,
            this.btnEliminar});
            this.DGV_Usuarios.Location = new System.Drawing.Point(3, 120);
            this.DGV_Usuarios.Name = "DGV_Usuarios";
            this.DGV_Usuarios.Size = new System.Drawing.Size(757, 246);
            this.DGV_Usuarios.TabIndex = 19;
            this.DGV_Usuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Usuarios_CellContentClick);
            this.DGV_Usuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_Usuarios_CellFormatting);
            // 
            // id_usuario
            // 
            this.id_usuario.DataPropertyName = "id_usuario";
            this.id_usuario.HeaderText = "id_usuario";
            this.id_usuario.Name = "id_usuario";
            this.id_usuario.Visible = false;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "estado_usuario";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "nombre";
            this.nombre.Name = "nombre";
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "apellido";
            this.apellido.Name = "apellido";
            // 
            // dni
            // 
            this.dni.DataPropertyName = "dni";
            this.dni.HeaderText = "dni";
            this.dni.Name = "dni";
            this.dni.Visible = false;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "email";
            this.email.Name = "email";
            // 
            // nombre_rol
            // 
            this.nombre_rol.DataPropertyName = "nombre_rol";
            this.nombre_rol.HeaderText = "Rol";
            this.nombre_rol.Name = "nombre_rol";
            // 
            // nombre_Especialidad
            // 
            this.nombre_Especialidad.DataPropertyName = "nombre_especialidad";
            this.nombre_Especialidad.HeaderText = "Especialidad";
            this.nombre_Especialidad.Name = "nombre_Especialidad";
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "Eliminar";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseColumnTextForButtonValue = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Filtrar por -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(327, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 21;
            this.label3.Text = "Rol:";
            // 
            // CB_Roles
            // 
            this.CB_Roles.FormattingEnabled = true;
            this.CB_Roles.Location = new System.Drawing.Point(379, 78);
            this.CB_Roles.Name = "CB_Roles";
            this.CB_Roles.Size = new System.Drawing.Size(121, 21);
            this.CB_Roles.TabIndex = 22;
            this.CB_Roles.SelectedIndexChanged += new System.EventHandler(this.CB_Roles_SelectedIndexChanged);
            // 
            // lb_Especialidad
            // 
            this.lb_Especialidad.AutoSize = true;
            this.lb_Especialidad.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold);
            this.lb_Especialidad.Location = new System.Drawing.Point(506, 78);
            this.lb_Especialidad.Name = "lb_Especialidad";
            this.lb_Especialidad.Size = new System.Drawing.Size(127, 21);
            this.lb_Especialidad.TabIndex = 23;
            this.lb_Especialidad.Text = "Especialidad:";
            this.lb_Especialidad.Visible = false;
            // 
            // CB_Especialidades
            // 
            this.CB_Especialidades.FormattingEnabled = true;
            this.CB_Especialidades.Location = new System.Drawing.Point(629, 78);
            this.CB_Especialidades.Name = "CB_Especialidades";
            this.CB_Especialidades.Size = new System.Drawing.Size(150, 21);
            this.CB_Especialidades.TabIndex = 24;
            this.CB_Especialidades.Visible = false;
            this.CB_Especialidades.SelectedIndexChanged += new System.EventHandler(this.CB_Especialidad_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(125, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 25;
            this.label4.Text = "Estado:";
            // 
            // CB_Estados
            // 
            this.CB_Estados.FormattingEnabled = true;
            this.CB_Estados.Location = new System.Drawing.Point(200, 78);
            this.CB_Estados.Name = "CB_Estados";
            this.CB_Estados.Size = new System.Drawing.Size(121, 21);
            this.CB_Estados.TabIndex = 26;
            this.CB_Estados.SelectedIndexChanged += new System.EventHandler(this.CB_Estados_SelectedIndexChanged);
            // 
            // UC_GestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.Controls.Add(this.CB_Estados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_Especialidades);
            this.Controls.Add(this.lb_Especialidad);
            this.Controls.Add(this.CB_Roles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGV_Usuarios);
            this.Controls.Add(this.panel1);
            this.Name = "UC_GestionUsuarios";
            this.Size = new System.Drawing.Size(799, 369);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGV_Usuarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Roles;
        private System.Windows.Forms.Label lb_Especialidad;
        private System.Windows.Forms.ComboBox CB_Especialidades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Estados;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Especialidad;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
    }
}
