using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
/// <summary>
/// Establece el estado actual del Pintor
/// </summary>
enum Estado {
    circulo,
    rectangulo,
    cambiando
}
/// <summary>
/// Menú donde se encuentran todos los controles
/// </summary>
class Menu_Control {
    readonly List<Button> panel_Control;
    public static bool modo_Mouse=false;
    public static Estado dibujando=Estado.cambiando;
    /// <summary>
    /// Se coloca el panel de control en una ventana
    /// </summary>
    /// <param name="ventana">Ventana donde se desea poner el panel de control, nota:usar this</param>
    public Menu_Control(Form ventana) {
        this.panel_Control = new List<Button>();
        iniciaComponentes(ventana);
    }
    /// <summary>
    /// Creacion de controles que estarán en el panel de control
    /// </summary>
    /// <param name="ventana_activa">Ventana en la que estará el panel de control</param>
    void iniciaComponentes(Form ventana_activa) {
        var etiquetas= new string[]{"Modo Mouse","Dibuja circulo","Dibuja cuadrado","Cambia color"};
        for (int i = 0; i < 4; i++) {
            this.panel_Control.Add(new Button());
            this.panel_Control[i].Size = new Size(this.panel_Control[i].Size.Width,50);
            this.panel_Control[i].Text = etiquetas[i];
            this.panel_Control[i].Location = new Point(i * this.panel_Control[i].Width + 10, 5);
            ventana_activa.Controls.Add(this.panel_Control[i]);
        }

        this.panel_Control[0].Click += new EventHandler(modo_Dibujo);
        this.panel_Control[1].Click += new EventHandler(dibujando_Circulo);
        this.panel_Control[2].Click += new EventHandler(dibujando_Rectangulo);
        this.panel_Control[3].Click += new EventHandler(dibujando_Color);
    }
    /// <summary>
    /// Cmabia el estado actual, de pintando con mouse a pintando usando el menu.
    /// </summary>
    void modo_Dibujo(object sender, EventArgs e) {
        if (!modo_Mouse) {
            this.panel_Control[1].Enabled = false;
            this.panel_Control[2].Enabled = false;
            this.panel_Control[3].Enabled = false;
            modo_Mouse = true;
        }
        else {
            this.panel_Control[1].Enabled = true;
            this.panel_Control[2].Enabled = true;
            this.panel_Control[3].Enabled = true;
            modo_Mouse = false;
        }
    }
    /*Metodos para cambiar la figura que se está dibujando en modo menu*/
    void dibujando_Circulo(object sender, EventArgs e) => dibujando = Estado.circulo;
    void dibujando_Rectangulo(object sender, EventArgs e) => dibujando = Estado.rectangulo;
    void dibujando_Color(object sender, EventArgs e) => dibujando = Estado.cambiando;
}

