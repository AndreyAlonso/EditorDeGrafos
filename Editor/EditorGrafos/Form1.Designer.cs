namespace EditorGrafos
{
    partial class EditorGrafo
    {
        /// <summary>
        /// Editor realizado por los alumnos de la ACM
        /// Arturo Garía Pérez
        /// Braulio Alejandro García Rivera
        /// Aldo Daniel Ponce Hernandez
        /// Andrey Hernandez Alonso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorGrafo));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Imprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.grafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aristaNoDirigidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Preferencias = new System.Windows.Forms.ToolStripMenuItem();
            this.Nombre = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.Open = new System.Windows.Forms.ToolStripButton();
            this.Print = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CrearNodo = new System.Windows.Forms.ToolStripButton();
            this.MueveNodo = new System.Windows.Forms.ToolStripButton();
            this.BorrarNodo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AristaNoDirigida = new System.Windows.Forms.ToolStripButton();
            this.AristaDirigida = new System.Windows.Forms.ToolStripButton();
            this.BorrarArista = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MueveGrafo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Cambia = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BorrarGrafo = new System.Windows.Forms.ToolStripButton();
            this.EliminarGrafo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.nPartita = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.grafoToolStripMenuItem,
            this.configuracionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.Imprimir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Archivo_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.AccessibleName = "Save";
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.AccessibleName = "Open";
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // Imprimir
            // 
            this.Imprimir.AccessibleName = "Imprimir";
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(120, 22);
            this.Imprimir.Text = "Imprimir";
            // 
            // grafoToolStripMenuItem
            // 
            this.grafoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nodoToolStripMenuItem,
            this.aristaToolStripMenuItem,
            this.moverGrafoToolStripMenuItem,
            this.borrarGrafoToolStripMenuItem,
            this.eliminarGrafoToolStripMenuItem});
            this.grafoToolStripMenuItem.Name = "grafoToolStripMenuItem";
            this.grafoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.grafoToolStripMenuItem.Text = "Grafo";
            this.grafoToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Grafo_Click);
            // 
            // nodoToolStripMenuItem
            // 
            this.nodoToolStripMenuItem.AccessibleName = "Nodo";
            this.nodoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearToolStripMenuItem,
            this.moverToolStripMenuItem,
            this.borrarNodoToolStripMenuItem});
            this.nodoToolStripMenuItem.Name = "nodoToolStripMenuItem";
            this.nodoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.nodoToolStripMenuItem.Text = "Nodo";
            this.nodoToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Nodo_Click);
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.AccessibleName = "CrearNodo";
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.crearToolStripMenuItem.Text = "Crear Nodo";
            // 
            // moverToolStripMenuItem
            // 
            this.moverToolStripMenuItem.AccessibleName = "MoverNodo";
            this.moverToolStripMenuItem.Name = "moverToolStripMenuItem";
            this.moverToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.moverToolStripMenuItem.Text = "Mover Nodo";
            // 
            // borrarNodoToolStripMenuItem
            // 
            this.borrarNodoToolStripMenuItem.AccessibleName = "BorrarNodo";
            this.borrarNodoToolStripMenuItem.Name = "borrarNodoToolStripMenuItem";
            this.borrarNodoToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.borrarNodoToolStripMenuItem.Text = "Borrar Nodo";
            // 
            // aristaToolStripMenuItem
            // 
            this.aristaToolStripMenuItem.AccessibleName = "Arista";
            this.aristaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearAristaToolStripMenuItem,
            this.aristaNoDirigidaToolStripMenuItem,
            this.moverAristaToolStripMenuItem});
            this.aristaToolStripMenuItem.Name = "aristaToolStripMenuItem";
            this.aristaToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aristaToolStripMenuItem.Text = "Arista";
            this.aristaToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Arista_Click);
            // 
            // crearAristaToolStripMenuItem
            // 
            this.crearAristaToolStripMenuItem.AccessibleName = "AristaDirigida";
            this.crearAristaToolStripMenuItem.Name = "crearAristaToolStripMenuItem";
            this.crearAristaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.crearAristaToolStripMenuItem.Text = "Arista Dirigida";
            // 
            // aristaNoDirigidaToolStripMenuItem
            // 
            this.aristaNoDirigidaToolStripMenuItem.AccessibleName = "AristaNoDirigida";
            this.aristaNoDirigidaToolStripMenuItem.Name = "aristaNoDirigidaToolStripMenuItem";
            this.aristaNoDirigidaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.aristaNoDirigidaToolStripMenuItem.Text = "Arista No Dirigida";
            // 
            // moverAristaToolStripMenuItem
            // 
            this.moverAristaToolStripMenuItem.AccessibleName = "BorrarArista";
            this.moverAristaToolStripMenuItem.Name = "moverAristaToolStripMenuItem";
            this.moverAristaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.moverAristaToolStripMenuItem.Text = "Borrar Arista";
            // 
            // moverGrafoToolStripMenuItem
            // 
            this.moverGrafoToolStripMenuItem.AccessibleName = "MoverGrafo";
            this.moverGrafoToolStripMenuItem.Name = "moverGrafoToolStripMenuItem";
            this.moverGrafoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.moverGrafoToolStripMenuItem.Text = "Mover Grafo";
            // 
            // borrarGrafoToolStripMenuItem
            // 
            this.borrarGrafoToolStripMenuItem.AccessibleName = "BorrarGrafo";
            this.borrarGrafoToolStripMenuItem.Name = "borrarGrafoToolStripMenuItem";
            this.borrarGrafoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.borrarGrafoToolStripMenuItem.Text = "Borrar Grafo";
            // 
            // eliminarGrafoToolStripMenuItem
            // 
            this.eliminarGrafoToolStripMenuItem.AccessibleName = "EliminarGrafo";
            this.eliminarGrafoToolStripMenuItem.Name = "eliminarGrafoToolStripMenuItem";
            this.eliminarGrafoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.eliminarGrafoToolStripMenuItem.Text = "Eliminar Grafo";
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Preferencias,
            this.Nombre});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            this.configuracionToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Configuracion_Clicked);
            // 
            // Preferencias
            // 
            this.Preferencias.AccessibleName = "Preferencias";
            this.Preferencias.Name = "Preferencias";
            this.Preferencias.Size = new System.Drawing.Size(170, 22);
            this.Preferencias.Text = "Preferencias...";
            // 
            // Nombre
            // 
            this.Nombre.AccessibleName = "Cambia";
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(170, 22);
            this.Nombre.Text = "Switch de nombre";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Open,
            this.Print,
            this.toolStripSeparator2,
            this.CrearNodo,
            this.MueveNodo,
            this.BorrarNodo,
            this.toolStripSeparator1,
            this.AristaNoDirigida,
            this.AristaDirigida,
            this.BorrarArista,
            this.toolStripSeparator3,
            this.MueveGrafo,
            this.toolStripButton1,
            this.Cambia,
            this.toolStripSeparator4,
            this.BorrarGrafo,
            this.EliminarGrafo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Toolbar_Clicked);
            // 
            // Save
            // 
            this.Save.AccessibleName = "Save";
            this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(36, 36);
            this.Save.Text = "Guardar en un archivo";
            // 
            // Open
            // 
            this.Open.AccessibleName = "Open";
            this.Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Open.Image = ((System.Drawing.Image)(resources.GetObject("Open.Image")));
            this.Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(36, 36);
            this.Open.Text = "toolStripButton1";
            this.Open.ToolTipText = "Abrir desde un archivo";
            // 
            // Print
            // 
            this.Print.AccessibleName = "Imprimir";
            this.Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Print.Image = ((System.Drawing.Image)(resources.GetObject("Print.Image")));
            this.Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(36, 36);
            this.Print.Text = "toolStripButton4";
            this.Print.ToolTipText = "Imprimir el grafo creado";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // CrearNodo
            // 
            this.CrearNodo.AccessibleName = "CrearNodo";
            this.CrearNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CrearNodo.Image = ((System.Drawing.Image)(resources.GetObject("CrearNodo.Image")));
            this.CrearNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CrearNodo.Name = "CrearNodo";
            this.CrearNodo.Size = new System.Drawing.Size(36, 36);
            this.CrearNodo.Text = "CrearNodo";
            this.CrearNodo.ToolTipText = "Crea un nuevo nodo";
            // 
            // MueveNodo
            // 
            this.MueveNodo.AccessibleName = "MoverNodo";
            this.MueveNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MueveNodo.Image = ((System.Drawing.Image)(resources.GetObject("MueveNodo.Image")));
            this.MueveNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MueveNodo.Name = "MueveNodo";
            this.MueveNodo.Size = new System.Drawing.Size(36, 36);
            this.MueveNodo.Text = "toolStripButton1";
            this.MueveNodo.ToolTipText = "Mueve un Nodo";
            // 
            // BorrarNodo
            // 
            this.BorrarNodo.AccessibleName = "BorrarNodo";
            this.BorrarNodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BorrarNodo.Image = ((System.Drawing.Image)(resources.GetObject("BorrarNodo.Image")));
            this.BorrarNodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BorrarNodo.Name = "BorrarNodo";
            this.BorrarNodo.Size = new System.Drawing.Size(36, 36);
            this.BorrarNodo.Text = "toolStripButton1";
            this.BorrarNodo.ToolTipText = "Borra un Nodo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // AristaNoDirigida
            // 
            this.AristaNoDirigida.AccessibleName = "AristaNoDirigida";
            this.AristaNoDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AristaNoDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaNoDirigida.Image")));
            this.AristaNoDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AristaNoDirigida.Name = "AristaNoDirigida";
            this.AristaNoDirigida.Size = new System.Drawing.Size(36, 36);
            this.AristaNoDirigida.Text = "toolStripButton2";
            this.AristaNoDirigida.ToolTipText = "Crea una nueva Arista no dirigida";
            // 
            // AristaDirigida
            // 
            this.AristaDirigida.AccessibleName = "AristaDirigida";
            this.AristaDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AristaDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaDirigida.Image")));
            this.AristaDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AristaDirigida.Name = "AristaDirigida";
            this.AristaDirigida.Size = new System.Drawing.Size(36, 36);
            this.AristaDirigida.Text = "toolStripButton2";
            this.AristaDirigida.ToolTipText = "Crea una nueva Arista dirigida";
            // 
            // BorrarArista
            // 
            this.BorrarArista.AccessibleName = "BorrarArista";
            this.BorrarArista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BorrarArista.Image = ((System.Drawing.Image)(resources.GetObject("BorrarArista.Image")));
            this.BorrarArista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BorrarArista.Name = "BorrarArista";
            this.BorrarArista.Size = new System.Drawing.Size(36, 36);
            this.BorrarArista.Text = "toolStripButton1";
            this.BorrarArista.ToolTipText = "Elimina una Arista";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // MueveGrafo
            // 
            this.MueveGrafo.AccessibleName = "MoverGrafo";
            this.MueveGrafo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MueveGrafo.Image = ((System.Drawing.Image)(resources.GetObject("MueveGrafo.Image")));
            this.MueveGrafo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MueveGrafo.Name = "MueveGrafo";
            this.MueveGrafo.Size = new System.Drawing.Size(36, 36);
            this.MueveGrafo.Text = "toolStripButton1";
            this.MueveGrafo.ToolTipText = "Mueve el grafo completo";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AccessibleName = "Preferencias";
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Abre el menu de configuracion del nodo";
            // 
            // Cambia
            // 
            this.Cambia.AccessibleName = "Cambia";
            this.Cambia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cambia.Image = ((System.Drawing.Image)(resources.GetObject("Cambia.Image")));
            this.Cambia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cambia.Name = "Cambia";
            this.Cambia.Size = new System.Drawing.Size(36, 36);
            this.Cambia.Text = "toolStripButton2";
            this.Cambia.ToolTipText = "Cambia todos los nodos de letras a numeros y viceversa";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // BorrarGrafo
            // 
            this.BorrarGrafo.AccessibleName = "BorrarGrafo";
            this.BorrarGrafo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BorrarGrafo.Image = ((System.Drawing.Image)(resources.GetObject("BorrarGrafo.Image")));
            this.BorrarGrafo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BorrarGrafo.Name = "BorrarGrafo";
            this.BorrarGrafo.Size = new System.Drawing.Size(36, 36);
            this.BorrarGrafo.Text = "toolStripButton2";
            this.BorrarGrafo.ToolTipText = "Borra el grafo del area cliente";
            // 
            // EliminarGrafo
            // 
            this.EliminarGrafo.AccessibleName = "EliminarGrafo";
            this.EliminarGrafo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminarGrafo.Image = ((System.Drawing.Image)(resources.GetObject("EliminarGrafo.Image")));
            this.EliminarGrafo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminarGrafo.Name = "EliminarGrafo";
            this.EliminarGrafo.Size = new System.Drawing.Size(36, 36);
            this.EliminarGrafo.Text = "toolStripButton3";
            this.EliminarGrafo.ToolTipText = "Elimina el grafo y crea uno nuevo";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton6,
            this.nPartita});
            this.toolStrip2.Location = new System.Drawing.Point(0, 63);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(37, 598);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.metodosAdicionales);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AccessibleName = "complemento";
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::EditorGrafos.Properties.Resources.favicon;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton2.Text = "Complemento del Grafo";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AccessibleName = "preExamen_1";
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton6.Text = "Grados";
            // 
            // nPartita
            // 
            this.nPartita.AccessibleName = "nPartita";
            this.nPartita.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nPartita.Image = ((System.Drawing.Image)(resources.GetObject("nPartita.Image")));
            this.nPartita.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nPartita.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nPartita.Name = "nPartita";
            this.nPartita.Size = new System.Drawing.Size(34, 36);
            this.nPartita.Text = "n-Partita";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip3.Location = new System.Drawing.Point(947, 63);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(37, 598);
            this.toolStrip3.TabIndex = 4;
            this.toolStrip3.Text = "toolStrip3";
            this.toolStrip3.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.grafosEspeciales);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AccessibleDescription = "Grafo  Completo";
            this.toolStripButton3.AccessibleName = "GrafoKn";
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton3.Text = "Grafo Completo";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AccessibleDescription = "Grafo Ciclo";
            this.toolStripButton4.AccessibleName = "GrafoCn";
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton4.Text = "Grafo Ciclo";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AccessibleDescription = "Grafo de Volante";
            this.toolStripButton5.AccessibleName = "GrafoWn";
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton5.Text = "Grafo Volante";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(905, 80);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericKn);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(905, 123);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericCn);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(905, 162);
            this.numericUpDown3.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown3.TabIndex = 7;
            this.numericUpDown3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericWn);
            // 
            // EditorGrafo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorGrafo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Grafos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearAristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverAristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Preferencias;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton CrearNodo;
        private System.Windows.Forms.ToolStripButton AristaNoDirigida;
        private System.Windows.Forms.ToolStripButton MueveNodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BorrarNodo;
        private System.Windows.Forms.ToolStripMenuItem Imprimir;
        private System.Windows.Forms.ToolStripMenuItem Nombre;
        private System.Windows.Forms.ToolStripButton BorrarArista;
        private System.Windows.Forms.ToolStripButton Open;
        private System.Windows.Forms.ToolStripButton Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton MueveGrafo;
        private System.Windows.Forms.ToolStripButton BorrarGrafo;
        private System.Windows.Forms.ToolStripButton EliminarGrafo;
        private System.Windows.Forms.ToolStripButton Print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton Cambia;
        private System.Windows.Forms.ToolStripButton AristaDirigida;
        private System.Windows.Forms.ToolStripMenuItem aristaNoDirigidaToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton nPartita;
    }
}

